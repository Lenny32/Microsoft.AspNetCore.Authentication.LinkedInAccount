using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.AspNetCore.Authentication.LinkedInAccount
{
    public static class LinkedInAccountDefaults
    {
        public const string AuthenticationScheme = "LinkedIn";

        public static readonly string AuthorizationEndpoint = "https://www.linkedin.com/oauth/v2/authorization";

        public static readonly string TokenEndpoint = "https://www.linkedin.com/oauth/v2/accessToken";

        //public static readonly string UserInformationEndpoint = "https://api.linkedin.com/v1/people/~:(id,first-name,last-name,email-address,headline,picture-url,industry,summary,num-connections,siteStandardProfileRequest,specialties,positions:(id,title,summary,start-date,end-date,is-current,company:(id,name,type,size,industry,ticker)),educations:(id,school-name,field-of-study,start-date,end-date,degree,activities,notes),associations,interests,num-recommenders,date-of-birth,publications:(id,title,publisher:(name),authors:(id,name),date,url,summary),patents:(id,title,summary,number,status:(id,name),office:(name),inventors:(id,name),date,url),languages:(id,language:(name),proficiency:(level,name)),skills:(id,skill:(name)),certifications:(id,name,authority:(name),number,start-date,end-date),courses:(id,name,number),recommendations-received:(id,recommendation-type,recommendation-text,recommender),honors-awards,three-current-positions,three-past-positions,volunteer)";
        public static readonly string UserInformationEndpoint = "https://api.linkedin.com/v1/people/~";
    }
}
