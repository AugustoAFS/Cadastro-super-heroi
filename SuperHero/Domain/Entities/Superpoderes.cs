using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Superpoderes : BaseEntity
    {
        public string Superpoder { get; set; }
        public string Descricao { get; set; }

        public Superpoderes(){}
    }
}
