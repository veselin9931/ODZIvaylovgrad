using ODZ.Data.Common.Repositories;
using ODZ.Models;
using ODZ.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ODZ.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IDeletableEntityRepository<Article> repository;

        public ArticleService(IDeletableEntityRepository<Article> repository)
        {
            this.repository = repository;
        }

        public async Task<bool> CreateArticle(string name, string descripton, string imgUrl, byte[] imgContent, string imgName)
        {
            var article = new Article()
            {
                Name = name,
                Description = descripton,
                Document = new Document()
                {
                    Name = imgName,
                    Bytes = imgContent,
                    Size = imgContent.Length,
                }
            };

            this.repository.Add(article);

            var result = await repository.SaveChangesAsync();

            return result > 0;


        }

        public async Task<bool> DeleteArticleByIdAsync(int id)
        {
           var deleateble = this.repository.All().FirstOrDefault(a => a.Id == id);

            deleateble.IsDeleted = true;

            this.repository.Update(deleateble);

            var result = await this.repository.SaveChangesAsync();

            return result >0;
        }


        public IEnumerable<TViewModel> GetAllArticleAsync<TViewModel>()
        {
            return this.repository.All().To<TViewModel>().ToList();
        }
    }
}
