using System;
using System.Collections.Generic;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Movies.Commands.TagEmotion;
using CleanArchitecture.Application.Movies.Queries;
using CleanArchitecture.Application.Movies.Queries.GetMovies;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Infrastructure.Persistence;
using CleanArchitecture.WebUI.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using Xunit;
using Xunit.Abstractions;
using Xunit.DependencyInjection;


namespace MovieTests
{
    //Arrange
    //Act
    //Assert


    public class MovieTests
    {
       [Fact]

       public void ControllerIsFunctional()
        {
            //Arrange
            var mC = new MovieController();


            //Act
           var result =  mC.GetMovieInfo("path");

            //Assert
            Assert.IsType<MovieVm>(result);

        }



    }
}
