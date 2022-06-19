using System;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.WebUI.Controllers
{
    public class AnalyticsQueryHandlerBase
    {
        public Task<> Handle(AnalyticsQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}