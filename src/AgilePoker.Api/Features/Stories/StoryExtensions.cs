using System;
using AgilePoker.Api.Models;

namespace AgilePoker.Api.Features
{
    public static class StoryExtensions
    {
        public static StoryDto ToDto(this Story story)
        {
            return new ()
            {
                StoryId = story.StoryId
            };
        }
        
    }
}
