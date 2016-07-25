using Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Commands
{
    public class CreateCommentCommand : ICommand {
        public int PageId { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public CreateCommentCommand() {

        }
        public CreateCommentCommand(int pageId, string author, string content) {
            PageId = pageId;
            Author = author;
            Content = content;
        }
    }
}
