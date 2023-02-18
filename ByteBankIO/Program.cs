 using ByteBankIO;
using System.Text;
using System.Xml;

partial class Program
{
    static void Main(string[] args)
    {
        //CriarArquivo(); 
        //CriarArquivoComWriter();
        //TestaEscrita();

        //EscritaBinaria();
        //LeituraBinaria();

        //UsarStreamDaEntrada();

        var linhas = File.ReadAllLines("D:\\Projetos\\ByteBankIO\\contas.txt");
        Console.WriteLine(linhas.Length);

        foreach (var linha in linhas)
        {
            Console.WriteLine(linha);
        }

        var byteArquivos = File.ReadAllBytes("D:\\Projetos\\ByteBankIO\\contas.txt");
        Console.WriteLine($"Arquivo contas.txt possui {byteArquivos.Length} bytes");

        File.WriteAllText("escrevendoComAClasseFile.txt", "Testando file.WriteAllText");

        Console.WriteLine("Aplicação finalizada...");
        Console.ReadLine();
    }
}