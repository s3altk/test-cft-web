using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TestCft.Models
{
    public partial class App
    {
        [HiddenInput(DisplayValue = false)]
        public Guid Id { get; set; }

        [Required]
        [DisplayName("App name")]
        public string Name { get; set; }

        [DisplayName("Creation date")]
        public DateTime? Created { get; set; }

        public ICollection<Request> Requests { get; set; }

        public App()
        {
            Requests = new HashSet<Request>();
        }
    }
}
