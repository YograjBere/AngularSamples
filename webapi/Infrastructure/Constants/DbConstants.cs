using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webapi.Infrastructure.Constants
{
    public static class DbConstants
    {
        /// <summary>
        /// The student table name
        /// </summary>
        public const string StudentTableName = "Stud";

        /// <summary>
        /// The student database connection string key name
        /// </summary>
        public const string StudentDbConnectionStringKeyName = "DefaultConnection";

        /// <summary>
        /// The student grade col length
        /// </summary>
        public const int StudentGradeColLength = 2;
    }
}