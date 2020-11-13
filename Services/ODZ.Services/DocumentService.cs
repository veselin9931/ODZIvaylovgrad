﻿using Microsoft.AspNetCore.Http;
using ODZ.Data.Common.Repositories;
using ODZ.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ODZ.Services.Mapping;

using Microsoft.EntityFrameworkCore;

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

                // Upload the file if less than 8 MB
                if (memoryStream.Length <= 8388608 )
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

        public async Task<bool> DeleteDocumentByIdAsync(int id)
        {
            //Gets document for delete from db.
            var documentToDelete = this.repository.All()
                .FirstOrDefault(x => x.Id == id);

            if (documentToDelete != null)
            {
                //Delete the document from db.
                this.repository.Delete(documentToDelete);

                var result = await this.repository.SaveChangesAsync();
                return result > 0;
            }

            //Later move exceptions in GlobalConstants class.

            throw new InvalidOperationException($"Failed to delete document with id={documentToDelete.Id} from database!");
        }

        public async Task<IEnumerable<TViewModel>> GetAllDocumentAsync<TViewModel>()
        {
            //Gets all documents, working with ODZ.Mappings to map to IQueryable.

            var allDocuments = await this.repository
                .All()
                .Where(x => x.IsDeleted == false)
                .OrderBy(x => x.CreatedOn)
                .To<TViewModel>()
                .ToListAsync();

            if (allDocuments != null)
            {
                return allDocuments;
            }

            //Later move exceptions in GlobalConstants class.

            throw new InvalidOperationException("Failed to load documents from database!");
        }

        //Get document by passed id from database.
        public async Task<TViewModel> GetDocumentByIdAsync<TViewModel>(int id)
            => await this.repository.All()
            .Where(x => x.Id == id && x.IsDeleted == false)
            .To<TViewModel>()
            .FirstOrDefaultAsync();
    }
}