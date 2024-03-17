using cleanArchMvc.Domain.Entities;
using cleanArchMvc.Domain.Validation;

using FluentAssertions;

namespace cleanArchMvc.Domain.Test
{
    public class CategoryUnitTest
    {
        [Fact(DisplayName = "Create category with valid state")]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Category(1, "Category Name");
            action.Should()
                .NotThrow<DomainExceptionValidator>();
        }

        [Fact]
        public void CreateCategory_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Category(-1, "Category name");
            action.Should().Throw<DomainExceptionValidator>()
                .WithMessage("Invalid Id value.");
        }

        [Fact]
        public void CreateCategory_MissingValue_DomainExceptionRequiredName()
        {
            Action action = () => new Category(1, "");
            action.Should()
                .Throw<DomainExceptionValidator>();
        }

        [Fact]
        public void CreateCategory_WithNullNameValue_ValidObject()
        {
            Action action = () => new Category(1, null);
            action.Should()
                .Throw<DomainExceptionValidator>();
        }
    }
}
