 using ByteBankIO;
using System.Text;

partial class Program
{
    static void Main(string[] args)
    {
        var enderecoDoArquivo = "D:\\Projetos\\ByteBankIO\\contas.txt";

        using (var fluxoDoArquivo = new FileStream(enderecoDoArquivo, FileMode.Open))
        {
            var leitor = new StreamReader(fluxoDoArquivo);

            //var linha = leitor.ReadLine();

            // tomar cuidado ao usar esse metódo para arquivos grandes
            //var texto = leitor.ReadToEnd();

            // lê o primeiro byte do conteúdo do arquivo
            //var numero = leitor.Read();

            // lendo linha a linha não sobrecarregando a memória do servidor da aplicação
            while (!leitor.EndOfStream) // enquanto não chega ao final do arquivo
            {
                var linha = leitor.ReadLine();
                Console.WriteLine(linha);
            }
        }

        Console.ReadLine();
    }
}