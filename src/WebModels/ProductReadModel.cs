using System;
using System.ComponentModel.DataAnnotations;

namespace WebModels
{
    public class ProductReadModel
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
