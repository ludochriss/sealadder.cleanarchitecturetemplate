using System;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Movies.Queries;
using CleanArchitecture.Application.Movies.Queries.GetMovies;
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
        public string Path { get => _path;}
        public string _path = "https://api.themoviedb.org/3/movie/505?api_key=05de5ca3aa311e569babae21ac91e652&language=en-US";

        [Fact]
        public async void ControllerIsFunctional()
        {
            
            var cont = new MovieController();
            //var result = await  cont.GetMovieInfo(Path);


            Assert.NotNull(cont);
           Assert.IsType<MovieVm>(cont.GetMovieInfo(Path).Result);
            

        }
        //[Fact]
        //public async void 



    }
}
