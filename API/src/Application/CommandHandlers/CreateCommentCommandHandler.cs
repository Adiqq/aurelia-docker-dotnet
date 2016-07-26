using Application.Commands;
using Infrastructure.Core;
using Infrastructure.Data;
using Infrastructure.Data.Model;
using Microsoft.Extensions.Logging;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Application.CommandHandlers {
    public class CreateCommentCommandHandler : ICommandHandler<CreateCommentCommand> {
        private readonly TestDbContext _context;
        public CreateCommentCommandHandler(TestDbContext context) {
            _context = context;
        }
        public void Execute(CreateCommentCommand command) {
            var page = _context.Pages.Include(x => x.Comments).Single(x => x.Id == command.PageId);

            var comment = new Comment {
                Author = command.Author,
                Content = command.Content,
                PageId = command.PageId
            };
            page.Comments.Add(comment);

            _context.SaveChanges();
        }
    }
}
