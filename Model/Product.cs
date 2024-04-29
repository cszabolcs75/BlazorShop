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

        public async Task<Result<Product>> Validate()
        {
            if (string.IsNullOrEmpty(Name))
            {
                return Result<Product>.Fail("Product name cannot be null or empty");
            }
            if (Price <= 0)
            {
                return Result<Product>.Fail("Price must be greater than zero");

            }
            if (ManufactureDate == default(DateTime))
            {
                return Result<Product>.Fail("Manufacture date must be provided");
            }
            return null;
        }
    }
}
