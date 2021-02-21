using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace InlämningsUppgiftASPnetMVC.Data
{
    public class ApplicationUserClaims : UserClaimsPrincipalFactory<ApplicationUser>
    {
        public ApplicationUserClaims(UserManager<ApplicationUser> userManager, IOptions<IdentityOptions> optionsAccessor) : base(userManager, optionsAccessor)
        {
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUser user)
        {
            var _identity = await base.GenerateClaimsAsync(user);

            var _roles = await UserManager.GetRolesAsync(user);

            _identity.AddClaim(new Claim("FullName", user.FullName ?? ""));
            _identity.AddClaim(new Claim(ClaimTypes.Role, _roles.FirstOrDefault()));
            

            return _identity;
        }
    }
}
