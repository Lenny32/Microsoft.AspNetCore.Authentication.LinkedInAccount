using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Microsoft.AspNetCore.Authentication.LinkedInAccount
{
    /// <summary>
    /// Contains static methods that allow to extract user's information from a <see cref="JObject"/>
    /// instance retrieved from LinkedIn after a successful authentication process.
    /// </summary>
    public static class LinkedInAccountHelper
    {
        /// <summary>
        /// Gets the LinkedIn Account user ID.
        /// </summary>
        public static string GetId(JObject user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            return user.Value<string>("id");
        }

        /// <summary>
        /// Gets the user's name.
        /// </summary>
        public static string GetDisplayName(JObject user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            return user.Value<string>("formattedName");
        }

        /// <summary>
        /// Gets the user's given name.
        /// </summary>
        public static string GetGivenName(JObject user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            return user.Value<string>("lastName");
        }

        /// <summary>
        /// Gets the user's surname.
        /// </summary>
        public static string GetSurname(JObject user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            return user.Value<string>("firstName");
        }

        /// <summary>
        /// Gets the user's email address.
        /// </summary>
        public static string GetEmail(JObject user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            return user.Value<string>("emailAddress");
        }
    }
}
