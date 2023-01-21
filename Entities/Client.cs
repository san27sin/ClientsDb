using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientsDb.Entities
{
    [Table("Clients")]
    public class Client
    {
        [Column("client_id")] //свойство Id будет сопоставляться со столбцом "user_id" (а не Id, как бы было по умолчанию).
        public int Id { get; set; }
        [MaxLength(50)]//ограничение по длине 
        public string Name { get; set; }
        [MaxLength(50)]//ограничение по длине
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int Age { get; set; }

        public List<Order> Orders { get; set; } = new();
        // навигационное свойство, ссылка на другие сущности, один ко многим, один ко одному.
    }
}