using Application.Commands;
using Infrastructure.Core;
using Infrastructure.Data;
using Infrastructure.Data.Model;

namespace Application.CommandHandlers {
    public class CreatePageCommandHandler : ICommandHandler<CreatePageCommand> {
        private readonly TestDbContext _context;
        public CreatePageCommandHandler(TestDbContext context) {
            _context = context;
        }
        public void Execute(CreatePageCommand command) {
            _context.Add<Page>(new Page {
                Name = command.Name
            });
            _context.SaveChanges();
        }
    }
}
