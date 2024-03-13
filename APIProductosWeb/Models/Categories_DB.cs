using System.ComponentModel.DataAnnotations;

namespace APIProductosWeb.Models
{
    public class Categories_DB
    {
        [Key]
        public int CategoryID { get; set; }
        public string? CategoryName { get; set; }

    }
}
