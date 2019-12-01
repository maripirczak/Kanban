using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain
{
    [Table("Status")]
    public class Status
    {
        [Key]
        public int StatusId { get; set; }

        public string TipoStatus { get; set; }
    }
}
