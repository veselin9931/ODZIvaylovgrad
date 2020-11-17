using Microsoft.AspNetCore.Http;
using ODZ.Data.Common.Repositories;
using ODZ.Models;
using ODZ.Services.Mapping;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ODZ.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IDeletableEntityRepository<Article> repository;
        private readonly IDeletableEntityRepository<Document> repository1;

        public ArticleService(IDeletableEntityRepository<Article> repository, IDeletableEntityRepository<Document> repository1)
        {
            this.repository = repository;
            this.repository1 = repository1;
        }

        public async Task<bool> CreateArticle(string name, string descripton)
        {
            var article = new Article()
            {
                Name = name,
                Description = descripton,
            };

            this.repository.Add(article);

            var result = await this.repository.SaveChangesAsync();

            if (result != 0)
            {
                return true;
            }

            return false;
            
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
