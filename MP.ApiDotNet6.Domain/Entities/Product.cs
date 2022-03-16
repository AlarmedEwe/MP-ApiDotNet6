using MP.ApiDotNet6.Domain.Validations;

namespace MP.ApiDotNet6.Domain.Entities;
internal sealed class Product
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string CodErp { get; private set; }
    public decimal Price { get; private set; }

    public Product(string name, string codErp, decimal price)
    {
        Validation(name, codErp, price);
    }

    public Product(int id, string name, string codErp, decimal price)
    {
        DomainValidationException.When(id < 0, "Id inválido: deve ser maior que zero!");
        Id = id;
        Validation(name, codErp, price);
    }

    public void Validation(string name, string codErp, decimal price)
    {
        DomainValidationException.When(string.IsNullOrWhiteSpace(name), "Nome deve ser informado!");
        DomainValidationException.When(string.IsNullOrWhiteSpace(codErp), "Código ERP deve ser informado!");
        DomainValidationException.When(price < 0, "O valor deve ser maior do que zero!");

        Name = name;
        CodErp = codErp;
        Price = price;
    }
}
