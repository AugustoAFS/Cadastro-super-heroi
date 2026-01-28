using System.ComponentModel.DataAnnotations;

namespace ApplicationService.Dtos.Resposes.Heroi
{
    public class HeroiResponse
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string NomeHeroi { get; set; }
        public DateTime DataNascimento { get; set; }
        public decimal Altura { get; set; }
        public decimal Peso { get; set; }

        public List<string> Superpoderes { get; set; } = new List<string>();
    }
}
