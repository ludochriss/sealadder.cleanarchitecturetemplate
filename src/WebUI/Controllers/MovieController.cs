using System;
using System.Net.Http;
using System.Threading.Tasks;
using CleanArchitecture.Application.Movies.Commands.TagEmotion;
using CleanArchitecture.Application.Movies.Queries;
using CleanArchitecture.Application.Movies.Queries.GetMovies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebUI.Controllers
{
    public class MovieController : ApiController
    {
        // api/{controller}/{action=Index}/{id?}


        //inject the http client in handler to manage  life cycle and connection properties
        [HttpGet]
        public async Task<ActionResult<MovieVm>> GetMovieInfo(string path)
        {
            return await Mediator.Send(new GetMovieQuery
            {
                Path = path
            });
        }

        [HttpPost]
        public async Task<ActionResult<bool>> TagEmotion(int movieId, int userId, string emotion)
        {
            return await Mediator.Send(new TagMovieWithEmotion
            {
                MovieId = movieId,
                UserId = userId,
                Emotion= emotion
            }); ;

            throw new NotImplementedException();
        }

        //[HttpGet]
        //public async Task<ActionResult<MovieVm>> GetMovieInfo(string path, int emo)
        //{
        //    return await Mediator.Send(new GetMovieQueryWithEmotion)
        //    {
        //        Path = path

        //    });
        //}

        //[HttpPost]
        //public async Task<ActionResult<int>> Create(CreateMovieCommand command)
        //{
        //    return await Mediator.Send(command);
        //}

        //[HttpPut("{id}")]
        //public async Task<ActionResult> Update(int id, UpdateMovieCommand command)
        //{
        //    if (id != command.Id)
        //    {
        //        return BadRequest();
        //    }

        //    await Mediator.Send(command);

        //    return NoContent();
        //}

        //[HttpPut("[action]")]
        //public async Task<ActionResult> UpdateMovieDetails(int id, UpdateMovieDetailsCommand command)
        //{
        //    if (id != command.Id)
        //    {
        //        return BadRequest();
        //    }

        //    await Mediator.Send(command);

        //    return NoContent();
        //}

        //[HttpDelete("{id}")]
        //public async Task<ActionResult> Delete(int id)
        //{
        //    await Mediator.Send(new DeleteMovieCommand { Id = id });

        //    return NoContent();
        //}
    }
}
