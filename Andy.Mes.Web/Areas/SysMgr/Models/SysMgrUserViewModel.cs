using Andy.Mes.Web.Models;
using System;

namespace Andy.Mes.Web
{
    public class SysMgrUserViewModel : ViewModelBase
    {


        public string Guid { get; set; }
        public string DataVersion { get; set; }

        public string Name { get; set; }
        public char Age { get; set; }
        public char Sex { get; set; }
        public string Telephone { get; set; }


    }
}
