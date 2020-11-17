namespace ODZ.Services
{
    using Microsoft.AspNetCore.Http;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IArticleService
    {
        public Task<bool> CreateArticle(string name, string descripton);

        public Task<bool> DeleteArticleByIdAsync(int id);

        public IEnumerable<TViewModel> GetAllArticleAsync<TViewModel>();

    }
}
