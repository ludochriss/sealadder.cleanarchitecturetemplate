using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Movies.Commands.TagEmotion
{
    public  class TagMovieWithEmotionCommand :IRequest<bool>
    {
        public int MovieId { get; set; }

        public int UserId { get; set; }

        public string Emotion { get; set; }
        public bool IsSuccessful { get; set; } = false;

    }
    public class TagMovieWithEmotionCommandHandler : IRequestHandler<TagMovieWithEmotionCommand, bool>
    {
        private readonly IApplicationDbContext _db;
        public TagMovieWithEmotionCommandHandler(IApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Handle(TagMovieWithEmotionCommand request, CancellationToken cancellationToken)
        {
            var result = await
                _db.MovieUsers
              .Include(u => u.UserEmotions)
              .Include(m => m.Movies)
              .ThenInclude(m => m.MovieEmotions)
              .FirstOrDefaultAsync(u=>u.Id == request.UserId);
            
            var movieExists = result.Movies.Exists(m => m.Id == request.MovieId);
            if (!movieExists)
            {
                return false;
            }
            var list = result.UserEmotions;
            list = CheckIfPreviouslyTaggedByUser(list, request)
            if ()
            {
                result.UserEmotions.f
            }

            return false;
           
        }
       
        
        public List<Emotion> CheckIfPreviouslyTaggedByUser(List<Emotion>emos, TagMovieWithEmotionCommand request, out bool prevTagged)
        {
            foreach (var emo in emos)
            {
                if (emo.Name == request.Emotion)
                {
                    
                    prevTagged = true;
                    emo.Count++;
                    return emos;
                }
            }
            prevTagged = false;
            return emos;
        }
       
    }

}
