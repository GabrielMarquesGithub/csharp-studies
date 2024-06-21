using Exe1;

int productsQuantity;
bool work;

do
{
    Console.WriteLine("Enter the number of products: ");
    work = int.TryParse(Console.ReadLine(), out productsQuantity);
    if (!work)
    {
        Console.WriteLine("Invalid value. Please, try again.");
    }
} while (!work);


List<Product> products = [];

for (int i = 0; i < productsQuantity; i++)
{
    Console.WriteLine($"Product #{i + 1} data:");
    Console.Write("Common, used or imported (c/u/i)? ");
    char productType = char.Parse(Console.ReadLine().ToLower());
    Console.Write("Name: ");
    string name = Console.ReadLine();
    Console.Write("Price: ");
    double price = double.Parse(Console.ReadLine());

    switch (productType)
    {
        case 'c':
            products.Add(new Product(name, price));
            break;
        case 'u':
            Console.Write("Manufacture date (DD/MM/YYYY): ");
            DateTime manufactureDate = DateTime.Parse(Console.ReadLine());
            products.Add(new UsedProduct(name, price, manufactureDate));
            break;
        case 'i':
            Console.Write("Customs fee: ");
            double customsFee = double.Parse(Console.ReadLine());
            products.Add(new ImportedProduct(name, price, customsFee));
            break;
        default:
            Console.WriteLine("Invalid value. Please, try again.");
            i--;
            break;
    }
}

Console.WriteLine("\nPRICE TAGS:");
foreach (Product product in products)
{
    Console.WriteLine(product.PriceTag());
}

