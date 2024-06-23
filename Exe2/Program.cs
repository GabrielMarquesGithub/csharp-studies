try
{
    Console.WriteLine("Entre com o caminho do arquivo: ");
    string path = Console.ReadLine() ?? throw new Exception("É necessário informar o caminho do arquivo.");

    if (!File.Exists(path))
    {
        throw new Exception("Arquivo não encontrado.");
    }
    using StreamReader sr = File.OpenText(path);

    SortedSet<string> usersName = [];

    while (!sr.EndOfStream)
    {
        string? line = sr.ReadLine();
        if (line != null)
        {
            string[] fields = line.Split(" ");
            usersName.Add(fields[0]);
        }
    }

    Console.WriteLine("Total de usuários: " + usersName.Count);
}
catch (Exception e)
{
    Console.WriteLine("Erro: " + e.Message);
}



