using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class TransfusionCenter
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        [Range(0, 5)]
        public float Rating { get; set; }

    }
}
