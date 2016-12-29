using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;

namespace Microsoft.AspNetCore.Authentication.LinkedInAccount
{
    public static class LinkedInFields
    {
        /// <summary>
        /// A unique identifying value for the member.
        /// <para>This value is linked to your specific application.  Any attempts to use it with a different application will result in a "404 - Invalid member id" error.</para>
        /// </summary>
        public const string Id = "id";
        /// <summary>
        /// The member's first name.
        /// </summary>
        public const string FirstName = "first-name";

        /// <summary>
        /// The member's last name.
        /// </summary>
        public const string LastName = "last-name";

        /// <summary>
        /// The member's maiden name.
        /// </summary>
        public const string MaidenName = "maiden-name";

        /// <summary>
        /// The member's name, formatted based on language.
        /// </summary>
        public const string FormattedName = "formatted-name";

        /// <summary>
        /// The member's first name, spelled phonetically.
        /// </summary>
        public const string PhoneticFirstName = "phonetic-first-name";

        /// <summary>
        /// The member's last name, spelled phonetically.
        /// </summary>
        public const string PhoneticLastName = "phonetic-last-name";


        /// <summary>
        /// The member's name, spelled phonetically and formatted based on language.
        /// </summary>
        public const string FormattedPhoneticName = "formatted-phonetic-name";

        /// <summary>
        /// The member's headline.
        /// </summary>
        public const string Headline = "headline";

        /// <summary>
        /// An object representing the user's physical location.
        /// <para>See Location Fields for a description of the fields available within this object.</para>
        /// <para>https://developer.linkedin.com/docs/fields/location</para>
        /// </summary>
        public const string Location = "location";

        /// <summary>
        /// The industry the member belongs to.
        /// <para>See Industry Codes for a list of possible values.</para>
        /// <para>https://developer.linkedin.com/docs/reference/industry-codes</para>
        /// </summary>
        public const string Industry = "industry";

        /// <summary>
        /// The most recent item the member has shared on LinkedIn.  If the member has not shared anything, their 'status' is returned instead.
        /// </summary>
        public const string CurrentShare = "current-share";


        /// <summary>
        /// The number of LinkedIn connections the member has, capped at 500.  See 'num-connections-capped' to determine if the value returned has been capped.
        /// </summary>
        public const string NumConnections = "num-connections";

        /// <summary>
        /// Returns 'true' if the member's 'num-connections' value has been capped at 500', or 'false' if 'num-connections' represents the user's true value.
        /// </summary>
        public const string NumConnectionsCapped = "num-connections-capped";

        /// <summary>
        /// A long-form text area describing the member's professional profile.
        /// </summary>
        public const string Summary = "summary";

        /// <summary>
        /// A short-form text area describing the member's specialties.
        /// </summary>
        public const string Specialties = "specialties";

        /// <summary>
        /// An object representing the member's current position.
        /// <para>See Position Fields for a description of the fields available within this object.</para>
        /// <para>https://developer.linkedin.com/docs/fields/positions</para>
        /// </summary>
        public const string Positions = "positions";

        /// <summary>
        /// A URL to the member's formatted profile picture, if one has been provided.
        /// </summary>
        public const string PictureUrl = "picture-url";

        /// <summary>
        /// A URL to the member's original unformatted profile picture.  This image is usually larger than the picture-url value above.
        /// </summary>
        public const string PictureUrls = "picture-urls::(original)";

        /// <summary>
        /// The URL to the member's authenticated profile on LinkedIn.  You must be logged into LinkedIn to view this URL.
        /// </summary>
        public const string SiteStandardProfileRequest = "site-standard-profile-request";

        /// <summary>
        /// A URL representing the resource you would request for programmatic access to the member's profile.
        /// </summary>
        public const string ApiStandardProfileRequest = "api-standard-profile-request";

        /// <summary>
        /// The URL to the member's public profile on LinkedIn.
        /// </summary>
        public const string PublicProfileUrl = "public-profile-url";

        /// <summary>
        /// The LinkedIn member's primary email address.  Secondary email addresses associated with the member are not available via the API.
        /// <para>The following member fields require the r_emailaddress member permission:</para>
        /// </summary>
        public const string EmailAddress = "email-address";


        /// <summary>
        /// All the fields listed here
        /// </summary>
        public static string All
        {
            get
            {
                return String.Join(",", typeof(LinkedInFields).GetTypeInfo().GetFields(BindingFlags.Public | BindingFlags.Static |
                                   BindingFlags.FlattenHierarchy).Where(fi => fi.IsLiteral && !fi.IsInitOnly).ToList().Select(
                    x=> x.GetValue(null)
                    ));
            }
        }
    }
}
