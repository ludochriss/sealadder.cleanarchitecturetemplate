using System;
using System.Collections.Generic;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Movies.Commands.TagEmotion;
using CleanArchitecture.Application.Movies.Queries;
using CleanArchitecture.Application.Movies.Queries.GetMovies;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.WebUI.Controllers;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Xunit.DependencyInjection;


namespace MovieTests
{
    //Arrange
    //Act
    //Assert
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IApplicationDbContext, IApplicationDbContext>();
        }
    }
    public class MovieTests
    {
        private readonly IApplicationDbContext _context;
        public string Path { get => _path;}
        public string _path = "https://api.themoviedb.org/3/movie/505?api_key=05de5ca3aa311e569babae21ac91e652&language=en-US";

        [Fact]
        public async void ControllerIsFunctional()
        {
            
            var cont = new MovieController();
            //var result = await  cont.GetMovieInfo(Path);

            
            Assert.NotNull(cont);
          // Assert.IsType<MovieVm>(cont.GetMovieInfo(Path).Result);
         
            
        }
    
        [Fact]
        public async void EmotionTagReturnsBool()
        {


            //Arrange
            var command = new TagMovieWithEmotionCommand();
            var emo = new List<Emotion>();
            var handler = new TagMovieWithEmotionCommandHandler(_context);


            //Act
            Assert.IsType<List<Emotion>>(handler.CheckIfPreviouslyTaggedByUser(emo, command, out bool prev));
            //Assert
        }

    }
}
