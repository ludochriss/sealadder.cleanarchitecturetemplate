using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Movies.Commands.TagEmotion
{
    public  class TagMovieWithEmotion :IRequest<bool>
    {
        public int MovieId { get; set; }

        public int UserId { get; set; }

        public string Emotion { get; set; }
        public bool IsSuccessful { get; set; } = false;

    }
    public class TagMovieWithEmotionCommandHandler : IRequestHandler<TagMovieWithEmotion, bool>
    {
        private readonly IApplicationDbContext _db;
        public TagMovieWithEmotionCommandHandler(IApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Handle(TagMovieWithEmotion request, CancellationToken cancellationToken)
        {
            var result = await 
                _db.Movies.Include(m => m.Emotions)
                
                .FirstOrDefaultAsync(m => m.Id == request.MovieId);

        }
    }

}
