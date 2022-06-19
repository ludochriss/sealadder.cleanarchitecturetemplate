using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Movies.Queries;
using CleanArchitecture.Application.Movies.Queries.GetMovies;
using CleanArchitecture.Domain.Events;
using FluentAssertions;
using NUnit.Framework;

namespace CleanArchitecture.Application.IntegrationTests.Movie
{
    using static Testing;
    public class GetMovieTest : TestBase
    {

        public string MovieApiPath { get; set; } = "https://api.themoviedb.org/3/movie/25/recommendations?api_key=05de5ca3aa311e569babae21ac91e652&language=en-US&page=1";
        public GetMovieQuery Query { get; set; }

        public MovieSearchedEvent Event { get; set; }
        [Test]
        public async Task ShouldReturnValidModel()
        {
            var query = new GetMovieQuery();
            query.Path = MovieApiPath;
            MovieVm result =await SendAsync(query);

            result.Should().NotBeNull();
            result.Should().BeOfType<MovieVm>();
            
        }

    }
}
