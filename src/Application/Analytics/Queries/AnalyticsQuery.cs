using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Application.Analytics;
using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.WebUI.Controllers
{
    public class AnalyticsQuery : IRequest<RequestVM>
    {
        public DateTime _start;
        public string Start
        {
            get => _start.ToString();
            set => DateTime.Parse(value);
        }
        public DateTime _end;
        public string End
        {
            get => _start.ToString();
            set => DateTime.Parse(value);
        }       
    }
    public class AnalyticsQueryHandler : IRequestHandler<AnalyticsQuery,RequestVM>
    {
        private readonly ILoggerFactory _logger;

        private readonly IApplicationDbContext _context;

        public AnalyticsQueryHandler(IApplicationDbContext context,  ILoggerFactory logger)
        {
            _logger = logger;
            _context = context; 
        }
        //fucking nailed it
        public Task<RequestVM> Handle(AnalyticsQuery request, CancellationToken cancellationToken)
        {
            var logger = _logger.CreateLogger<AnalyticsQueryHandler>();
            logger.LogInformation($"General analytics query made at {DateTime.Now}");
            var result = _context.TotalSearches
                .Select(s => new RequestVM
                {
                    MovieSearches = s.MovieSearches
                    .Where(s => s.DateOccurred > request._start && s.DateOccurred < request._end)
                .ToList(),
                    EmotionTags = s.EmotionTags
                    .Where(s => s.DateOccurred > request._start && s.DateOccurred < request._end)
                    .ToList()
                });
            return (Task<RequestVM>)result;
        }
    }
}