namespace Exe1;

sealed class ImportedProduct(string name, double price, double customsFee) : Product(name, price)
{
    // Props
    private readonly double _customsFee = customsFee;

    // Métodos sobrescritos
    public override string PriceTag()
    {
        return $"{Name} ${TotalPrice()} (Customs fee: ${_customsFee})";
    }

    // Métodos
    public double TotalPrice()
    {
        return Price + _customsFee;
    }
}