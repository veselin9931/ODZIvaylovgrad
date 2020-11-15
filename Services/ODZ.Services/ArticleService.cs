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

        public async Task<bool> CreateArticle(string name, string descripton, IFormFile file)
        {
            var article = new Article()
            {
                Name = name,
                Description = descripton,
            };


            using (var memoryStream = new MemoryStream())
            {
                file.CopyTo(memoryStream);

                // Upload the file if less than 8 MB
                if (memoryStream.Length <= 8388608)
                {
                    var fileforDb = new Document()
                    {
                        Name = name,
                        Bytes = memoryStream.ToArray(),
                        Size = memoryStream.Length,
                        CreatedOn = DateTime.Now,
                    };

                    repository1.Add(fileforDb);

                    if (await repository.SaveChangesAsync() > 0)
                    {
                        article.Document.Id = fileforDb.Id;
                    }
                }

                this.repository.Add(article);

                var result = await repository.SaveChangesAsync();

                return result > 0;


            }
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
