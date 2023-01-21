using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientsDb.Entities
{
    [Table("Orders")]
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [Required]        
        public string Name { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        [Column("Description")]
        public string Description { get; set; }
        public int ClientId { get; set; }
        //навигационное свойство
        public Client Customer { get; set; }
    }
}
