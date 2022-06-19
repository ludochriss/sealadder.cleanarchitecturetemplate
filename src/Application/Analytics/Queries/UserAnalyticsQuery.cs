using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Analytics.Queries
{
    public class UserAnalyticsQuery : IRequest<UserInfoVm>
    {

        public int UserId { get; set; }
        public class UserAnalyticsQueryHandler : IRequestHandler<UserAnalyticsQuery, UserInfoVm>
        {
            private readonly IApplicationDbContext _context;
            private readonly ILoggerFactory _logger;

            
            public UserAnalyticsQueryHandler(IApplicationDbContext _context, ILoggerFactory logger)
            {
                _context = _context;
                _logger = logger;
            }
            
            public Task<UserInfoVm> Handle(UserAnalyticsQuery request, CancellationToken cancellationToken)
            {
                var logger = _logger.CreateLogger<UserAnalyticsQueryHandler>();

                logger.LogInformation($"User Analytics request has been made at {DateTime.Now}");

                var result = _context.MovieUsers
                    .Select(x => new UserInfoVm
                    {
                        Id = x.Id,
                        Name = x.Name,
                        EmotionsSearched = x.UserEmotions,
                        MoviesSearched = x.Movies
                    })
                    .FirstOrDefaultAsync(x => x.Id == request.UserId);
                    
                    return result;
            }
        }
    }
}
