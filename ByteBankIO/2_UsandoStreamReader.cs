using ByteBankIO;
using System.Text;

partial class Program
{
    static void UsandoStreamReader()
    {
        var enderecoDoArquivo = "C:\\Projetos\\ByteBankIO\\contas.txt";

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
                var contaCorrente = ConverterStringParaContaCorrente(linha);

                var msg = $"{contaCorrente.Titular.Nome} : Conta número {contaCorrente.Numero} / Agência {contaCorrente.Agencia} / Saldo {contaCorrente.Saldo}";
                Console.WriteLine(msg);
            }
        }

        Console.ReadLine();
    }

    static ContaCorrente ConverterStringParaContaCorrente(string linha)
    {
        // 375,4644,2483.13,Jonatan Silva

        var campos = linha.Split(',');

        var agencia = campos[0];
        var numero = campos[1];
        var saldo = campos[2].Replace('.', ',');
        var nomeTitular = campos[3];

        var agenciaComInt = int.Parse(agencia);
        var numeroComInt = int.Parse(numero);
        var saldoComoDouble = double.Parse(saldo);

        var titular = new Cliente();
        titular.Nome = nomeTitular;

        var resultado = new ContaCorrente(agenciaComInt, numeroComInt);
        resultado.Depositar(saldoComoDouble);
        resultado.Titular = titular;

        return resultado;
    }

}