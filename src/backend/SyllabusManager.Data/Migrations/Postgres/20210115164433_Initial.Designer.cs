﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SyllabusManager.Data.ProviderContexts;

namespace SyllabusManager.Data.Migrations.Postgres
{
    [DbContext(typeof(PostgresSyllabusManagerDbContext))]
    [Migration("20210115164433_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("SyllabusManager.Data.Models.FieldOfStudies.FieldOfStudy", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("text");

                    b.Property<string>("BranchOfScience")
                        .HasColumnType("text");

                    b.Property<string>("Discipline")
                        .HasColumnType("text");

                    b.Property<string>("Faculty")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<int>("Language")
                        .HasColumnType("integer");

                    b.Property<int>("Level")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Profile")
                        .HasColumnType("integer");

                    b.Property<string>("SupervisorId")
                        .HasColumnType("text");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Code");

                    b.HasIndex("SupervisorId");

                    b.ToTable("FieldsOfStudies");
                });

            modelBuilder.Entity("SyllabusManager.Data.Models.FieldOfStudies.Specialization", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("text");

                    b.Property<string>("FieldOfStudyCode")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Code");

                    b.HasIndex("FieldOfStudyCode");

                    b.ToTable("Specializations");
                });

            modelBuilder.Entity("SyllabusManager.Data.Models.LearningOutcomes.LearningOutcome", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<int>("Category")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<Guid?>("LearningOutcomeDocumentId")
                        .HasColumnType("uuid");

                    b.Property<string>("S2degreePrk")
                        .HasColumnType("text");

                    b.Property<string>("S2degreePrkeng")
                        .HasColumnType("text");

                    b.Property<string>("SpecializationCode")
                        .HasColumnType("text");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("U1degreeCharacteristics")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("LearningOutcomeDocumentId");

                    b.HasIndex("SpecializationCode");

                    b.ToTable("LearningOutcome");
                });

            modelBuilder.Entity("SyllabusManager.Data.Models.LearningOutcomes.LearningOutcomeDocument", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("AcademicYear")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FieldOfStudyCode")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Version")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("FieldOfStudyCode");

                    b.ToTable("LearningOutcomeDocuments");
                });

            modelBuilder.Entity("SyllabusManager.Data.Models.ManyToMany.SubjectTeacher", b =>
                {
                    b.Property<Guid>("SubjectId")
                        .HasColumnType("uuid");

                    b.Property<string>("TeacherId")
                        .HasColumnType("text");

                    b.HasKey("SubjectId", "TeacherId");

                    b.HasIndex("TeacherId");

                    b.ToTable("SubjectTeacher");
                });

            modelBuilder.Entity("SyllabusManager.Data.Models.Subjects.CardEntries", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("SubjectId")
                        .HasColumnType("uuid");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("SubjectId");

                    b.ToTable("CardEntries");
                });

            modelBuilder.Entity("SyllabusManager.Data.Models.Subjects.CardEntry", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("CardEntriesId")
                        .HasColumnType("uuid");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CardEntriesId");

                    b.ToTable("CardEntry");
                });

            modelBuilder.Entity("SyllabusManager.Data.Models.Subjects.ClassForm", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int>("Hours")
                        .HasColumnType("integer");

                    b.Property<Guid?>("LessonId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("LessonId");

                    b.ToTable("ClassForm");
                });

            modelBuilder.Entity("SyllabusManager.Data.Models.Subjects.LearningOutcomeEvaluation", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int>("GradingSystem")
                        .HasColumnType("integer");

                    b.Property<string>("LearningOutcomeSymbol")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("SubjectId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("SubjectId");

                    b.ToTable("LearningOutcomeEvaluation");
                });

            modelBuilder.Entity("SyllabusManager.Data.Models.Subjects.Lesson", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<int>("Ects")
                        .HasColumnType("integer");

                    b.Property<int>("EctsinclDirectTeacherStudentContactClasses")
                        .HasColumnType("integer");

                    b.Property<int>("EctsinclPracticalClasses")
                        .HasColumnType("integer");

                    b.Property<int>("FormOfCrediting")
                        .HasColumnType("integer");

                    b.Property<int>("HoursAtUniversity")
                        .HasColumnType("integer");

                    b.Property<bool>("IsFinal")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsGroup")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsScientific")
                        .HasColumnType("boolean");

                    b.Property<int>("LessonType")
                        .HasColumnType("integer");

                    b.Property<int>("StudentWorkloadHours")
                        .HasColumnType("integer");

                    b.Property<Guid?>("SubjectId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("SubjectId");

                    b.ToTable("Lesson");
                });

            modelBuilder.Entity("SyllabusManager.Data.Models.Subjects.Literature", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("Authors")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Distributor")
                        .HasColumnType("text");

                    b.Property<bool>("IsPrimary")
                        .HasColumnType("boolean");

                    b.Property<string>("Isbn")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("SubjectId")
                        .HasColumnType("uuid");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("Year")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("SubjectId");

                    b.ToTable("Literature");
                });

            modelBuilder.Entity("SyllabusManager.Data.Models.Subjects.Subject", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("AcademicYear")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FieldOfStudyCode")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<int>("KindOfSubject")
                        .HasColumnType("integer");

                    b.Property<int>("Language")
                        .HasColumnType("integer");

                    b.Property<int>("ModuleType")
                        .HasColumnType("integer");

                    b.Property<string>("NameEng")
                        .HasColumnType("text");

                    b.Property<string>("NamePl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SpecializationCode")
                        .HasColumnType("text");

                    b.Property<string>("SupervisorId")
                        .HasColumnType("text");

                    b.Property<int>("TypeOfSubject")
                        .HasColumnType("integer");

                    b.Property<string>("Version")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("FieldOfStudyCode");

                    b.HasIndex("SpecializationCode");

                    b.HasIndex("SupervisorId");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("SyllabusManager.Data.Models.Syllabuses.PointLimit", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<int?>("KindOfSubject")
                        .HasColumnType("integer");

                    b.Property<int>("ModuleType")
                        .HasColumnType("integer");

                    b.Property<int>("Points")
                        .HasColumnType("integer");

                    b.Property<Guid?>("SyllabusId")
                        .HasColumnType("uuid");

                    b.Property<int?>("TypeOfSubject")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("SyllabusId");

                    b.ToTable("PointLimit");
                });

            modelBuilder.Entity("SyllabusManager.Data.Models.Syllabuses.SubjectInSyllabusDescription", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<int>("AssignedSemester")
                        .HasColumnType("integer");

                    b.Property<int?>("CompletionSemester")
                        .HasColumnType("integer");

                    b.Property<Guid?>("SubjectId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("SyllabusId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("SubjectId");

                    b.HasIndex("SyllabusId");

                    b.ToTable("SubjectInSyllabusDescription");
                });

            modelBuilder.Entity("SyllabusManager.Data.Models.Syllabuses.Syllabus", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("AcademicYear")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("ApprovalDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("AuthorName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid?>("DescriptionId")
                        .HasColumnType("uuid");

                    b.Property<string>("FieldOfStudyCode")
                        .HasColumnType("text");

                    b.Property<string>("IntershipType")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<DateTime?>("OpinionDeadline")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("ScopeOfDiplomaExam")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SpecializationCode")
                        .HasColumnType("text");

                    b.Property<int>("State")
                        .HasColumnType("integer");

                    b.Property<int?>("StudentGovernmentOpinion")
                        .HasColumnType("integer");

                    b.Property<string>("StudentRepresentativeName")
                        .HasColumnType("text");

                    b.Property<string>("ThesisCourse")
                        .HasColumnType("text");

                    b.Property<DateTime?>("ValidFrom")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Version")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("DescriptionId");

                    b.HasIndex("FieldOfStudyCode");

                    b.HasIndex("SpecializationCode");

                    b.ToTable("Syllabuses");
                });

            modelBuilder.Entity("SyllabusManager.Data.Models.Syllabuses.SyllabusDescription", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("EmploymentOpportunities")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("FormOfGraduation")
                        .HasColumnType("integer");

                    b.Property<int>("NumOfSemesters")
                        .HasColumnType("integer");

                    b.Property<string>("PossibilityOfContinuation")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Prerequisites")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ProfessionalTitleAfterGraduation")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("SyllabusDescription");
                });

            modelBuilder.Entity("SyllabusManager.Data.Models.User.SyllabusManagerUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("SyllabusManager.Data.Models.User.SyllabusManagerUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("SyllabusManager.Data.Models.User.SyllabusManagerUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SyllabusManager.Data.Models.User.SyllabusManagerUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("SyllabusManager.Data.Models.User.SyllabusManagerUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SyllabusManager.Data.Models.FieldOfStudies.FieldOfStudy", b =>
                {
                    b.HasOne("SyllabusManager.Data.Models.User.SyllabusManagerUser", "Supervisor")
                        .WithMany()
                        .HasForeignKey("SupervisorId");
                });

            modelBuilder.Entity("SyllabusManager.Data.Models.FieldOfStudies.Specialization", b =>
                {
                    b.HasOne("SyllabusManager.Data.Models.FieldOfStudies.FieldOfStudy", null)
                        .WithMany("Specializations")
                        .HasForeignKey("FieldOfStudyCode");
                });

            modelBuilder.Entity("SyllabusManager.Data.Models.LearningOutcomes.LearningOutcome", b =>
                {
                    b.HasOne("SyllabusManager.Data.Models.LearningOutcomes.LearningOutcomeDocument", null)
                        .WithMany("LearningOutcomes")
                        .HasForeignKey("LearningOutcomeDocumentId");

                    b.HasOne("SyllabusManager.Data.Models.FieldOfStudies.Specialization", "Specialization")
                        .WithMany()
                        .HasForeignKey("SpecializationCode");
                });

            modelBuilder.Entity("SyllabusManager.Data.Models.LearningOutcomes.LearningOutcomeDocument", b =>
                {
                    b.HasOne("SyllabusManager.Data.Models.FieldOfStudies.FieldOfStudy", "FieldOfStudy")
                        .WithMany()
                        .HasForeignKey("FieldOfStudyCode");
                });

            modelBuilder.Entity("SyllabusManager.Data.Models.ManyToMany.SubjectTeacher", b =>
                {
                    b.HasOne("SyllabusManager.Data.Models.Subjects.Subject", "Subject")
                        .WithMany("SubjectsTeachers")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SyllabusManager.Data.Models.User.SyllabusManagerUser", "Teacher")
                        .WithMany("SubjectsTeachers")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SyllabusManager.Data.Models.Subjects.CardEntries", b =>
                {
                    b.HasOne("SyllabusManager.Data.Models.Subjects.Subject", null)
                        .WithMany("CardEntries")
                        .HasForeignKey("SubjectId");
                });

            modelBuilder.Entity("SyllabusManager.Data.Models.Subjects.CardEntry", b =>
                {
                    b.HasOne("SyllabusManager.Data.Models.Subjects.CardEntries", null)
                        .WithMany("Entries")
                        .HasForeignKey("CardEntriesId");
                });

            modelBuilder.Entity("SyllabusManager.Data.Models.Subjects.ClassForm", b =>
                {
                    b.HasOne("SyllabusManager.Data.Models.Subjects.Lesson", null)
                        .WithMany("ClassForms")
                        .HasForeignKey("LessonId");
                });

            modelBuilder.Entity("SyllabusManager.Data.Models.Subjects.LearningOutcomeEvaluation", b =>
                {
                    b.HasOne("SyllabusManager.Data.Models.Subjects.Subject", null)
                        .WithMany("LearningOutcomeEvaluations")
                        .HasForeignKey("SubjectId");
                });

            modelBuilder.Entity("SyllabusManager.Data.Models.Subjects.Lesson", b =>
                {
                    b.HasOne("SyllabusManager.Data.Models.Subjects.Subject", null)
                        .WithMany("Lessons")
                        .HasForeignKey("SubjectId");
                });

            modelBuilder.Entity("SyllabusManager.Data.Models.Subjects.Literature", b =>
                {
                    b.HasOne("SyllabusManager.Data.Models.Subjects.Subject", null)
                        .WithMany("Literature")
                        .HasForeignKey("SubjectId");
                });

            modelBuilder.Entity("SyllabusManager.Data.Models.Subjects.Subject", b =>
                {
                    b.HasOne("SyllabusManager.Data.Models.FieldOfStudies.FieldOfStudy", "FieldOfStudy")
                        .WithMany()
                        .HasForeignKey("FieldOfStudyCode");

                    b.HasOne("SyllabusManager.Data.Models.FieldOfStudies.Specialization", "Specialization")
                        .WithMany()
                        .HasForeignKey("SpecializationCode");

                    b.HasOne("SyllabusManager.Data.Models.User.SyllabusManagerUser", "Supervisor")
                        .WithMany()
                        .HasForeignKey("SupervisorId");
                });

            modelBuilder.Entity("SyllabusManager.Data.Models.Syllabuses.PointLimit", b =>
                {
                    b.HasOne("SyllabusManager.Data.Models.Syllabuses.Syllabus", null)
                        .WithMany("PointLimits")
                        .HasForeignKey("SyllabusId");
                });

            modelBuilder.Entity("SyllabusManager.Data.Models.Syllabuses.SubjectInSyllabusDescription", b =>
                {
                    b.HasOne("SyllabusManager.Data.Models.Subjects.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectId");

                    b.HasOne("SyllabusManager.Data.Models.Syllabuses.Syllabus", null)
                        .WithMany("SubjectDescriptions")
                        .HasForeignKey("SyllabusId");
                });

            modelBuilder.Entity("SyllabusManager.Data.Models.Syllabuses.Syllabus", b =>
                {
                    b.HasOne("SyllabusManager.Data.Models.Syllabuses.SyllabusDescription", "Description")
                        .WithMany()
                        .HasForeignKey("DescriptionId");

                    b.HasOne("SyllabusManager.Data.Models.FieldOfStudies.FieldOfStudy", "FieldOfStudy")
                        .WithMany()
                        .HasForeignKey("FieldOfStudyCode");

                    b.HasOne("SyllabusManager.Data.Models.FieldOfStudies.Specialization", "Specialization")
                        .WithMany()
                        .HasForeignKey("SpecializationCode");
                });
#pragma warning restore 612, 618
        }
    }
}
