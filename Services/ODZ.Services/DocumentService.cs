using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ODZ.Services
{
    public class DocumentService : IDocumentService
    {
        public int CreateDocument(string title, string url)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteDocumentByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EditDocumentByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TViewModel>> GetAllDocumentAsync<TViewModel>()
        {
            throw new NotImplementedException();
        }
    }
}
