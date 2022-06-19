using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Events;
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
            var mov = result.Movies.Find(m => m.Id == request.MovieId);
            mov.TagEmotion(mov, result);
            var list = result.UserEmotions;
            list = CheckIfPreviouslyTaggedByUser(list, request, out bool prevTagged);
            // check if the movie was previously tagged.
            if (prevTagged)
            {
                result.UserEmotions = list;
                _db.MovieUsers.Update(result);
               await _db.SaveChangesAsync(cancellationToken);
                return true;
            }
            else
            {
                var emo = new Emotion
                {
                    Name = request.Emotion,
                    Count = 1
                };
                result.UserEmotions.Add(emo);
                _db.MovieUsers.Update(result);
              await  _db.SaveChangesAsync(cancellationToken);
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
