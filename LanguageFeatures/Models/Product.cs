namespace LanguageFeatures.Models
{
    public class Product
    {
        private string name;
        public string Name{ get
            { return name + ProductId; }
                set
                    { name = value; } }
        public int ProductId { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        
    }
}