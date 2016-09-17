using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.ExceptionHandling;
using webapi.Infrastructure.Constants;
using webapi.Infrastructure.Logger;

namespace webapi.Infrastructure.ErrorHandler
{
    /// <summary>
    /// Global exception handler in owin pipeline
    /// </summary>
    /// <seealso cref="System.Web.Http.ExceptionHandling.ExceptionHandler" />
    public class GlobalExceptionHandler : ExceptionHandler
    {
        private ILogger _logger;

        public GlobalExceptionHandler(ILogger logger)
        {
            _logger = logger;
        }

        public override void Handle(ExceptionHandlerContext context)
        {
            base.Handle(context);
            _logger.Error(ErrorMessages.GenericErrorMessage, context.Exception);
        }

        public override bool ShouldHandle(ExceptionHandlerContext context)
        {
            return base.ShouldHandle(context);
        }
    }
}