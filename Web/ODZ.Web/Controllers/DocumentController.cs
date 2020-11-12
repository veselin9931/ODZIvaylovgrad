﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using Microsoft.Web.Helpers;
using ODZ.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ODZ.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentService documentService;

        public DocumentController(IDocumentService documentService)
        {
            this.documentService = documentService;
        }

        // POST api/<DocumentController>
        [HttpPost("{fileName}")]
        public async Task<IActionResult> Upload(string fileName)
        {
            IFormFile file = Request.Form.Files[0];

            if (file == null || file.Length > 8388608)
            {
                return this.UnprocessableEntity(new  {err = "Качения файл трябва да бъде не по-голям от 8МБ. Ако искате да качите по-голям файл свържете се с вашия администратор." }); 
            }

            bool result = await this.documentService.CreateDocument(fileName, file);

            if (!result)
            return this.BadRequest();

            return Ok(new { err = $"Качването е успешно. Вие създадохте файл с име {fileName}" });
        }

        // GET api/<DocumentController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // PUT api/<DocumentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DocumentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
