using Application.Commands;
using Application.Queries;
using Infrastructure.Core;
using Infrastructure.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Services
{

    public interface IPageService {
        Page GetPageByName(string name);
        void AddComment(CreateCommentCommand command);
    }

    public class PageService : IPageService
    {
        private readonly IQueryDispatcher _queryDispatcher;
        private readonly ICommandDispatcher _commandDispatcher;
        public PageService(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher) {
            _queryDispatcher = queryDispatcher;
            _commandDispatcher = commandDispatcher;
        }

        public Page GetPageByName(string name) {
            var page = TryGetPage(name);
            if (page != null) {
                return page;
            }
            _commandDispatcher.Execute<CreatePageCommand>(new CreatePageCommand(name));
            return TryGetPage(name);
        }

        private Page TryGetPage(string name) {
            try {
                return _queryDispatcher.Execute<GetPageByNameQuery, Page>(new GetPageByNameQuery(name));
            }
            catch(InvalidOperationException e) {
                return null;
            }
       }

        public void AddComment(CreateCommentCommand command) {
            _commandDispatcher.Execute(command);
        }
    }
}
