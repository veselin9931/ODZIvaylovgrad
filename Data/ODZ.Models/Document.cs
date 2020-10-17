using ODZ.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ODZ.Models
{
    public class Document : BaseDeletableModel<int>
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Url { get; set; }

    }
}
