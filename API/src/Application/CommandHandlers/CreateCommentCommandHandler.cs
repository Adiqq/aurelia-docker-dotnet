using Application.Commands;
using Infrastructure.Core;
using Infrastructure.Data;
using Infrastructure.Data.Model;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.CommandHandlers
{
    public class CreateCommentCommandHandler : ICommandHandler<CreateCommentCommand> {
        private readonly TestDbContext _context;
        private readonly ILogger<CreateCommentCommandHandler> _logger;
        public CreateCommentCommandHandler(TestDbContext context, ILogger<CreateCommentCommandHandler> logger) {
            _context = context;
            _logger = logger;
        }
        public void Execute(CreateCommentCommand command) {
            var page = _context.Pages.Single(x => x.Id == command.PageId);
            _logger.LogDebug(JsonConvert.SerializeObject(page));
            var comment = new Comment {
                Author = command.Author,
                Content = command.Content
            };
            page.Comments = new List<Comment> { comment };
            _logger.LogDebug(JsonConvert.SerializeObject(page));
            _context.SaveChanges();
        }
    }
}
