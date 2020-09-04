using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Buisness.ViewModels
{
    public class UserViewModel
    {
        public Guid Id { get; set; }
        [Required]
        [DisplayName("User name")]
        public string UserName { get; set; }
        [Required]
        [MinLength(6)]
        [DisplayName("Password")]
        public string Password { get; set; }
        [Required]
        [MinLength(6)]
        [Compare(nameof(Password))]
        [DisplayName("Confirm password")]
        public string ConfirmPassword { get; set; }
        [Required]
        public DateTime Birthday { get; set; }
    }
}
