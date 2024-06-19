namespace Products;

public class Product
{
    private string _name;
    private readonly decimal _price;
    public int Quantity { get; private set; }

    public Product(string name, decimal price, int quantity)
    {
        _name = name;
        _price = price;
        Quantity = quantity;
    }

    public Product(string name, decimal price)
    {
        _name = name;
        _price = price;
        Quantity = 0;
    }

    public override string ToString()
    {
        return $"Nome: {_name}, Preço: {_price}, Quantidade: {Quantity}";
    }

    public string Name
    {
        set
        {
            if (value != null && value.Length > 1)
            {
                _name = value;
            }
            else
            {
                System.Console.WriteLine("Nome inválido!");
            }
        }
    }
}
