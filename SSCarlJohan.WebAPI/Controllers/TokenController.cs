﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SSCarlJohan.WebAPI.Data;
using System.Threading.Tasks;

namespace SSCarlJohan.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        //private readonly ApplicationDbContext context;
        //private readonly UserManager<IdentityUser> userManager;

        //public TokenController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        //{
        //    this.context = context;
        //    this.userManager = userManager;
        //}

        //[Route("/token")]
        //[HttpPost]
        //public async Task<IActionResult> Create(string username, string password, string grant_type)
        //{
        //    if(await IsValidUsernameAndPassword(username, password))
        //    {

        //    }
        //    else
        //    {
        //        return BadRequest();
        //    }
        //}

        //private async Task<bool> IsValidUsernameAndPassword(string username, string password)
        //{
        //    var user = await userManager.FindByEmailAsync(username);

        //    return await userManager.CheckPasswordAsync(user, password);
        //}

        //private async Task<dynamic> GenerateToken(string username)
        //{
        //    //var user = await userManager.FindByEmailAsync(username);

        //    //var roles = from ur in context.UserRoles
        //    //            join r in context.Roles on ur.RoleId equals r.Id
        //    //            where ur.UserId == user.Id
        //    //            select new { ur.UserId, ur.RoleId, r.Name };
        //}
    }
}