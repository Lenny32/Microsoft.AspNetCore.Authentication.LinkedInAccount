using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.AspNetCore.Authentication.LinkedInAccount
{
    public class LinkedInAccountOptions : OAuthOptions
    {
        /// <summary>
        /// Initializes a new <see cref="LinkedInAccountOptions"/>.
        /// </summary>
        public LinkedInAccountOptions(string fields)
        {
            AuthenticationScheme = LinkedInAccountDefaults.AuthenticationScheme;
            DisplayName = AuthenticationScheme;
            CallbackPath = new PathString("/signin-linkedin");
            AuthorizationEndpoint = LinkedInAccountDefaults.AuthorizationEndpoint;
            TokenEndpoint = LinkedInAccountDefaults.TokenEndpoint;
            
            UserInformationEndpoint = LinkedInAccountDefaults.UserInformationEndpoint + (fields == null ? "?format=json" : $":({fields})");
        }


        /// <summary>
        /// Initializes a new <see cref="LinkedInAccountOptions"/>.
        /// </summary>
        public LinkedInAccountOptions(IEnumerable<string> fields) : this(fields == null ? null : String.Join(",", fields))
        {
        }

        /// <summary>
        /// Initializes a new <see cref="LinkedInAccountOptions"/>.
        /// </summary>
        public LinkedInAccountOptions() : this("?format=json")
        {
        }

    }
}
