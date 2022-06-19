using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Movies.EventHandlers
{
    public class MovieSearchedEventHandler : INotificationHandler<DomainEventNotification<MovieSearchedEvent>>
    {
        private readonly ILogger<MovieSearchedEventHandler> _logger;
        private readonly IApplicationDbContext _context;
        public MovieSearchedEventHandler(ILogger<MovieSearchedEventHandler> logger, IApplicationDbContext context)
        {
            _context = context;
            _logger = logger;
        }
        public Task Handle(DomainEventNotification<MovieSearchedEvent> notification, CancellationToken cancellationToken)
        {
            
            var dE = notification.DomainEvent;
            
            _logger.LogInformation($"Movie searched at : {dE.DateOccurred}\nMovie search took : {dE.TimeTaken}\nMovie pulled from cache : {dE.IsFromCache} ", dE.GetType().Name);

            return Task.CompletedTask;
        }
    }
}
