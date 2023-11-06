using System.Collections.Generic;

namespace SuperHero.Domain.Response
{
    public class CharacterResponse
    {
        public string Name { get; set; }
        public string Desc { get; set; }
        public Thumbnail Thumbnail { get; set; }
        public List<Event> Events { get; set; }

    }

    public class Event
    {
        public string Title { get; set; }
        public string Desc { get; set; }
        public Thumbnail Thumbnail { get; set; }

    }

    public class Thumbnail
    {
        public string Path { get; set; }
        public string Extension { get; set; }

    }
}
