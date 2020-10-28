using ODZ.Common;
using ODZ.Data.Common.Models;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ODZ.Models
{
    public class Group : BaseDeletableModel<int>
    {
        public Group()
        {
            this.Personal = new List<Customer>();
        }

        [Required]
        [StringLength(GlobalConstants.MaxLenghtName, MinimumLength = GlobalConstants.MinLenghtName, ErrorMessage = GlobalConstants.NameErrorMsg)]
        public string Name { get; set; }

        [Required]
        [StringLength(GlobalConstants.MaxLenghtDescription, ErrorMessage = GlobalConstants.DescriptionErrorMsg, MinimumLength = GlobalConstants.MinLenghDescription)]
        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public IList<Customer> Personal { get; set; }
    }
}
