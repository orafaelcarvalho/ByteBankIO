using ByteBankIO;
using System.Text;

partial class Program
{
    static void LidandoComFileStreamDiretamente()
    {
        var enderecoDoArquivo = "D:\\Projetos\\ByteBankIO\\contas.txt";

        using (var fluxoDoArquivo = new FileStream(enderecoDoArquivo, FileMode.Open))
        {
            var numeroDeBytesLidos = -1;
            var buffer = new byte[1024]; // 1KB

            while (numeroDeBytesLidos != 0)
            {
                numeroDeBytesLidos = fluxoDoArquivo.Read(buffer, 0, 1024);
                //Console.WriteLine($"\n Bytes lidos: {numeroDeBytesLidos} \n");
                EscreverBuffer(buffer, numeroDeBytesLidos);
            }


        }

        //fluxoDoArquivo.Close(); // fecha arquivo

        // public override int Read(byte[] array, int offset, int count);
        // array é o buffer

        // Devoluções:
        // O número total de bytes lidos do buffer. Isso poderá ser menor que o número de
        // bytes solicitado se esse número de bytes não estiver disponível no momento, ou
        // zero, se o final do fluxo for atingido

        Console.ReadLine();
    }

    static void EscreverBuffer(byte[] buffer, int bytesLidos)
    {
        var utf8 = new UTF8Encoding();

        // public virtual string GetString(byte[] bytes, int index, int count);
        // se não usar o parametro count pra indicar até onde escrever, o método escreverá
        // todas as posições incluindo as últimas que não fora sobrepostas
        // por exemplo, se no final sobrarem bytes o sufiente pra preencher somente metade do array,
        // o restante do array permanecerá com os valores anteriores
        var texto = utf8.GetString(buffer, 0, bytesLidos);

        Console.Write(texto);

        //foreach (var meuByte in buffer)
        //{
        //    Console.Write(meuByte);
        //    Console.Write(" ");
        //}
    }

}