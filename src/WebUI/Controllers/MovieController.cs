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
        public async Task<ActionResult<bool>> TagEmotion(int movieId, int userId, string emotion)
        {
            return await Mediator.Send(new TagMovieWithEmotionCommand
            {
                MovieId = movieId,
                UserId = userId,
                Emotion= emotion
            }); ;

            throw new NotImplementedException();
        }
        [HttpGet]
        [Route("Movie/GeneralAnalyticsInfo")]
        public async Task<ActionResult<RequestVM>> RequestAnalyticsInfo(string start, string end)
        {
            return await Mediator.Send(new AnalyticsQuery
            {
                
                Start = start,
                End = end
            }); ;

        }
        [HttpGet]
        [Route("Movie/UserAnalyticsInfo")]
        public async Task<ActionResult<UserInfoVm>> GetRequestsForUser(string id)
        {
            bool valid = Int32.TryParse(id, out int result);
            if (valid)
            {
                return await Mediator.Send(new UserAnalyticsQuery
                {
                    UserId = result

                }) ;
            }
            throw new Exception("Id cannot be a non-integer");

        }

        //[HttpGet]
        //public async Task<ActionResult<MovieVm>> GetMovieInfo(string path, int emo)
        //{
        //    return await Mediator.Send(new GetMovieQueryWithEmotion)
        //    {
        //        Path = path

        //    });
        //}


 
    }
}
