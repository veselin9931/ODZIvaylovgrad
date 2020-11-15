using Microsoft.AspNetCore.Http;
using ODZ.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ODZ.Services
{
    public interface IDocumentService
    {
        public Task<bool> CreateDocument(string name, IFormFile file);

        public Task<bool> DeleteAllDocuments();

        public Task<bool> DeleteDocumentByIdAsync(int id);

        public Task<IEnumerable<TViewModel>> GetAllDocumentAsync<TViewModel>();

        public Task<TViewModel> GetDocumentByIdAsync<TViewModel>(int id);
    } 
}
