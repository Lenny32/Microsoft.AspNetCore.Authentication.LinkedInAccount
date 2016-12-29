using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Http.Authentication;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Microsoft.AspNetCore.Authentication.LinkedInAccount
{
    internal class LinkedInAccountHandler : OAuthHandler<LinkedInAccountOptions>
    {
        public LinkedInAccountHandler(HttpClient httpClient)
            : base(httpClient)
        {
        }

        protected override async Task<AuthenticationTicket> CreateTicketAsync(ClaimsIdentity identity, AuthenticationProperties properties, OAuthTokenResponse tokens)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, Options.UserInformationEndpoint);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", tokens.AccessToken);
            request.Headers.Add("x-li-format", "json"); // Tell LinkedIn we want the result in JSON, otherwise it will return XML

            var response = await Backchannel.SendAsync(request, Context.RequestAborted);
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Failed to retrived LinkedIn user information ({response.StatusCode}) Please check if the authentication information is correct and the corresponding Microsoft Account API is enabled.");
            }
            var json = await response.Content.ReadAsStringAsync();
            var payload = JObject.Parse(json);

            var ticket = new AuthenticationTicket(new ClaimsPrincipal(identity), properties, Options.AuthenticationScheme);
            var context = new OAuthCreatingTicketContext(ticket, Context, Options, Backchannel, tokens, payload);
            var identifier = LinkedInAccountHelper.GetId(payload);
            if (!string.IsNullOrEmpty(identifier))
            {
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, identifier, ClaimValueTypes.String, Options.ClaimsIssuer));
                //identity.AddClaim(new Claim("urn:linkedinaccount:id", identifier, ClaimValueTypes.String, Options.ClaimsIssuer));
            }

            var name = LinkedInAccountHelper.GetDisplayName(payload);
            if (!string.IsNullOrEmpty(name))
            {
                identity.AddClaim(new Claim(ClaimTypes.Name, name, ClaimValueTypes.String, Options.ClaimsIssuer));
                //identity.AddClaim(new Claim("urn:linkedinaccount:name", name, ClaimValueTypes.String, Options.ClaimsIssuer));
            }

            var givenName = LinkedInAccountHelper.GetGivenName(payload);
            if (!string.IsNullOrEmpty(givenName))
            {
                identity.AddClaim(new Claim(ClaimTypes.GivenName, givenName, ClaimValueTypes.String, Options.ClaimsIssuer));
                //identity.AddClaim(new Claim("urn:linkedinaccount:givenname", givenName, ClaimValueTypes.String, Options.ClaimsIssuer));
            }

            var surname = LinkedInAccountHelper.GetSurname(payload);
            if (!string.IsNullOrEmpty(surname))
            {
                identity.AddClaim(new Claim(ClaimTypes.Surname, surname, ClaimValueTypes.String, Options.ClaimsIssuer));
                //identity.AddClaim(new Claim("urn:linkedinaccount:surname", surname, ClaimValueTypes.String, Options.ClaimsIssuer));
            }

            var email = LinkedInAccountHelper.GetEmail(payload);
            if (!string.IsNullOrEmpty(email))
            {
                identity.AddClaim(new Claim(ClaimTypes.Email, email, ClaimValueTypes.String, Options.ClaimsIssuer));
            }

            await Options.Events.CreatingTicket(context);
            return context.Ticket;
        }
    }
}
