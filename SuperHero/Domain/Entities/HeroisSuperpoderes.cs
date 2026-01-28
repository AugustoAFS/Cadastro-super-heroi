using Domain.Entities.Base;


namespace Domain.Entities
{
    public class HeroisSuperpoderes : BaseEntity
    {
        public Herois Heroi { get; set; }
        public int HeroiId { get; set; }
        public Superpoderes Superpoder { get; set; }
        public int SuperpoderId { get; set; }

        public HeroisSuperpoderes() { }
    }
}
