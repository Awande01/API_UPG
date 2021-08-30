using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace BL.Model
{
    public  class Logging
    {
        public RequestDelegate requestDelegate;
        public Logging(RequestDelegate requestDelegate)
        {
            this.requestDelegate = requestDelegate;
        }
        public async Task Invoke(HttpContext context, ILogger<Logging> logger)
        {
            try
            {
                await requestDelegate(context);
            }
            catch (Exception ex)
            {
                await HandleException(context, ex,logger);
            }
        }
        private static Task HandleException(HttpContext context, Exception ex, ILogger<Logging> logger)
        {
            logger.LogError(ex.ToString());
            var errorMessage = JsonConvert.SerializeObject(new { Message = ex.Message, Code = "GE" });

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            return context.Response.WriteAsync(errorMessage);
        }
    }
}

