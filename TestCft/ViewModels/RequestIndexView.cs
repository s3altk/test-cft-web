using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using TestCft.Models;

namespace TestCft.ViewModels
{
    public class RequestIndexView
    {
        public IQueryable<Request> Requests { get; set; }
        public int RequestsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount { get { return Convert.ToInt32(Math.Ceiling(Requests.Count() / (double)RequestsPerPage)); } }

        public IQueryable<Request> PaginatedRequests()
        {
            var skipCount = (CurrentPage - 1) * RequestsPerPage;

            return Requests.OrderBy(p => p.Id).Skip(skipCount).Take(RequestsPerPage).Include(p => p.App);
        }
    }
}
