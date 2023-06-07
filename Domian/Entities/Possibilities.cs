﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinderProject.Domian.Entities.BaseEntity;

namespace FinderProject.Domian.Entities
{
   public class Possibilities:BaseEntities
    {
        public string PossibilityValue { get; set; }
        public virtual Product Product { get; set; }
        [ForeignKey("Product")]
        public long ProductId { get; set; }
    }
}
