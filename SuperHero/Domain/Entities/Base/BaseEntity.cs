using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Base
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime? Created_At { get; set; }
        public bool Flg_Inativo { get; set; }
        public DateTime? Deleted_At { get; set; }

        public BaseEntity(){}
    }
}
