using Application.Commands;
using Application.Queries;
using AutoMapper;
using Infrastructure.Core;
using Infrastructure.Data.Model;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using WebAPI.ViewModels;

namespace WebAPI.Services {

    public interface IPageService {
        PageViewModel GetPageByName(string name);
        void AddComment(CreateCommentCommand command);
    }

    public class PageService : IPageService
    {
        private readonly IQueryDispatcher _queryDispatcher;
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly ILogger<PageService> _logger;
        public PageService(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher, ILogger<PageService> logger) {
            _queryDispatcher = queryDispatcher;
            _commandDispatcher = commandDispatcher;
            _logger = logger;
        }

        public PageViewModel GetPageByName(string name) {
            var page = TryGetPage(name);
            if (page != null) {
                return Mapper.Map<Page, PageViewModel>(page);
            }

            _commandDispatcher.Execute<CreatePageCommand>(new CreatePageCommand(name));
            page = TryGetPage(name);

            return Mapper.Map<Page, PageViewModel>(page);
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
            _logger.LogDebug(JsonConvert.SerializeObject(command));
            _commandDispatcher.Execute(command);
        }
    }
}
