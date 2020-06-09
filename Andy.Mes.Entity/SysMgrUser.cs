using System;
using System.Collections.Generic;
using System.Text;

namespace Andy.Mes.Entity
{
    public class SysMgrUser 
    {
        public string Guid { get; set; }
        public string DataVersion { get; set; }

        public string Name { get; set; }
        public string Age { get; set; }
        public bool Sex { get; set; }
        public string Telephone { get; set; }
    }

}