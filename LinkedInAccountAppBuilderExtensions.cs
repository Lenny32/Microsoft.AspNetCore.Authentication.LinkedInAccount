using System;
using Microsoft.AspNetCore.Authentication.LinkedInAccount;
using Microsoft.Extensions.Options;

namespace Microsoft.AspNetCore.Builder
{
    /// <summary>
    /// Extension methods to add LinkedIn Account authentication capabilities to an HTTP application pipeline.
    /// </summary>
    public static class LinkedInAccountAppBuilderExtensions
    {
        /// <summary>
        /// Adds the <see cref="LinkedInAccountMiddleware"/> middleware to the specified <see cref="IApplicationBuilder"/>, which enables LinkedIn Account authentication capabilities.
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder"/> to add the middleware to.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        public static IApplicationBuilder UseLinkedInAccountAuthentication(this IApplicationBuilder app)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }

            return app.UseMiddleware<LinkedInAccountMiddleware>();
        }

        /// <summary>
        /// Adds the <see cref="LinkedInAccountMiddleware"/> middleware to the specified <see cref="IApplicationBuilder"/>, which enables LinkedIn Account authentication capabilities.
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder"/> to add the middleware to.</param>
        /// <param name="options">A <see cref="LinkedInAccountOptions"/> that specifies options for the middleware.</param>
        /// <returns>A reference to this instance after the operation has completed.</returns>
        public static IApplicationBuilder UseLinkedInAccountAuthentication(this IApplicationBuilder app, LinkedInAccountOptions options)
        {
            if (app == null)
            {
                throw new ArgumentNullException(nameof(app));
            }
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            return app.UseMiddleware<LinkedInAccountMiddleware>(Options.Create(options));
        }
    }
}
