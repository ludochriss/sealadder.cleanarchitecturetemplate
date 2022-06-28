using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Movies.Commands.TagEmotion
{
    public class TagMovieWithEmotionCommand : IRequest<bool>
    {
        public int MovieId { get; set; }

        public int UserId { get; set; }

        public int EmotionId { get; set; }
        public bool IsSuccessful { get; set; } = false;

    }
    public class TagMovieWithEmotionCommandHandler : IRequestHandler<TagMovieWithEmotionCommand, bool>
    {
        private readonly IApplicationDbContext _db;
        private readonly ILoggerFactory _logger;
        private readonly IMovieCacheService _cache;
        private readonly IHttpClientFactory _client;


        public TagMovieWithEmotionCommandHandler(IHttpClientFactory client, IMovieCacheService cache, IApplicationDbContext db, ILoggerFactory logger)
        {
            _logger = logger;
             _cache = cache;    
            _db = db;
            _client = client;
        }
        public async Task<bool> Handle(TagMovieWithEmotionCommand request, CancellationToken cancellationToken)
        {
            var logger = _logger.CreateLogger<TagMovieWithEmotionCommand>();
            logger.LogInformation($"Emotion tagging request made by user Id : {request.UserId} at {DateTime.Now}" +
                $" for Movie of Id : {request.MovieId} with emotion of  : {request.EmotionId}");


                MovieList movieList = _cache.GetCachedMovies();            
                MovieEmotion me = new MovieEmotion{
                    MovieId = request.MovieId,
                    UserId = request.UserId,
                    EmotionId = request.EmotionId
                };                 
                _db.MovieEmotions.Add(me);
               await _db.SaveChangesAsync(cancellationToken);
                return request.IsSuccessful = true;
        }
    }
}
