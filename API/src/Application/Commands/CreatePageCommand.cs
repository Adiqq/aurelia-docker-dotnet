using Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Commands
{
    public class CreatePageCommand : ICommand
    {
        public string Name { get; set; }

        public CreatePageCommand() {

        }
        public CreatePageCommand(string name) {
            Name = name;
        }
    }
}
