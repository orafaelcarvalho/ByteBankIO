﻿using ByteBankIO;
using System.Text;

partial class Program
{
    static void EscritaBinaria()
    {
        var caminhoNovoArquivo = "D:\\Projetos\\ByteBankIO\\contaCorrente.txt";

        using (var fs = new FileStream(caminhoNovoArquivo, FileMode.Create))
        using (var escritor = new BinaryWriter(fs))
        {
            escritor.Write(456);                //número da agência
            escritor.Write(546544);             //número da conta
            escritor.Write(4000.50);            //saldo
            escritor.Write("Rafael Carvalho");  //nome do cliente
        }
    }

    static void LeituraBinaria()
    {
        var caminhoNovoArquivo = "D:\\Projetos\\ByteBankIO\\contaCorrente.txt";

        using (var fluxoDeArquivo = new FileStream(caminhoNovoArquivo, FileMode.Open))
        using (var leitor = new BinaryReader(fluxoDeArquivo))
        {
            var agencia = leitor.ReadInt32();
            var numeroConta = leitor.ReadInt32();
            var saldo = leitor.ReadDouble();
            var titular = leitor.ReadString();

            Console.WriteLine($"{agencia}/{numeroConta} {titular} {saldo}");
        }
    }
}