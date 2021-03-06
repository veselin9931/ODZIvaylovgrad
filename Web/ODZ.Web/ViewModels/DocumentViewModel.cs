﻿using ODZ.Models;
using System.ComponentModel.DataAnnotations;
using ODZ.Services.Mapping;

namespace ODZ.Web.ViewModels { 

    public class DocumentViewModel : IMapFrom<Document>
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public byte[] Bytes { get; set; }

        [Required]
        public long Size { get; set; }
    }
}
