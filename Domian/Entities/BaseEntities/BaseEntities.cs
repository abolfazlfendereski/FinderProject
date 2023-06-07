using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinderProject.Domian.Entities.BaseEntity
{
   public class BaseEntities
    {
        [Key]
        public long Id { get; set; }
        public DateTime InsertTime { get; set; } = DateTime.Now;
        public DateTime UpdateTime { get; set; }
        public bool isRemoved { get; set; } = false;
        public DateTime RemovedTime { get; set; }

    }
}
