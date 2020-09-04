using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Buisness.ViewModels
{
    public class StoreViewModel
    {
        public Guid Id { get; set; }
        [Required]
        
        public string StoreName { get; set; }
        public IEnumerable<ProductViewModel> Products { get; set; }
    }
}
