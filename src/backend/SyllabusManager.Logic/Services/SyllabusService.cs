﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SyllabusManager.Data;
using SyllabusManager.Data.Enums.LearningOutcomes;
using SyllabusManager.Data.Models.Syllabuses;
using SyllabusManager.Data.Models.User;
using SyllabusManager.Logic.Helpers;
using SyllabusManager.Logic.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SyllabusManager.Logic.Pdf;
using SyllabusManager.Data.Enums.Syllabuses;

namespace SyllabusManager.Logic.Services
{
    public class SyllabusService : DocumentInAcademicYearService<Syllabus>, ISyllabusService
    {
        private readonly ISyllabusPdf _syllabusPdf;
        private readonly IPlanPdf _planPdf;

        public SyllabusService(SyllabusManagerDbContext dbContext, UserManager<SyllabusManagerUser> userManager, ISyllabusPdf syllabusPdf, IPlanPdf planPdf) : base(dbContext, userManager)
        {
            this._syllabusPdf = syllabusPdf;
            _planPdf = planPdf;
        }

        public async Task<Syllabus> Latest(string fos, string spec, string year)
        {
            Syllabus syllabus = await _dbSet.Include(s => s.FieldOfStudy)
                .Include(s => s.Specialization)
                .Include(s => s.Description)
                .Include(s => s.SubjectDescriptions)
                .ThenInclude(sd => sd.Subject)
                .Include(s => s.PointLimits)
                .OrderByDescending(s => s.Version)
                .FirstOrDefaultAsync(s =>
                    s.FieldOfStudy.Code == fos
                    && s.Specialization.Code == spec
                    && s.AcademicYear == year
                    && !s.IsDeleted);

            if (syllabus is null)
            {
                syllabus = new Syllabus
                {
                    FieldOfStudy = _dbContext.FieldsOfStudies.Include(f => f.Specializations)
                        .FirstOrDefault(f => f.Code == fos),
                    Specialization = _dbContext.Specializations.Find(spec),
                    AcademicYear = year,
                    Version = "new",
                    PointLimits = SyllabusHelper.PredefinedPointLimits
                };
            }

            if (syllabus.FieldOfStudy is null || syllabus.Specialization is null) return null;

            return syllabus;
        }

        /// <summary>
        /// Zapisuje obiekt w najnowsze wersji
        /// </summary>
        /// <param name="syllabus"></param>
        /// <returns></returns>
        public async Task<Syllabus> Save(Syllabus syllabus, SyllabusManagerUser user)
        {
            Syllabus currentDocument = await _dbSet.Include(s => s.FieldOfStudy)
                .Include(s => s.Specialization)
                .Include(s => s.Description)
                .Include(s => s.SubjectDescriptions)
                .ThenInclude(sd => sd.Subject)
                .Include(s => s.PointLimits)
                .OrderByDescending(s => s.Version)
                .FirstOrDefaultAsync(s =>
                    s.FieldOfStudy.Code == syllabus.FieldOfStudy.Code
                    && s.Specialization.Code == syllabus.Specialization.Code
                    && s.AcademicYear == syllabus.AcademicYear
                    && !s.IsDeleted);

            if (currentDocument is null)
            {
                syllabus.Version = NewVersion();
                syllabus.CreationDate = DateTime.Now;
                syllabus.AuthorName = user.Name;
            }
            else
                syllabus.Version = IncreaseVersion(currentDocument.Version);

            syllabus.Id = Guid.NewGuid();

            syllabus.SubjectDescriptions.ForEach(sd =>
            {
                sd.Id = Guid.NewGuid();
                if (sd.Subject != null)
                {
                    Data.Models.Subjects.Subject subj = _dbContext.Subjects.Find(sd.Subject.Id);
                    sd.Subject = subj;
                }
            });

            syllabus.PointLimits.ForEach(pl => pl.Id = Guid.NewGuid());

            syllabus.Description.Id = Guid.NewGuid();

            Data.Models.FieldOfStudies.FieldOfStudy fos = _dbContext.FieldsOfStudies.Find(syllabus.FieldOfStudy.Code);
            syllabus.FieldOfStudy = fos;
            syllabus.Specialization = _dbContext.Specializations.Find(syllabus.Specialization.Code);

            syllabus.IsDeleted = false;

            await _dbSet.AddAsync(syllabus);
            await _dbContext.SaveChangesAsync();

            return syllabus;
        }

