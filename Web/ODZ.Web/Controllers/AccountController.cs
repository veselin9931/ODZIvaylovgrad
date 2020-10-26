namespace ODZ.Web.Controllers
{
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using Microsoft.IdentityModel.Tokens;
    using ODZ.Data.Models;
    using ODZ.Web.Infrastructure.Extensions;
    using ODZ.Web.ViewModels;

    public class AccountController : BaseController
    {
        private readonly ILogger<AccountController> logger;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IConfiguration configuration;

        public AccountController(ILogger<AccountController> logger,
                                SignInManager<ApplicationUser> signInManager,
                                UserManager<ApplicationUser> userManager,
                                IConfiguration configuration)
        {
            this.logger = logger;
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.configuration = configuration;
        }

        public async Task<IActionResult> Register([FromBody]UserCredsViewModel model)
        {
            if (model == null || !this.ModelState.IsValid)
            {
                return this.BadRequest("Failed to register");
            }

            var user = new ApplicationUser { Email = model.Email, UserName = model.Email };
            var result = await this.userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                return this.Ok();
            }

            return this.BadRequest("Something in Account controller went wrong");
        }
    }
}
