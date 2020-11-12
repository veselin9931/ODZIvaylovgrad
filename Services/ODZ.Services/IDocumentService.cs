using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ODZ.Services
{
    public interface IDocumentService
    {
        public Task<bool> CreateDocument(string name, IFormFile file);

        public Task<bool> DeleteDocumentByIdAsync(string id);

        public Task<IEnumerable<TViewModel>> GetAllDocumentAsync<TViewModel>();
    }
}
