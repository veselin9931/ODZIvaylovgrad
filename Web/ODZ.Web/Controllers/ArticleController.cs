using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ODZ.Services;
using ODZ.Web.ViewModels;

namespace ODZ.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleService articleService;

        public ArticleController(IArticleService articleService)
        {
            this.articleService = articleService;
        }


        // GET: api/<ArticleController>
        [HttpGet]
        public async Task<IEnumerable<ArticleViewModel>> Get()
        {
            return articleService.GetAllArticleAsync<ArticleViewModel>();
        }


        // POST api/<ArticleController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] string name, string description)
        {
            IFormFile file = Request.Form.Files[0];

            if (file == null || file.Length > 8388608)
            {
                return this.UnprocessableEntity(new { err = "Качения файл трябва да бъде не по-голям от 8МБ. Ако искате да качите по-голям файл свържете се с вашия администратор." });
            }

            var result = await this.articleService.CreateArticle(name, description, file);

            if (result)
            {
                // TODO: Add mesage
                return this.Ok();
            }

            return this.BadRequest();
        }

        // DELETE api/<ArticleController>/5
        [HttpDelete("{id}")]
        public async void Delete(int id)
        {
          await  this.articleService.DeleteArticleByIdAsync(id);
        }
    }
}
