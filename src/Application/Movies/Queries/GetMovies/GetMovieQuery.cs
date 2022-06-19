using System;

using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Movies.Queries.GetMovies;
using CleanArchitecture.Domain.Entities;
using MediatR;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

using CleanArchitecture.Domain.Events;
using System.Diagnostics;

namespace CleanArchitecture.Application.Movies.Queries
{
    public class GetMovieQuery : IRequest<MovieVm>
    {
        
        public string Path { get; set; }
    }
    public class GetMovieQueryHandler : IRequestHandler<GetMovieQuery, MovieVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpClientFactory _client;
        private readonly IMovieCacheService _cache;
        private readonly ILoggerFactory _logger;
        private readonly IIdentityService _identity;

        //di of mapper, httpclient and dbcontext
        public GetMovieQueryHandler(IMovieCacheService cache, IApplicationDbContext context, IMapper mapper,
            IHttpClientFactory client,ILoggerFactory logger)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
            _client = client;
            _cache = cache;
            
        }   
        public async Task<MovieVm> Handle(GetMovieQuery request, CancellationToken cancellationToken)
        {            //------STOPWATCH & LOGGER------
            var logger = _logger.CreateLogger<GetMovieQueryHandler>();   
            logger.LogInformation($"Request received at {DateTime.Now}");
            Stopwatch stopwatch = new Stopwatch();          
            stopwatch.Start();
            logger.Log(LogLevel.Information, "Timing Request..");

            //create new movieVM
            var vm = new MovieVm();

            //check cache for movieslist or create and return an empty list             
            MovieList movieList = _cache.GetCachedMovies();
            logger.LogInformation("Cache Accessed");

            //check the movies for matching url
            //return the movie vm if found.          
            foreach (var m in movieList.Movies)
            {
                if (m.Url == request.Path)
                {
                    long located = stopwatch.ElapsedTicks;
                    m.UpdateMovieInfo(new MovieSearchedEvent(m, stopwatch.Elapsed, true), request.Path);                    
                    _context.Movies.Update(m);
                    _context.SaveChangesAsync(cancellationToken);
                    long saved = stopwatch.ElapsedTicks;
                    movieList.Movies.Add(m);
                    _cache.SetMoviesToCache(movieList);
                    vm = _mapper.Map<MovieVm>(m);
                    logger.Log(LogLevel.Information,
                        $"Movie located in cache at {new TimeSpan(located)} and information updated at {new TimeSpan(saved)}");
                    stopwatch.Stop();
                    return vm;
                }
            }
            //-------create HttpClient and time the call-------------
            var requestSent = stopwatch.Elapsed;
            var cli = _client.CreateClient();
            var response = await
                cli.GetAsync(request.Path);
            var httpCallDuration = stopwatch.Elapsed - requestSent;
            //Mapping Json Response
            if (response.IsSuccessStatusCode)
            {
                //start time                
                var mR = _cache.DeserializeMovieResponse(response);
                try
                {
                    var m =  await _context.Movies                        
                        .FirstOrDefaultAsync(l => l.Id == mR.Id);

                    if (m == null)
                    {
                        m = new Movie();                
                    }
                    //updated information about movies
                    m.UpdateMovieInfo(new MovieSearchedEvent(m, stopwatch.Elapsed, false), request.Path);                 
                   
                    //update the tracked item and save
                    _context.Movies.Update(m);
                    _context.SaveChangesAsync(cancellationToken);
                    //update the cache
                    movieList.Movies.Add(m);
                    _cache.SetMoviesToCache(movieList);

                    //log information
                    logger.Log(LogLevel.Information,
                       $"Movie request sent at {requestSent} and information received at {httpCallDuration}");

                    //return the model
                    vm = _mapper.Map<MovieVm>(m);
                }
                catch (Exception e)
                {
                    logger.LogError($"EXCEPTION {e} LOGGED AT : {DateTime.Now}");
                    throw e;
                }
            }
            stopwatch.Stop();
            return vm;
        }
    }
}
