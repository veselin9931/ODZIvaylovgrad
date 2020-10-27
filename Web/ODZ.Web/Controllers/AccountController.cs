namespace ODZ.Web.Controllers
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using ODZ.Data.Models;
    using ODZ.Web.ViewModels;
    using System;
    using System.Threading.Tasks;

    [ApiController]
    [Route("api/[Controller]")]
    public class AccountController : BaseController
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;

        public AccountController( SignInManager<ApplicationUser> signInManager,
                                UserManager<ApplicationUser> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        [HttpPost]
        [Route("Register")]
        //POST : /api/Account/Register
        public async Task<Object> Register(RegisterViewModel model)
        {
            var appUser = new ApplicationUser()
            {
                UserName = model.UserName,
                FullName = model.FullName,
                Email = model.Email
            };

            try
            {
                var result = await this.userManager.CreateAsync(appUser, model.Password);
                return this.Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
