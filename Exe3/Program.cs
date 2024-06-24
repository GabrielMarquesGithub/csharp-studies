using System.Text;

string resultado = ProcessaObjeto(1, null, "teste", 4, 5);
Console.WriteLine(resultado);

static string ProcessaObjeto(params object[] objetos)
{
    StringBuilder resultado = new();
    foreach (object objeto in objetos)
    {
        if (objeto == null)
        {
            resultado.AppendLine("Objeto nulo");
            continue;
        }
        resultado.AppendLine(objeto.GetType() + ": " + objeto);
    }

    return resultado.ToString();
}
