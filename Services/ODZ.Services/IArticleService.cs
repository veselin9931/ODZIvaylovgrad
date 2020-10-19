using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ODZ.Services
{
    public interface IArticleService
    {
        public int CreateArticle(string name, string descripton, string imgUrl);

        public Task<bool> DeleteArticleByIdAsync(string id);

        public Task<IEnumerable<TViewModel>> GetAllArticle<TViewModel>();

        public Task<TViewModel> GetLastArticle<TViewModel>();

    }
}
