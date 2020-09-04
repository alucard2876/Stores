using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Buisness.ViewModels
{
    public class OrderViewModel
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public Guid UserId { get; set; }
        public UserViewModel User { get; set; }
    }
}
