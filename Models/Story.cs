using System;

namespace EFCoreTests.Models
{
    public class Story
    {
        public int StoryId { get; set; }
        public string Title { get; set; }
        public Guid WriterId { get; set; }
        public Writer Writer { get; set; }
    }
}
