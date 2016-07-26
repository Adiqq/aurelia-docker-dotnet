using Application.Queries;
using Infrastructure.Core;
using Infrastructure.Data;
using Infrastructure.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Application.QueryHandlers {
    public class GetPageByNameQueryHandler : IQueryHandler<GetPageByNameQuery, Page> {
        private readonly TestDbContext _context;
        public GetPageByNameQueryHandler(TestDbContext context) {
            _context = context;
        }
        public Page Execute(GetPageByNameQuery query) {
            return _context.Pages.Include(x => x.Comments).Single(x => x.Name == query.Name);
        }
    }
}
