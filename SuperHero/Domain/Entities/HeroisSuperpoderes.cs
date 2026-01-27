using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class HeroisSuperpoderes : BaseEntity
    {
        public int HeroiId { get; set; }
        public int SuperpoderId { get; set; }

        public HeroisSuperpoderes() { }
    }
}
