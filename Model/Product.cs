namespace Model
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime ManufactureDate { get; set; }
        public bool IsAvailable { get; set; }
        public int StockCount { get; set; }

        public void Validate()
        {
            if (string.IsNullOrEmpty(Name))
                throw new ArgumentException("Product name cannot be null or empty");
            if (Price <= 0)
                throw new ArgumentException("Price must be greater than zero");
            if (ManufactureDate == default(DateTime))
                throw new ArgumentException("Manufacture date must be provided");
        }
    }
}
