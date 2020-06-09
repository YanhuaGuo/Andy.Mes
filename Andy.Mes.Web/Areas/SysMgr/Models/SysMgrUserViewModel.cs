using Andy.Mes.Web.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Andy.Mes.Web
{
    public class SysMgrUserViewModel : ViewModelBase
    {

        public string Guid { get; set; }
        public string DataVersion { get; set; }

        public string Name { get; set; }
        public int Age { get; set; }
        public bool Sex { get; set; }
        public string Telephone { get; set; }


    }
}
