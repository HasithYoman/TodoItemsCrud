using System.ComponentModel.DataAnnotations;

namespace BackEnd.Entities
{
    public class itemEntity
    {
        [Key]
        public long Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }

    }
}
