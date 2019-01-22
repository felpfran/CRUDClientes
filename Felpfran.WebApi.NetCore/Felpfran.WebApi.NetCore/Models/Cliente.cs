using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Felpfran.WebApi.NetCore.Models
{
    public class Cliente
    {
        public long ID { get; set; }
        [Required]
        [StringLength(150)]
        public string Nome { get; set; }
        [Required]
        [StringLength(100)]
        public string Email { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DataNascimento { get; set; }
    }
}
