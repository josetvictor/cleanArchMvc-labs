using cleanArchMvc.Domain.Validation;

namespace cleanArchMvc.Domain.Entities
{
    public sealed class Product
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set; }

        public Product(string name, string description, decimal price, int stock, string image)
        {
            ValidateDomain(name, description, price, stock, image);
        }

        public Product(int id, string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidator.When(id < 0, "Invalid Id value.");
            Id = id;
            ValidateDomain(name, description, price, stock, image);
        }

        public void Update(string name, string description, decimal price, int stock, string image, int categoryId)
        {
            ValidateDomain(name, description, price, stock, image);
            CategoryId = categoryId;
        }

        public void ValidateDomain(string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidator.When(string.IsNullOrWhiteSpace(name), "Invalid name. Name is required.");
            DomainExceptionValidator.When(name.Length < 3 , "Invalid name, too short, minimum 3 charecters.");
            DomainExceptionValidator.When(string.IsNullOrWhiteSpace(description), "Invalid description. Description is required.");
            DomainExceptionValidator.When(description.Length < 10, "Invalid description, too short, minimum 10 charecters.");
            DomainExceptionValidator.When(stock  < 0, "Invalid stock value.");
            DomainExceptionValidator.When(price < 0, "Invalid price value");
            DomainExceptionValidator.When(image.Length > 250, "Invalid image name, too long, maximum 250 characters.");

            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
        }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
