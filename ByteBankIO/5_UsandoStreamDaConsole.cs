using ByteBankIO;
using System.Text;

partial class Program
{
    static void UsarStreamDaEntrada()
    {
        var caminhoNovoArquivo = "D:\\Projetos\\ByteBankIO\\entradaConsole.txt";

        using (var fluxoDeEntrada = Console.OpenStandardInput())
        using (var fs = new FileStream(caminhoNovoArquivo, FileMode.Create))
        {
            var buffer = new byte[1024]; //1kb
            while (true)
            {
                var bytesLidos = fluxoDeEntrada.Read(buffer, 0, 1024);
                fs.Write(buffer, 0, bytesLidos);
                fs.Flush();
                Console.WriteLine($"Bytes lidos na console: {bytesLidos}");
            }
        }
    }
}