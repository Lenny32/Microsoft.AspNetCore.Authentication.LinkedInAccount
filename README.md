# Microsoft.AspNetCore.Authentication.LinkedInAccount
Add external authentication middleware
I copied the code of the Microsoft package and I adapted it for LinkedIn

```csharp
app.UseLinkedInAccountAuthentication(new LinkedInAccountOptions(LinkedInFields.All)
    {
        AuthenticationScheme = "LinkedIn",
        CallbackPath = new PathString("/signin-linkedin"),
        ClientId = Configuration["Authentication:LinkedIn:ClientId"],
        ClientSecret = Configuration["Authentication:LinkedIn:ClientSecret"],
        Scope = { LinkedInScopes.BasicProfile, LinkedInScopes.EmailAddress }
    });
```
*(Feel free to update/change the package to make it better)*
