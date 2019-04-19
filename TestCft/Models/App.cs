using System;
using System.Collections.Generic;

namespace TestCft.Models
{
    public partial class App
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime? Created { get; set; }
        public ICollection<Request> Requests { get; set; }

        public App()
        {
            Requests = new HashSet<Request>();
        }
    }
}
