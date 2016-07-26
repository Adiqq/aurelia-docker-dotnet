using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.ViewModels
{
    public class PageViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<CommentViewModel> Comments { get; set; }
    }
}
