using Microsoft.AspNetCore.Http;
using ODZ.Data.Common.Repositories;
using ODZ.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ODZ.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly IDeletableEntityRepository<Document> repository;

        public DocumentService(IDeletableEntityRepository<Document> repository)
        {
            this.repository = repository;
        }

        public async Task<bool> CreateDocument(string name, IFormFile file)
        {
            int result = -1;

            using (var memoryStream = new MemoryStream())
            {
                file.CopyTo(memoryStream);

                // Upload the file if less than 2 MB
                if (memoryStream.Length < 2097152)
                {
                    var fileforDb = new Document()
                    {
                        Name = name,
                        Bytes = memoryStream.ToArray(),
                        Size = memoryStream.Length,

                    };

                    repository.Add(fileforDb);

                    result = await repository.SaveChangesAsync();
                }

                return result > 0 ? true : false;
            }




        }

        public Task<bool> DeleteDocumentByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TViewModel>> GetAllDocumentAsync<TViewModel>()
        {
            throw new NotImplementedException();
        }
    }
}