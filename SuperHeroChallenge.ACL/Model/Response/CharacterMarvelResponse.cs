using System.Collections.Generic;

namespace SuperHero.Marvel.ACL.Model.Response
{
    public class CharacterMarvelResponse
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ThumbnailModel Thumbnail { get; set; }
        public List<EventsModel> Events { get; set; }

        public CharacterMarvelResponse(CharacterMarvelModel characterModel, List<EventsModel> eventsModel)
        {
            Name = characterModel.Name;
            Description = characterModel.Description;
            Thumbnail = characterModel.Thumbnail;
            Events = eventsModel;
        }
    }
}
