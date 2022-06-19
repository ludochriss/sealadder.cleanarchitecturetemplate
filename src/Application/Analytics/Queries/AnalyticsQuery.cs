using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Application.Analytics;
using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.WebUI.Controllers
{
    public class AnalyticsQuery : IRequest<RequestVM>
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }

    public class AnalyticsQueryHandler : IRequestHandler<AnalyticsQuery,RequestVM>
    {
        private readonly IApplicationDbContext _context;

        public AnalyticsQueryHandler(IApplicationDbContext _context)
        {
            _context = _context; 
        }

        public Task<RequestVM> Handle(AnalyticsQuery request, CancellationToken cancellationToken)
        {
            var result = _context.TotalSearches
                .Select(s => new RequestVM
                {
                    MovieSearches = s.MovieSearches
                    .Where(s => s.DateOccurred > request.Start && s.DateOccurred < request.End)
                .ToList(),
                    EmotionTags = s.EmotionTags
                    .Where(s => s.DateOccurred > request.Start && s.DateOccurred < request.End)
                    .ToList()
                });            
        }
    }
}