        /// <summary>
        /// Zapisuje obiekt w najnowszej wersji ale jako inny obiekt o podanych parametrach
        /// </summary>
        /// <param name="fos"></param>
        /// <param name="spec"></param>
        /// <param name="year"></param>
        /// <param name="syllabus"></param>
        /// <returns></returns>
        public async Task<Syllabus> SaveAs(string fosCode, string specCode, string academicYear, Syllabus syllabus,
            SyllabusManagerUser user)
        {
            Syllabus currentSyllabus = await Latest(fosCode, specCode, academicYear);

            currentSyllabus.ThesisCourse = syllabus.ThesisCourse;
            currentSyllabus.Description = syllabus.Description;
            currentSyllabus.IntershipType = syllabus.IntershipType;
            currentSyllabus.OpinionDeadline = syllabus.OpinionDeadline;
            currentSyllabus.ScopeOfDiplomaExam = syllabus.ScopeOfDiplomaExam;
            currentSyllabus.PointLimits = syllabus.PointLimits;

            return await Save(currentSyllabus, user);
        }

        /// <summary>
        /// Pobiera najnowszą wersję z obiektu o podanych parametrach i zapisuje jej kopię jako najnowsza wersja obiektu
        /// </summary>
        /// <param name="currentDocId"></param>
        /// <param name="fos"></param>
        /// <param name="spec"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public async Task<Syllabus> ImportFrom(Guid currentDocId, string fosCode, string specCode, string academicYear,
            SyllabusManagerUser user)
        {
            Syllabus currentSyllabus = await _dbSet.AsNoTracking()
                .Include(s => s.FieldOfStudy)
                .Include(s => s.Specialization)
                .Include(s => s.SubjectDescriptions)
                .ThenInclude(sd => sd.Subject)
                .Include(s => s.Description)
                .Include(s => s.PointLimits)
                .FirstOrDefaultAsync(s =>
                    s.Id == currentDocId
                    && !s.IsDeleted);

            Syllabus syllabus = await _dbSet.AsNoTracking()
                .Include(s => s.FieldOfStudy)
                .Include(s => s.Specialization)
                .Include(s => s.SubjectDescriptions)
                .ThenInclude(sd => sd.Subject)
                .Include(s => s.Description)
                .Include(s => s.PointLimits)
                .FirstOrDefaultAsync(s =>
                    s.FieldOfStudy.Code == fosCode
                    && s.AcademicYear == academicYear
                    && s.Specialization.Code == specCode
                    && !s.IsDeleted);

            if (currentSyllabus is null || syllabus?.FieldOfStudy is null || syllabus.Specialization is null)
                return null;

            currentSyllabus.ThesisCourse = syllabus.ThesisCourse;
            currentSyllabus.Description = syllabus.Description;
            currentSyllabus.IntershipType = syllabus.IntershipType;
            currentSyllabus.OpinionDeadline = syllabus.OpinionDeadline;
            currentSyllabus.ScopeOfDiplomaExam = syllabus.ScopeOfDiplomaExam;
            currentSyllabus.PointLimits = syllabus.PointLimits;

            return await Save(currentSyllabus, user);
        }

        /// <summary>
        /// Pobiera historię wersji (jako lista string z nazwami wersji)
        /// </summary>
        /// <param name="currentDocId"></param>
        /// <returns></returns>
        public async Task<List<string>> History(Guid id)
        {
            Syllabus syllabus = await _dbSet.Include(s => s.FieldOfStudy)
                .Include(s => s.Specialization)
                .Include(s => s.Description)
                .FirstOrDefaultAsync(s =>
                    s.Id == id
                    && !s.IsDeleted);

            List<string> versions = await _dbSet.Include(s => s.FieldOfStudy)
                .Include(s => s.Specialization)
                .Where(s =>
                    s.AcademicYear == syllabus.AcademicYear
                    && s.FieldOfStudy == syllabus.FieldOfStudy
                    && s.Specialization == syllabus.Specialization
                    && !s.IsDeleted)
                .OrderByDescending(s => s.Version)
                .Select(s => $"{s.Id}:{s.Version}")
                .ToListAsync();
            return versions;
        }

        public async Task<bool> Delete(Guid id)
        {
            Syllabus entity = _dbSet.Include(s => s.FieldOfStudy)
                .Include(s => s.Specialization).FirstOrDefault(f => f.Id == id);

            List<Syllabus> syllabuses = await _dbSet.Include(s => s.FieldOfStudy)
                .Include(s => s.Specialization)
                .Where(s =>
                    s.FieldOfStudy == entity.FieldOfStudy
                    && s.Specialization == entity.Specialization
                    && s.AcademicYear == entity.AcademicYear
                    && !s.IsDeleted).ToListAsync();

            syllabuses.ForEach(s => s.IsDeleted = true);
            int state = await _dbContext.SaveChangesAsync();
            return state > 0;
        }

