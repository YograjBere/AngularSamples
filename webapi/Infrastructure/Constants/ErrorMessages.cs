using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webapi.Infrastructure.Constants
{
    /// <summary>
    /// Collection of validation error message constants
    /// </summary>
    public static class ErrorMessages
    {
        /// <summary>
        /// The invalid student identifier error
        /// </summary>
        public const string InvalidStudentIdError = "Invalid Id field provided.";

        /// <summary>
        /// The student first name required error
        /// </summary>
        public const string StudentFirstNameRequiredError = "First name is required.";

        /// <summary>
        /// The student last name required error
        /// </summary>
        public const string StudentLastNameRequiredError = "Last name is required.";

        /// <summary>
        /// The student grade required error
        /// </summary>
        public const string StudentGradeRequiredError = "Grade is required.";

        /// <summary>
        /// The student grade lenght error
        /// </summary>
        public static string StudentGradeLenghtError = string.Format("Grade field should contain {0} characters only.", DbConstants.StudentGradeColLength);

        /// <summary>
        /// The student date of birth required errro
        /// </summary>
        public const string StudentDateOfBirthRequiredErrror = "Date of birth is required field.";

        /// <summary>
        /// The generic error message
        /// </summary>
        public const string GenericErrorMessage = "Internal error occurred.";

    }
}