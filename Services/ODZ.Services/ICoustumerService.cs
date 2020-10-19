using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ODZ.Services
{
    public interface ICoustumerService
    {
        public int CreateCostumer(string name, string descripton, string imgUrl);

        public Task<bool> DeleteCostumerByIdAsync(string id);

        public Task<IEnumerable<TViewModel>> GetAllCostumersAsync<TViewModel>();

        public Task<bool> EditCostumerByIdAsync(string id);
    }
}
