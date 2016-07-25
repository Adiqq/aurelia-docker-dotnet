using Infrastructure.Core.Exceptions;
using Infrastructure.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Core
{
    public class QueryDispatcher : IQueryDispatcher {
        private readonly IDependencyResolver _resolver;

        public QueryDispatcher(IDependencyResolver resolver) {
            _resolver = resolver;
        }

        public TResult Execute<TQuery, TResult>(TQuery query)
            where TQuery : IQuery<TResult> {
            if (query == null) {
                throw new ArgumentNullException("query");
            }

            var handler = _resolver.Resolve<IQueryHandler<TQuery, TResult>>();

            if (handler == null) {
                throw new QueryHandlerNotFoundException(typeof(TQuery));
            }

            return handler.Execute(query);
        }
    }
}
