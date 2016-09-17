using FluentValidation.Attributes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using webapi.Infrastructure.Constants;
using webapi.Infrastructure.Validators;

namespace webapi.Models
{
    /// <summary>
    /// Represents the student entity model
    /// </summary>
    [Validator(typeof(StudentValidator))]
    [System.ComponentModel.DataAnnotations.Schema.Table("Stud")]
    public class Student
    {

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public virtual int Id { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        public virtual string FirstName { get; set; }
        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        public virtual string LastName { get; set; }
        /// <summary>
        /// Gets or sets the grade.
        /// </summary>
        /// <value>
        /// The grade.
        /// </value>
        public virtual string Grade { get; set; }
        /// <summary>
        /// Gets or sets the date of birth.
        /// </summary>
        /// <value>
        /// The date of birth.
        /// </value>
        public virtual DateTime DateOfBirth { get; set; }
        /// <summary>
        /// Gets or sets the created date.
        /// </summary>
        /// <value>
        /// The created date.
        /// </value>
        public virtual DateTime CreatedDate { get; set; }
        /// <summary>
        /// Gets or sets the updated date.
        /// </summary>
        /// <value>
        /// The updated date.
        /// </value>
        public virtual DateTime UpdatedDate { get; set; }
    }

    /// <summary>
    /// DbContext entity from student model 
    /// </summary>
    /// <seealso cref="System.Data.Entity.DbContext" />
    public class StudentDbContext : DbContext
    {
        public StudentDbContext()
            : base(DbConstants.StudentDbConnectionStringKeyName)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new StudentEntityMap());
            Database.SetInitializer<StudentDbContext>(null);
            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// Gets or sets the students.
        /// </summary>
        /// <value>
        /// The students.
        /// </value>
        public virtual DbSet<Student> Students { get; set; }
    }

    /// <summary>
    /// Student model configuration mapping entity
    /// </summary>
    /// <seealso cref="System.Data.Entity.ModelConfiguration.EntityTypeConfiguration{webapi.Models.Student}" />
    public class StudentEntityMap : EntityTypeConfiguration<Student>
    {
        public StudentEntityMap()
        {
            ToTable(DbConstants.StudentTableName);
            Property(e => e.Grade).HasMaxLength(2);
        }
    }
}