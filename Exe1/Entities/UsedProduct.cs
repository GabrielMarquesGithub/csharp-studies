namespace Exe1;

sealed class UsedProduct(string name, double price, DateTime manufactureDate) : Product(name, price)
{
    private readonly DateTime _manufactureDate = manufactureDate;

    public override string PriceTag()
    {
        return $"{Name} (used) ${Price} (Manufacture date: {_manufactureDate:dd/MM/yyyy})";
    }
}
