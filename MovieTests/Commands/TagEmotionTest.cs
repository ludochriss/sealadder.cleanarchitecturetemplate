using System;
using System.Collections.Generic;
using System.Text;
using CleanArchitecture.Application.Movies.Commands.TagEmotion;
using Xunit;

namespace MovieTests.Commands
{
    public class TagEmotionTest
    {
        [Fact]
        public void CheckHandleCompiles()
        {
            var tag = new TagMovieWithEmotionCommand();

            tag.Handle

        }

    }
}
