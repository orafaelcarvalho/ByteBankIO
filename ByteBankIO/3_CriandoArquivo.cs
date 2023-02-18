using ByteBankIO;
using System.Text;

partial class Program
{
    static void CriarArquivo()
    {
        var caminhoNovoArquivo = "C:\\Projetos\\ByteBankIO\\contasExportadas.csv";

        using (var fluxoDoArquivo = new FileStream(caminhoNovoArquivo, FileMode.Create))
        {
            var contaComoString = "456, 7895, 4785.40, Rafael Carvalho";

            var enconding = Encoding.UTF8;

            var bytes = enconding.GetBytes(contaComoString);

            fluxoDoArquivo.Write(bytes, 0, bytes.Length);
        }

        Console.ReadLine();
    }

    static void CriarArquivoComWriter()
    {
        var caminhoNovoArquivo = "D:\\Projetos\\ByteBankIO\\entradaConsole.txt";

        using (var fluxoDeArquivo = new FileStream(caminhoNovoArquivo, FileMode.Create))
        using(var escritor = new StreamWriter(fluxoDeArquivo))
        {
            escritor.Write("456,7895,4785.40,Rafael Carvalho");
        }
    }

    static void TestaEscrita()
    {
        var caminhoNovoArquivo = "C:\\Projetos\\ByteBankIO\\teste.txt";

        using (var fluxoDeArquivo = new FileStream(caminhoNovoArquivo, FileMode.Create))
        using (var escritor = new StreamWriter(fluxoDeArquivo))
        {
            for (int i = 0; i < 1000000; i++)
            {
                escritor.WriteLine($"Linha {i}");
                escritor.Flush(); // Despeja o buffer para o Stream
                Console.WriteLine($"Linha {i} foi escrita no arquivo. Tecle enter...");
                Console.ReadLine();
            }
        }
    }
}