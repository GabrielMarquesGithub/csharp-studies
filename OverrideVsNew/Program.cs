using OverrideVsNew;

Teacher teacher = new("John");

Console.WriteLine("Override vs New");
Console.WriteLine("Override");
MakeIntroduction(teacher);

Console.WriteLine("New");
// Não é possível o polimorfismo com o método Goodbye, pois o método da classe base não é virtual
MakeGoodbye(teacher);

static void MakeIntroduction(Person person)
{
    person.Introduce();
}

static void MakeGoodbye(Person person)
{
    person.Goodbye();
}
