using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Andy.Mes.Entity
{
    [Table("SysMgrUser")]
    public class SysMgrUser
    {
        [Key]
        public string Guid { get; set; }
        public string DataVersion { get; set; }

        [Required]
        public string Name { get; set; }
        public int Age { get; set; }

        [Column("Sex")]
        public char _sex { get; set; }
        [NotMapped]
        public bool Sex { get { return _sex == '1'; } set { _sex = value ? '1' : '0'; } }


        public string Telephone { get; set; }
    }

}