        public async Task<bool> Pdf(Guid id)
        {
            Syllabus syllabus = await _dbSet.Include(s => s.FieldOfStudy)
                .Include(s => s.Specialization)
                .Include(s => s.SubjectDescriptions)
                .ThenInclude(sd => sd.Subject)
                .ThenInclude(sb => sb.Lessons)
                .Include(s => s.Description)
                .Include(s => s.PointLimits)
                .FirstOrDefaultAsync(s =>
                    s.Id == id
                    && !s.IsDeleted);


            if (syllabus is null)
                return false;


            Dictionary<LearningOutcomeCategory, int> lods = (await _dbContext.LearningOutcomeDocuments.Include(lod => lod.FieldOfStudy)
                                                     .Include(lod => lod.LearningOutcomes)
                                                     .OrderByDescending(lod => lod.Version)
                                                     .FirstOrDefaultAsync(lod =>
                                                                                lod.FieldOfStudy.Code == syllabus.FieldOfStudy.Code
                                                                             && lod.AcademicYear == syllabus.AcademicYear
                                                                             && !lod.IsDeleted)
                                                     )?.LearningOutcomes?.GroupBy(l => l.Category)
                                                                         .Select(c => new { category = c.Key, count = c.Count() })
                                                                         .ToDictionary(d => d.category, d => d.count);

            _syllabusPdf.Create(syllabus, lods);

            return true;
        }

        public async Task<bool> Pdf(string fos, string spec, string year)
        {
            Syllabus syllabus = await _dbSet.Include(s => s.FieldOfStudy)
                .Include(s => s.Specialization)
                .Include(s => s.SubjectDescriptions)
                .ThenInclude(sd => sd.Subject)
                .ThenInclude(sb => sb.Lessons)
                .Include(s => s.Description)
                .Include(s => s.PointLimits)
                .FirstOrDefaultAsync(s =>
                    s.FieldOfStudy.Code == fos
                    && s.Specialization.Code == spec
                    && s.AcademicYear == year
                    && !s.IsDeleted);


            if (syllabus is null)
                return false;

            Dictionary<LearningOutcomeCategory, int> lods = (await _dbContext.LearningOutcomeDocuments.Include(lod => lod.FieldOfStudy)
                                                     .Include(lod => lod.LearningOutcomes)
                                                     .OrderByDescending(lod => lod.Version)
                                                     .FirstOrDefaultAsync(lod =>
                                                                                lod.FieldOfStudy.Code == syllabus.FieldOfStudy.Code
                                                                             && lod.AcademicYear == syllabus.AcademicYear
                                                                             && !lod.IsDeleted)
                                                     )?.LearningOutcomes?.GroupBy(l => l.Category)
                                                                         .Select(c => new { category = c.Key, count = c.Count() })
                                                                         .ToDictionary(d => d.category, d => d.count);

            _syllabusPdf.Create(syllabus, lods);

            return true;
        }

        public async Task<bool> PlanPdf(Guid id)
        {
            Syllabus syllabus = await _dbSet.Include(s => s.FieldOfStudy)
                .Include(s => s.Specialization)
                .Include(s => s.SubjectDescriptions)
                .ThenInclude(sd => sd.Subject)
                .ThenInclude(sb => sb.Lessons)
                .Include(s => s.Description)
                .Include(s => s.PointLimits)
                .FirstOrDefaultAsync(s =>
                    s.Id == id
                    && !s.IsDeleted);


            if (syllabus is null)
                return false;

            _planPdf.Create(syllabus);

            return true;
        }

