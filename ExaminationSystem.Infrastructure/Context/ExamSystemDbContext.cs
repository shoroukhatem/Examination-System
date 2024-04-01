using ExaminationSystem.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ExaminationSystem.Infrastructure.Context
{
    public class ExamSystemDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        public ExamSystemDbContext(DbContextOptions<ExamSystemDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Exam>().HasMany(x => x.Questions)
                                  .WithOne()
                                  .HasForeignKey(x => x.ExamId);

           
            builder.Entity<Subject>().HasMany(x => x.Exams)
                                   .WithOne()
                                   .HasForeignKey(x => x.SubjectId);
            builder.Entity<MCQ>()
                .HasMany(x=>x.Answers)
                .WithOne().
                HasForeignKey(x=>x.QuestionId);
            builder.Entity<TOrF>();
            builder.Entity<Question>()
            .HasDiscriminator<string>(x=>x.QuestionType)
            .HasValue<MCQ>("MCQ")
            .HasValue<TOrF>("TOrF");

            builder.Entity<ExamStudent>().HasKey(x => new {x.ExamId,x.StudentId });
            builder.Entity<SubjectStudent>().HasKey(x => new {x.SubjectId,x.StudentId });
            builder.Entity<SubjectTeacher>().HasKey(x => new {x.SubjectId,x.TeacherId});
       

            base.OnModelCreating(builder);
        }
        public DbSet<Exam>Exams { get; set; }
        public DbSet<Question> Questions {  get; set; } 
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<ExamStudent> ExamsStudents { get; set;}
        public DbSet<SubjectStudent> SubjectStudents { get; set;}
        public DbSet<SubjectTeacher> SubjectTeachers{ get; set;}


    }
}
