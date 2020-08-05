using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Andy.Mes.Entity
{
    [Table("Staff")]
    public class Staff : EntityBase
    {
        public string Name { get; set; }

        public string JobName { get; set; }
    }
}