        public List<string> Verify(Syllabus syllabus)
        {
            var errors = new List<string>();

            // description
            if (syllabus.Description.NumOfSemesters < 1 || syllabus.Description.NumOfSemesters > 10) errors.Add("Niepoprawna liczba semestrów. (Dopuszczalne wartości 1-10)");
            if (string.IsNullOrWhiteSpace(syllabus.Description.Prerequisites) || syllabus.Description.Prerequisites == ".") errors.Add("Nieuzupełnione pole Wymagania wstępne.");
            if (string.IsNullOrWhiteSpace(syllabus.Description.EmploymentOpportunities) || syllabus.Description.EmploymentOpportunities == ".") errors.Add("Nieuzupełnione pole Sylwetka absolwenta.");
            if (string.IsNullOrWhiteSpace(syllabus.Description.PossibilityOfContinuation) || syllabus.Description.PossibilityOfContinuation == ".") errors.Add("Nieuzupełnione pole Możliwość kontynuacji studiów.");

            // subjects
            var wrongSubjects =
                syllabus.SubjectDescriptions.Where(sd => sd.AssignedSemester > syllabus.Description.NumOfSemesters);
            foreach (var subject in wrongSubjects)
            {
                errors.Add($"Przedmiot {subject.Subject.Code} \"{subject.Subject.NamePl}\" posiada niepoprawny przypisany semestr.");
            }

            wrongSubjects =
                syllabus.SubjectDescriptions.Where(sd => sd.CompletionSemester != null && sd.AssignedSemester > sd.CompletionSemester);
            foreach (var subject in wrongSubjects)
            {
                errors.Add($"Przedmiot {subject.Subject.Code} \"{subject.Subject.NamePl}\" posiada przypisany semestr większy niż semestr ukończenia.");
            }

            // obligatory fields
            if (string.IsNullOrWhiteSpace(syllabus.ThesisCourse) || syllabus.ThesisCourse == ".") errors.Add("Nieuzupełnione pole Praca dyplomowa.");
            if (string.IsNullOrWhiteSpace(syllabus.ScopeOfDiplomaExam) || syllabus.ScopeOfDiplomaExam == ".") errors.Add("Nieuzupełnione pole Zakres egzaminu dyplomowego.");
            if (string.IsNullOrWhiteSpace(syllabus.IntershipType) || syllabus.IntershipType == ".") errors.Add("Nieuzupełnione pole Praktyki.");
            
            return errors;
        }

        public async Task<bool> SendToAcceptance(Syllabus syllabus, SyllabusManagerUser user)
        {
            /*if (!Verify(syllabus).Any() && syllabus.State != State.Approved)
            {
                var result = await Save(syllabus, user);
                result.State = State.SentToAcceptance;
                result.StudentGovernmentOpinion = Option.Pending;
                result.StudentRepresentativeName = string.Empty;
                await _dbContext.SaveChangesAsync();
                return true;
            }*/

            return false;
        }

        public bool Accept(Guid syllabusId, SyllabusManagerUser user)
        {
            var document = _dbSet.Find(syllabusId);
            if (document.State == State.SentToAcceptance)
            {
                document.StudentGovernmentOpinion = Option.Approved;
                document.StudentRepresentativeName = user.Name;
                document.State = State.Approved;
                _dbContext.SaveChanges();
                return true;
            }

            return false;
        }

        public bool Reject(Guid syllabusId, SyllabusManagerUser user)
        {
            var document = _dbSet.Find(syllabusId);
            if (document.State == State.SentToAcceptance)
            {
                document.StudentGovernmentOpinion = Option.Rejected;
                document.StudentRepresentativeName = user.Name;
                document.State = State.Rejected;
                _dbContext.SaveChanges();
                return true;
            }

            return false;
        }

        public List<Syllabus> ToAccept(string fos, string spec, string year)
        {
            return _dbSet.AsNoTracking()
                .Include(s => s.FieldOfStudy)
                .Include(s => s.Specialization)
                .Where(s =>
                    (fos == null || s.FieldOfStudy.Code == fos)
                    && (spec == null || s.Specialization.Code == spec)
                    && (year == null || s.AcademicYear == year)
                    && s.State == State.SentToAcceptance
                    && !s.IsDeleted).ToList()
                .GroupBy(s => new { s.FieldOfStudy, s.Specialization, s.AcademicYear })
                .Select(g => g.OrderByDescending(s => s.Version)
                    .First()).ToList();
        }

        public List<Syllabus> Documents(string fos, string spec, string year)
        {
            return _dbSet.AsNoTracking()
                .Include(s => s.FieldOfStudy)
                .Include(s => s.Specialization)
                .Include(s => s.SubjectDescriptions)
                .ThenInclude(sd => sd.Subject)
                .Where(s =>
                    (fos == null || s.FieldOfStudy.Code == fos)
                    && (spec == null || s.Specialization.Code == spec)
                    && (year == null || s.AcademicYear == year)
                    && s.State == State.Approved
                    && !s.IsDeleted).ToList()
                .GroupBy(s => new { s.FieldOfStudy, s.Specialization, s.AcademicYear })
                .Select(g => g.OrderByDescending(s => s.Version)
                    .First()).ToList();
        }

        public static bool AreChanges(Syllabus previous, Syllabus current)
        {
            return true;
        }
    }
}

