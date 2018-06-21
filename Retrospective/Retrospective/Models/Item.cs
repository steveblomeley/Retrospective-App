using SQLite;

namespace Retrospective.Models
{
    [Table("Items")]
    public class Item
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Title { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }
    }
}