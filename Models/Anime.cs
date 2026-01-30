namespace Teste.Estagio.Models
{
    public class AnimeModel
    {
        public int Id { get; set; } 
        public string Title { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public int Episodes { get; set; } = 0;
        public string Studio { get; set; } = string.Empty;
        public float Score { get; set; } = 0.0f;
        public bool Watched { get; set; } = false;
    }
}