
List<Task> tarefas = new List<Task>();
tarefas.Add(tarefa1());
tarefas.Add(tarefa2());
tarefas.Add(tarefa3());

//await Task.WhenAll(tarefas);
//await Task.WhenAny(tarefas);

Console.WriteLine("Todas iniciadas");
Console.WriteLine("Vou uma finalizar");

await tarefas[^1];

Console.WriteLine("Tarefa finalizada");
await Task.WhenAll(tarefas);

static async Task tarefa1()
{
    Console.WriteLine("Tarefa 1 iniciada");
    await Task.Delay(3000);
    Console.WriteLine("Tarefa 1 finalizada");
}

static async Task tarefa2()
{
    Console.WriteLine("Tarefa 2 iniciada");
    await Task.Delay(4000);
    Console.WriteLine("Tarefa 2 finalizada");
}

static async Task tarefa3()
{
    Console.WriteLine("Tarefa 3 iniciada");
    await Task.Delay(2000);
    Console.WriteLine("Tarefa 3 finalizada");
}

