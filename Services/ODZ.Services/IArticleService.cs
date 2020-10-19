namespace ODZ.Services
{

    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IArticleService
    {
        public int CreateArticle(string name, string descripton, string imgUrl);

        public Task<bool> DeleteArticleByIdAsync(string id);

        public Task<IEnumerable<TViewModel>> GetAllArticleAsync<TViewModel>();

        public Task<TViewModel> GetLastArticleAsync<TViewModel>();

        public Task<bool> EditArticleByIdAsync(string id);

    }
}
