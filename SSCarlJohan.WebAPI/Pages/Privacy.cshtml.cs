using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSCarlJohan.WebAPI.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<IdentityUser> userManager;

        public PrivacyModel(ILogger<PrivacyModel> logger, 
            RoleManager<IdentityRole> roleManager,
            UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        public async Task OnGet()
        {
            string[] roles = new string[] { "Manager", "Cashier", "Admin" };

            foreach (var role in roles)
            {
                var roleExist = await roleManager.RoleExistsAsync(role);

                if(roleExist is false) 
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            var user = await userManager.FindByEmailAsync("erikholm97@gmail.com");

            if(user != null)
            {
                await userManager.AddToRoleAsync(user, "Admin");
                await userManager.AddToRoleAsync(user, "Cashier");
                await userManager.AddToRoleAsync(user, "Manager");
            }
        }
    }
}
