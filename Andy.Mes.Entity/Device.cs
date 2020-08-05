using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Andy.Mes.Entity
{
    [Table("Device")]
    public class Device : EntityBase
    {
        public string Name { get; set; }

        public DateTime ProduceDate { get; set; }
    }
}
