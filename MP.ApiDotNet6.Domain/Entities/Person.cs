﻿using MP.ApiDotNet6.Domain.Validations;

namespace MP.ApiDotNet6.Domain.Entities;
internal sealed class Person
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Document { get; private set; }
    public string Phone { get; private set; }

    public Person(string document, string name, string phone)
    {
        Validation(document, name, phone);
    }

    public Person(int id, string document, string name, string phone)
    {
        DomainValidationException.When(id < 0, "Id inválido: deve ser maior que 0!");
        Id = id;
        Validation(document, name, phone);
    }

    private void Validation(string document, string name, string phone)
    {
        DomainValidationException.When(string.IsNullOrWhiteSpace(name), "Nome deve ser informado!");
        DomainValidationException.When(string.IsNullOrWhiteSpace(document), "Documento deve ser informado!");
        DomainValidationException.When(string.IsNullOrWhiteSpace(phone), "Celular deve ser informado!");

        Name = name;
        Document = document;
        Phone = phone;
    }
}
