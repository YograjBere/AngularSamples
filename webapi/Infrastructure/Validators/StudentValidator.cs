using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webapi.Infrastructure.Constants;
using webapi.Models;

namespace webapi.Infrastructure.Validators
{
    /// <summary>
    /// Validator class for Student Model.
    /// </summary>
    /// <seealso cref="FluentValidation.AbstractValidator{webapi.Models.Student}" />
    public class StudentValidator : AbstractValidator<Student>
    {
        public StudentValidator()
        {
            RuleFor(e => e.Id).GreaterThanOrEqualTo(0).WithMessage(ErrorMessages.InvalidStudentIdError);
            RuleFor(e => e.FirstName).NotEmpty().WithMessage(ErrorMessages.StudentFirstNameRequiredError);
            RuleFor(e => e.LastName).NotEmpty().WithMessage(ErrorMessages.StudentLastNameRequiredError);
            RuleFor(e => e.Grade).NotEmpty().WithMessage(ErrorMessages.StudentGradeRequiredError);
            RuleFor(e => e.Grade).Length(2).WithMessage(ErrorMessages.StudentGradeLenghtError);
            RuleFor(e => e.DateOfBirth).NotEmpty().WithMessage(ErrorMessages.StudentDateOfBirthRequiredErrror);
        }
    }
}