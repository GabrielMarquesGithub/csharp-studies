namespace Products;

class Program
{
    static void Main(/* string[] args */)
    {
        var product1 = new Product("Notebook", 3500.00m, 5);
        var product2 = new Product("Smartphone", 2000.00m);

        System.Console.WriteLine(product1);
        System.Console.WriteLine(product2);
        System.Console.WriteLine(product2.Quantity);

        product2.Name = "T";

        System.Console.WriteLine(product2);
    }
}

