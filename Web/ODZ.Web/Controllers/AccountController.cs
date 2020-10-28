using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ODZ.Data;
using ODZ.Web.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ODZ.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly SignInManager<StoreUser> signInManager;
        private readonly UserManager<StoreUser> userManager;
        private readonly IConfiguration configuration;

        public AccountController(SignInManager<StoreUser> signInManager,
                                 UserManager<StoreUser> userManager,
                                 IConfiguration configuration)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.configuration = configuration;
        }
        // GET: api/<AccountController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AccountController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AccountController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]RegisterViewModel model)
        {
            if (model == null || !this.ModelState.IsValid)
            {
                return this.BadRequest("Failed to register");
            }

            var user = new StoreUser()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.Email,
            };

            var result = await this.userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                return this.Ok();
            }

            return this.BadRequest("Failed to register");
        }

        // PUT api/<AccountController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AccountController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}



//public class AccountController : BaseController
//{
//    private readonly SignInManager<StoreUser> signInManager;
//    private readonly UserManager<StoreUser> userManager;
//    private readonly IConfiguration configuration;

//    public AccountController(SignInManager<StoreUser> signInManager,
//                            UserManager<StoreUser> userManager,
//                            IConfiguration configuration)
//    {
//        this.signInManager = signInManager;
//        this.userManager = userManager;
//        this.configuration = configuration;
//    }

//    [HttpGet]
//    public async Task<string> Values()
//    {
//        return "value1";
//    }

//    [HttpPost]
//    [Route("Register")]
//    // POST : /api/Account/Register
//    public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
//    {
//        if (model == null || !this.ModelState.IsValid)
//        {
//            return this.BadRequest("Failed to register");
//        }

//        var user = new StoreUser()
//        {
//            FirstName = model.FirstName,
//            LastName = model.LastName,
//            Email = model.Email,
//            UserName = model.Email,
//        };

//        var result = await this.userManager.CreateAsync(user, model.Password);

//        if (result.Succeeded)
//        {
//            return this.Ok();
//        }

//        return this.BadRequest("Failed to register");

//    }

//    [HttpPost]
//    public async Task<IActionResult> CreateToken([FromBody] LoginViewModel model)
//    {
//        if (this.ModelState.IsValid)
//        {
//            var user = await userManager.FindByNameAsync(model.Username);

//            if (user != null)
//            {
//                var result = await this.signInManager.CheckPasswordSignInAsync(user, model.Password, false);

//                if (result.Succeeded)
//                {
//                    //Create token
//                    var claims = new[]
//                    {
//                            new Claim(JwtRegisteredClaimNames.Sub, user.Email),
//                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
//                            new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
//                        };

//                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.configuration["Tokens:Key"]));
//                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

//                    var token = new JwtSecurityToken(
//                        this.configuration["Tokens:Issuer"],
//                        this.configuration["Tokens:Audience"],
//                        claims,
//                        expires: DateTime.UtcNow.AddMinutes(30),
//                        signingCredentials: creds
//                        );

//                    var results = new
//                    {
//                        token = new JwtSecurityTokenHandler().WriteToken(token),
//                        expiration = token.ValidTo,
//                    };

//                    return this.Created(" ", results);
//                }

//            }

//        }

//        return this.BadRequest();
//    }
//}