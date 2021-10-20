using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PresentationUI.Helpers
{
    public class ApplicationUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<Writer, IdentityRole>
    {
        public ApplicationUserClaimsPrincipalFactory(UserManager<Writer> userManager,
           RoleManager<IdentityRole> roleManager, IOptions<IdentityOptions> options)
            : base(userManager, roleManager, options)
        {
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(Writer user)
        {
            var identity = await base.GenerateClaimsAsync(user);
            identity.AddClaim(new Claim("WriterName", user.WriterName ?? ""));
            return identity;
        }

    }
}
