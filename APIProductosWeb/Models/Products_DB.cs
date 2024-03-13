using System.ComponentModel.DataAnnotations.Schema;

namespace APIProductosWeb.Models
{
    public class Products_DB
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal? Price { get; set; }

        public int CategoryID { get; set; }
        [ForeignKey(nameof(CategoryID))]
        public virtual Categories_DB? Category { get; set; }

    }
}
