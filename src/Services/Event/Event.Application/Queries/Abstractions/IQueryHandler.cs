using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Application.Queries.Abstractions
{
    public interface IQueryHandler<TQuery, TResult>
        where TQuery : notnull, IQuery<TResult>
    {
        Task<TResult> HandleAsync(TQuery query);
    }
}
