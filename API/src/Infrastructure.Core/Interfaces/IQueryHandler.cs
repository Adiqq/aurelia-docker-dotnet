using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Core
{
    public interface IQueryHandler<in TQuery, out TResult>
     where TQuery : IQuery<TResult> {
        TResult Execute(TQuery query);
    }
}
