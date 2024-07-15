using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SimpleMVCApplicationWithCRUD.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [DisplayName("Display Order")] // because i dont want that property displayed as DisplayOrder, i want a space added inbetween
        [Range(1,100,ErrorMessage = "Display Order must between 1 and 100")] // entries outside this range will return an error
        public int DisplayOrder { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
