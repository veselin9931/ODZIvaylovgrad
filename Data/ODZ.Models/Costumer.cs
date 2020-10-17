using ODZ.Common;
using ODZ.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ODZ.Models
{
    public class Costumer : BaseDeletableModel<int>
    {
        [Required]
        [StringLength(GlobalConstants.MaxLenghtName, MinimumLength = GlobalConstants.MinLenghtName, ErrorMessage = GlobalConstants.NameErrorMsg)]
        public string FirstName { get; set; }
        
        [Required]
        [StringLength(GlobalConstants.MaxLenghtName, MinimumLength = GlobalConstants.MinLenghtName, ErrorMessage = GlobalConstants.NameErrorMsg)]
        public string LastName { get; set; }

        [Required]
        [StringLength(GlobalConstants.MaxLenghtName, MinimumLength = GlobalConstants.MinLenghtName, ErrorMessage = GlobalConstants.NameErrorMsg)]
        public string Position { get; set; }

        public string ImageUrl { get; set; }
    }
}
