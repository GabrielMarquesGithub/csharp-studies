namespace OverrideVsNew;

public class Person(string name)
{
    protected readonly string Name = name;

    public virtual void Introduce()
    {
        Console.WriteLine($"Hello, my name is {Name}");
    }

    public void Goodbye()
    {
        Console.WriteLine($"I {Name} say goodbye!");
    }
}
