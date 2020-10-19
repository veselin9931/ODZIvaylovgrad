using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ODZ.Services
{
    public class ArticleService : IArticleService
    {
        public int CreateArticle(string name, string descripton, string imgUrl)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteArticleByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EditArticleByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TViewModel>> GetAllArticleAsync<TViewModel>()
        {
            throw new NotImplementedException();
        }

        public Task<TViewModel> GetLastArticleAsync<TViewModel>()
        {
            throw new NotImplementedException();
        }
    }
}
