using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webapi.Infrastructure.Logger
{
    /// <summary>
    /// Logger interface for log4Net library.
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Debugs the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="obj">The object.</param>
        void Debug(object message, Exception obj = null);

        /// <summary>
        /// Errors the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="obj">The object.</param>
        void Error(object message, Exception obj = null);

        /// <summary>
        /// Warns the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="obj">The object.</param>
        void Warn(object message, Exception obj = null);

        /// <summary>
        /// Fatals the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="obj">The object.</param>
        void Fatal(object message, Exception obj = null);
    }
}
