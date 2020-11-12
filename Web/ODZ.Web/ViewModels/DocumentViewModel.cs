using System.ComponentModel.DataAnnotations;

namespace ODZ.Web.ViewModels { 

    public class DocumentViewModel 
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
