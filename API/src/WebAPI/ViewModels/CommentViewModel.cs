using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.ViewModels
{
    public class CommentViewModel
    {
        public string Author { get; set; }
        public string Content { get; set; }
        public IEnumerable<CommentViewModel> Children { get; set; }
    }
}
