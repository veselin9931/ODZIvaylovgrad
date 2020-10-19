using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ODZ.Services
{
    public class CostumerService : ICoustumerService
    {
        public int CreateCostumer(string name, string descripton, string imgUrl)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCostumerByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EditCostumerByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TViewModel>> GetAllCostumersAsync<TViewModel>()
        {
            throw new NotImplementedException();
        }
    }
}
