using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TestCft.Models
{
    public partial class Request
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        [DisplayName("Request name")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Development finish date")]
        public DateTime Finished { get; set; }

        [DisplayName("Description")]
        public string Description { get; set; }

        [EmailAddress]
        [Required]
        [DisplayName("Email")]
        public string Email { get; set; }

        [Required]
        [DisplayName("App")]
        public Guid AppId { get; set; }

        public App App { get; set; }
    }
}
