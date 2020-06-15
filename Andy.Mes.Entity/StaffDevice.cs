using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Andy.Mes.Entity
{
    [Table("StaffDevice")]
    public class StaffDevice : EntityBase
    {
        public string StaffGuid { get; set; }

        public string DeviceGuid { get; set; }
    }
}
