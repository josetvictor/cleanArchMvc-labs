using cleanArchMvc.Domain.Entities;
using cleanArchMvc.Domain.Validation;

using FluentAssertions;

namespace cleanArchMvc.Domain.Test
{
    public class ProductUnitTest
    {
        [Fact]
        public void CreateProduct_WithParameters_ResultObjectValidState()
        {
            Action action = () => new Product(1, "Product Name", "Product Description exemple", 9.99m, 99, "productImage.jpg");
            action.Should().NotThrow<DomainExceptionValidator>();
        }

        [Fact]
        public void CreateProduct_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Product(-1, "Product Name", "Product Description exemple", 9.99m, 99, "productImage.jpg");
            action.Should().Throw<DomainExceptionValidator>()
                           .WithMessage("Invalid Id value.");
        }

        [Fact]
        public void CreateProduct_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Product(1, "Pr", "Product Description exemple", 9.99m, 99, "productImage.jpg");
            action.Should().Throw<DomainExceptionValidator>()
                           .WithMessage("Invalid name, too short, minimum 3 charecters.");
        }
    }
}
