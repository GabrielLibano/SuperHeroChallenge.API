namespace SuperHero.Marvel.ACL.Model
{
    public class CharacterMarvelModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ThumbnailModel Thumbnail { get; set; }
    }

}
