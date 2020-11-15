﻿using ODZ.Common;
using ODZ.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ODZ.Models
{
    public class Article : BaseDeletableModel<int>
    {
        [Required]
        [StringLength(GlobalConstants.MaxLenghtName, MinimumLength = GlobalConstants.MinLenghtName, ErrorMessage = GlobalConstants.NameErrorMsg)]
        public string Name { get; set; }

        [Required]
        [StringLength(GlobalConstants.MaxLenghtDescription,ErrorMessage = GlobalConstants.DescriptionErrorMsg, MinimumLength = GlobalConstants.MinLenghDescription )]
        public string Description { get; set; }


        public int DocumentId { get; set; }

        public Document Document { get; set; }

    }
}
