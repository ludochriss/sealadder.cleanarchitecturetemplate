using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using CleanArchitecture.Application.Analytics;
using CleanArchitecture.Application.Analytics.Queries;
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
        public async Task<ActionResult<bool>> TagEmotion(int movieId, int userId, int emotionId)
        {
            return await Mediator.Send(new TagMovieWithEmotionCommand
            {
                MovieId = movieId,
                UserId = userId,
                EmotionId =  emotionId
            }); 

            throw new NotImplementedException();
        }
        [HttpGet]
        [Route("movie/general")]
        public async Task<ActionResult<RequestVM>> RequestAnalyticsInfo(string start, string end)
        {
            var _start = DateTime.Parse(start);
            var _end = DateTime.Parse(end);
            return await Mediator.Send(new AnalyticsQuery
            {                
                Start = _start,
                End = _end
            }); 
        }
        [HttpGet]
        [Route("Movie/user")]
        public async Task<ActionResult<UserInfoVm>> GetRequestsForUser(int id)
        {                   
                return await Mediator.Send(new UserAnalyticsQuery
                {
                    UserId = id
                }) ;
            
            throw new Exception("Id cannot be a non-integer");
        }

   


 
    }
}
