namespace OverrideVsNew;

public class Teacher(string name) : Person(name)
{
    public override void Introduce()
    {
        Console.WriteLine($"Hello, my name is {Name} and I am a teacher");
    }

    public new void Goodbye()
    {
        Console.WriteLine($"I {Name} say goodbye! See you in the next class!");
    }

}
