using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("TipoStatus")]
    public class TipoStatus
    {
        public TipoStatus()
        {

        }
        [Key]
        public int TipoStatusId { get; set; }

        public string NomeStatus { get; set; }
    }
}
