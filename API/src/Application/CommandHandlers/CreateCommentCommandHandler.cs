using Application.Commands;
using Infrastructure.Core;
using Infrastructure.Data;
using Infrastructure.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.CommandHandlers
{
    public class CreateCommentCommandHandler : ICommandHandler<CreateCommentCommand> {
        private readonly TestDbContext _context;
        public CreateCommentCommandHandler(TestDbContext context) {
            _context = context;
        }
        public void Execute(CreateCommentCommand command) {
            var aggregateRoot = _context.Pages.Single(x => x.Id == command.PageId);
            aggregateRoot.Comments.Add(new Comment {
                Author = command.Author,
                Content = command.Content,
            });
            _context.SaveChanges();
        }
    }
}
