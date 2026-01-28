using Domain.Entities.Base;

namespace Domain.Entities
{
    public class Herois : BaseEntity
    {
        public string Nome { get; set; }
        public string NomeHeroi { get; set; }
        public DateTime DataNascimento { get; set; }
        public Decimal Altura { get; set; }
        public Decimal Peso { get; set; }

        public virtual ICollection<HeroisSuperpoderes> HeroisSuperpoderes { get; set; }

        public Herois(){}
    }
}
