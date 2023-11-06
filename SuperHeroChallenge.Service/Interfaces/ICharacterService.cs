using SuperHero.Domain.Request;
using SuperHero.Domain.Response;

namespace SuperHero.Service.Interfaces
{
    public interface ICharacterService
    {
        CharacterResponse GetCharacter(CharacterRequest request);
    }
}
