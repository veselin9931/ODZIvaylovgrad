using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ODZ.Services
{
    public interface IDocumentService
    {
        public int CreateDocument(string title, string url);

        public Task<bool> DeleteDocumentByIdAsync(string id);

        public Task<IEnumerable<TViewModel>> GetAllDocumentAsync<TViewModel>();

        public Task<bool> EditDocumentByIdAsync(string id);
    }
}
