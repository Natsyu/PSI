﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SyllabusManager.Data.ProviderContexts;

namespace SyllabusManager.Data.Migrations.SqlServer
{
    [DbContext(typeof(SqlServerSyllabusManagerDbContext))]
    [Migration("20210110162803_SyllabusPointLimit3")]
    partial class SyllabusPointLimit3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("SyllabusManager.Data.Models.FieldOfStudies.FieldOfStudy", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BranchOfScience")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discipline")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Faculty")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("Language")
                        .HasColumnType("int");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Profile")
                        .HasColumnType("int");

                    b.Property<string>("SupervisorId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Code");

                    b.HasIndex("SupervisorId");

                    b.ToTable("FieldsOfStudies");
                });

            modelBuilder.Entity("SyllabusManager.Data.Models.FieldOfStudies.Specialization", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FieldOfStudyCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Code");

                    b.HasIndex("FieldOfStudyCode");

                    b.ToTable("Specializations");
                });

            modelBuilder.Entity("SyllabusManager.Data.Models.LearningOutcomes.LearningOutcome", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Category")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("LearningOutcomeDocumentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("S2degreePrk")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("S2degreePrkeng")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpecializationCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("U1degreeCharacteristics")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LearningOutcomeDocumentId");

                    b.HasIndex("SpecializationCode");

                    b.ToTable("LearningOutcome");
                });

            modelBuilder.Entity("SyllabusManager.Data.Models.LearningOutcomes.LearningOutcomeDocument", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AcademicYear")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FieldOfStudyCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Version")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FieldOfStudyCode");

                    b.ToTable("LearningOutcomeDocuments");
                });

            modelBuilder.Entity("SyllabusManager.Data.Models.ManyToMany.SubjectTeacher", b =>
                {
                    b.Property<Guid>("SubjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TeacherId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("SubjectId", "TeacherId");

                    b.HasIndex("TeacherId");

                    b.ToTable("SubjectTeacher");
                });

            modelBuilder.Entity("SyllabusManager.Data.Models.Subjects.CardEntries", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("SubjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SubjectId");

                    b.ToTable("CardEntries");
                });

            modelBuilder.Entity("SyllabusManager.Data.Models.Subjects.CardEntry", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CardEntriesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CardEntriesId");

                    b.ToTable("CardEntry");
                });

            modelBuilder.Entity("SyllabusManager.Data.Models.Subjects.ClassForm", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Hours")
                        .HasColumnType("int");

                    b.Property<Guid?>("LessonId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("LessonId");

                    b.ToTable("ClassForm");
                });

            modelBuilder.Entity("SyllabusManager.Data.Models.Subjects.LearningOutcomeEvaluation", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GradingSystem")
                        .HasColumnType("int");

                    b.Property<string>("LearningOutcomeSymbol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("SubjectId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("SubjectId");

                    b.ToTable("LearningOutcomeEvaluation");
                });

            modelBuilder.Entity("SyllabusManager.Data.Models.Subjects.Lesson", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Ects")
                        .HasColumnType("int");

                    b.Property<int>("EctsinclDirectTeacherStudentContactClasses")
                        .HasColumnType("int");

                    b.Property<int>("EctsinclPracticalClasses")
                        .HasColumnType("int");

                    b.Property<int>("FormOfCrediting")
                        .HasColumnType("int");

                    b.Property<int>("HoursAtUniversity")
                        .HasColumnType("int");

                    b.Property<bool>("IsFinal")
                        .HasColumnType("bit");

                    b.Property<bool>("IsGroup")
                        .HasColumnType("bit");

                    b.Property<bool>("IsScientific")
                        .HasColumnType("bit");

                    b.Property<int>("LessonType")
                        .HasColumnType("int");

                    b.Property<int>("StudentWorkloadHours")
                        .HasColumnType("int");

                    b.Property<Guid?>("SubjectId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("SubjectId");

                    b.ToTable("Lesson");
                });

            modelBuilder.Entity("SyllabusManager.Data.Models.Subjects.Literature", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Authors")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Distributor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsPrimary")
                        .HasColumnType("bit");

                    b.Property<string>("Isbn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("SubjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SubjectId");

                    b.ToTable("Literature");
                });

            modelBuilder.Entity("SyllabusManager.Data.Models.Subjects.Subject", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AcademicYear")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FieldOfStudyCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("KindOfSubject")
                        .HasColumnType("int");

                    b.Property<int>("Language")
                        .HasColumnType("int");

                    b.Property<int>("ModuleType")
                        .HasColumnType("int");

                    b.Property<string>("NameEng")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NamePl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpecializationCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SupervisorId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("TypeOfSubject")
                        .HasColumnType("int");

                    b.Property<string>("Version")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FieldOfStudyCode");

                    b.HasIndex("SpecializationCode");

                    b.HasIndex("SupervisorId");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("SyllabusManager.Data.Models.Syllabuses.PointLimit", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("KindOfSubject")
                        .HasColumnType("int");

                    b.Property<int>("ModuleType")
                        .HasColumnType("int");

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.Property<Guid?>("SyllabusId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("TypeOfSubject")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SyllabusId");

                    b.ToTable("PointLimit");
                });

            modelBuilder.Entity("SyllabusManager.Data.Models.Syllabuses.SubjectInSyllabusDescription", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AssignedSemester")
                        .HasColumnType("int");

                    b.Property<int?>("CompletionSemester")
                        .HasColumnType("int");

                    b.Property<Guid?>("SubjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("SyllabusId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("SubjectId");

                    b.HasIndex("SyllabusId");

                    b.ToTable("SubjectInSyllabusDescription");
                });

            modelBuilder.Entity("SyllabusManager.Data.Models.Syllabuses.Syllabus", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AcademicYear")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ApprovalDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("AuthorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("DescriptionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FieldOfStudyCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IntershipType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("OpinionDeadline")
                        .HasColumnType("datetime2");

                    b.Property<string>("ScopeOfDiplomaExam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpecializationCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<int?>("StudentGovernmentOpinion")
                        .HasColumnType("int");

                    b.Property<string>("StudentRepresentativeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ThesisCourse")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ValidFrom")
                        .HasColumnType("datetime2");

                    b.Property<string>("Version")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DescriptionId");

                    b.HasIndex("FieldOfStudyCode");

                    b.HasIndex("SpecializationCode");

                    b.ToTable("Syllabuses");
                });

            modelBuilder.Entity("SyllabusManager.Data.Models.Syllabuses.SyllabusDescription", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("EmploymentOpportunities")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FormOfGraduation")
                        .HasColumnType("int");

                    b.Property<int>("NumOfSemesters")
                        .HasColumnType("int");

                    b.Property<string>("PossibilityOfContinuation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prerequisites")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProfessionalTitleAfterGraduation")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("SyllabusDescription");
                });

            modelBuilder.Entity("SyllabusManager.Data.Models.User.SyllabusManagerUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

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
