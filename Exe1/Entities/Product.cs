namespace Exe1;

class Product(string name, double price)
{
    protected double Price { get; } = price;
    protected string Name { get; } = name;

    public virtual string PriceTag()
    {
        return $"{Name} ${Price}";
    }
}