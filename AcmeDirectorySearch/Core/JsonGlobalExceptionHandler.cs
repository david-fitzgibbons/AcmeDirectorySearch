namespace AcmeDirectorySearch.Core
{
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Diagnostics;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Newtonsoft.Json;

    /// <summary>
    /// Global error handling that catches errors and returns an error object
    /// in JSON format for consistent handling with the REST API
    /// 
    /// Code used/modifed from: https://github.com/nbarbettini/BeautifulRestApi/blob/master/src/Infrastructure/JsonExceptionMiddleware.cs
    /// </summary>
    public class JsonGlobalExceptionHandler
    {
        public const string DefaultErrorMessage = "A server error occurred.";

        private readonly IHostingEnvironment env;
        private readonly JsonSerializer serializer;

        public JsonGlobalExceptionHandler(IHostingEnvironment env)
        {
            this.env = env;
            this.serializer = new JsonSerializer();
        }

        public async Task Invoke(HttpContext context)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var ex = context.Features.Get<IExceptionHandlerFeature>()?.Error;
            if (ex == null)
            {
                return;
            }

            ErrorFormat err;

            if (this.env.IsDevelopment())
            {
                err = new ErrorFormat(ex.Message, ex.StackTrace);
            }
            else
            {
                err = new ErrorFormat(DefaultErrorMessage, ex.Message);
            }

            using (var writer = new StreamWriter(context.Response.Body))
            {
                this.serializer.Serialize(writer, err);
                await writer.FlushAsync().ConfigureAwait(false);
            }
        }

        /// <summary>
        /// Error format tries to stay consistent with the ActionResult format 
        /// that handles outputting Validation errors to keep consistency for the
        /// end users
        /// </summary>
        private class ErrorFormat
        {
            public ErrorFormat(string message, string detail)
            {
                this.Errors = new Dictionary<string, IEnumerable<string>>();
                this.Errors.Add(message, new List<string> { detail });
            }

            public Dictionary<string, IEnumerable<string>> Errors { get; private set; }

            public string Title { get; } = "One or more errors occurred while processing the request.";

            public int Status { get; } = (int)HttpStatusCode.InternalServerError;
        }
    }
}
