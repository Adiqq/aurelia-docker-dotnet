using Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Commands
{
    public class CreateCommentCommand : ICommand {
        public int PageId { get; }
        public string Author { get; }
        public string Content { get; }

        public CreateCommentCommand(int pageId, string author, string content) {
            PageId = pageId;
            Author = author;
            Content = content;
        }
    }
}
