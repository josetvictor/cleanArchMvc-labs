
using cleanArchMvc.Domain.Validation;

namespace cleanArchMvc.Domain.Entities
{
    public sealed class Category
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public Category(string name)
        {
            ValidateDomain(name);
        }

        public Category(int id, string name)
        {
            DomainExceptionValidator.When(id < 0, "Invalid Id value.");
            Id = id;
            ValidateDomain(name);
        }

        public void Update(string name)
        {
            ValidateDomain(name);
        }

        public ICollection<Product> Products { get; set; }

        private void ValidateDomain(string name)
        {
            DomainExceptionValidator.When(string.IsNullOrEmpty(name), "Invalid name. Name is required.");
            DomainExceptionValidator.When(name.Length < 3, "Invalid name, too short, minimum 3 charecters.");

            Name = name;
        }
    }
}
