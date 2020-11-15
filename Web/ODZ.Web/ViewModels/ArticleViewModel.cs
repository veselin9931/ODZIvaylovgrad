using Newtonsoft.Json;
using ODZ.Common;
using System.ComponentModel.DataAnnotations;

namespace ODZ.Web.ViewModels
{
    public class ArticleViewModel
    {
        [Required]
        [StringLength(GlobalConstants.MaxLenghtName, MinimumLength = GlobalConstants.MinLenghtName, ErrorMessage = GlobalConstants.NameErrorMsg)]
        public string Name { get; set; }

        [Required]
        [StringLength(GlobalConstants.MaxLenghtDescription, ErrorMessage = GlobalConstants.DescriptionErrorMsg, MinimumLength = GlobalConstants.MinLenghDescription)]
        public string Description { get; set; }


        public string ImagePath { get; set; }
    }
}
