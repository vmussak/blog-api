using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.UseCases
{
    public interface IUseCase<TRequest, TResponse>
    {
        public Task<DefaultResult<TResponse>> Handle(TRequest request, CancellationToken cancellationToken);
    }
}
