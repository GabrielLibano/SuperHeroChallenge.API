using SuperHero.Domain.Request;
using SuperHero.Domain.Response;
using SuperHero.Marvel.ACL.Interfaces;
using SuperHero.Service.Interfaces;
using System;
using System.Collections.Generic;

namespace SuperHero.Service
{
    public class CharacterService : ICharacterService
    {
        private readonly IMarvelAPI _marvelAPI;

        public CharacterService(IMarvelAPI marvelAPI)
        {
            _marvelAPI = marvelAPI;
        }
        public CharacterResponse GetCharacter(CharacterRequest request)
        {
            try
            {

                if (request == null || request.Nome == string.Empty) throw new Exception("Requesição inválida!");

                var marvelResult = _marvelAPI.GetCharacter(request.Nome);
                CharacterResponse character = new CharacterResponse();
                Thumbnail thumbnail = new Thumbnail();

                character.Name = marvelResult.Name;
                character.Desc = marvelResult.Description;
                thumbnail.Path = marvelResult.Thumbnail.Path;
                thumbnail.Extension = marvelResult.Thumbnail.Extension;
                character.Thumbnail = thumbnail;
                List<Event> eventList = new List<Event>();

                foreach (var currentEvent in marvelResult.Events)
                {
                    Thumbnail thumbnailEvents = new Thumbnail();
                    thumbnailEvents.Path = currentEvent.Thumbnail.Path;
                    thumbnailEvents.Extension = currentEvent.Thumbnail.Extension;
                    var jsonEvent = new Event
                    {
                        Title = currentEvent.Title,
                        Desc = currentEvent.Description,
                        Thumbnail = thumbnailEvents
                    };
                    eventList.Add(jsonEvent);
                }
                character.Events = eventList;
                return character;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
