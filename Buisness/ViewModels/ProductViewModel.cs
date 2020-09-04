using AutoMapper;
using Buisness.Logging;
using Domain.Entities;
using DomainAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.ViewModels
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string MainDescription { get; set; }
        
        public string SmallDescription { get; set; }
        [Required]
        public decimal Coast { get; set; }
        public Guid StoreId { get; set; }

    }
}
