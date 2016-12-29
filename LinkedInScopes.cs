using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.AspNetCore.Authentication.LinkedInAccount
{
    public class LinkedInScopes
    {
        /// <summary>
        /// To access any of the following basic profile fields, your app must request the r_basicprofile member permission. 
        /// <para>more information at : https://developer.linkedin.com/docs/fields/basic-profile </para>
        /// </summary>
        public const string BasicProfile = "r_basicprofile";

        /// <summary>
        /// To access any of the following full profile fields
        /// <para>more information at : https://developer.linkedin.com/docs/fields/full-profile </para>
        /// <para>you also need to apply to the LinkedIn Partner Program https://developer.linkedin.com/partner-programs/apply </para>
        /// </summary>
        public const string FullProfile = "r_fullprofile";
        /// <summary>
        /// The LinkedIn member's primary email address.  Secondary email addresses associated with the member are not available via the API.
        /// </summary>
        public const string EmailAddress = "r_emailaddress";

        //public const string CompanyAdmin = "rw_company_admin";
        //public const string Share = "w_share";

        
    }
}
