﻿using System.ComponentModel.DataAnnotations.Schema;
using FinderProject.Domian.Entities.BaseEntity;

namespace FinderProject.Domian.Entities
{
    public class Features : BaseEntities
    {

        public virtual Product Product { get; set; }
        [ForeignKey("Product")]
        public long ProductId { get; set; }
        public string DisPlayName { get; set; }
        public string value { get; set; }
        
    }
}