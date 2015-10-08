using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }
        public double Quantity { get; set; }

        public int CategoryId { get; set; }
    }
}
