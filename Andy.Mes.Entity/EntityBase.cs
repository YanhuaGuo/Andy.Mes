using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Andy.Mes.Entity
{
    public class EntityBase
    {
        [Key]
        public string Guid { get; set; }

        [Required]
        /// <summary>
        /// 是否删除
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}
