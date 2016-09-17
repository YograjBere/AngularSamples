using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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

    /// <summary>
    /// Wrapper for log4net library
    /// </summary>
    /// <seealso cref="webapi.Infrastructure.Logger.ILogger" />
    public class Logger : ILogger
    {
        private readonly log4net.ILog _logger;

        public Logger(Type type)
        {
            log4net.Config.XmlConfigurator.Configure();
            _logger = log4net.LogManager.GetLogger(type);
        }

        /// <summary>
        /// Debugs the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="obj">The object.</param>
        public void Debug(object message, Exception obj = null)
        {
            _logger.Debug(message, obj);
        }

        /// <summary>
        /// Errors the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="obj">The object.</param>
        public void Error(object message, Exception obj = null)
        {
            _logger.Error(message, obj);
        }

        /// <summary>
        /// Fatals the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="obj">The object.</param>
        public void Fatal(object message, Exception obj = null)
        {
            _logger.Fatal(message, obj);
        }

        /// <summary>
        /// Warns the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="obj">The object.</param>
        public void Warn(object message, Exception obj = null)
        {
            _logger.Warn(message, obj);
        }
    }

    /// <summary>
    /// LogManager for Logger class
    /// </summary>
    public static class LogManager
    {
        public static ILogger GetLogger()
        {
            return new Logger(typeof(Logger));
        }
    }
}