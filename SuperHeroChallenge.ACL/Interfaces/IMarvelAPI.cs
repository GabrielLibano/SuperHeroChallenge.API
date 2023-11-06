using SuperHero.Marvel.ACL.Model.Response;

namespace SuperHero.Marvel.ACL.Interfaces
{
    public interface IMarvelAPI
    {
        CharacterMarvelResponse GetCharacter(string name);
    }
}
