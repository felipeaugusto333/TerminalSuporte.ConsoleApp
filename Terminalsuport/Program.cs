using System;
using System.Threading;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        while (true)
        {
            Tela();

            Console.Write("\nDigite um comando (ex: PING, HELP): ");
            Console.ForegroundColor = ConsoleColor.White;
            string comando = Console.ReadLine().ToUpper();

            if (comando == "PING")
                Ping();
            else if (comando == "RESET")
                Reiniciar();
            else if (comando == "FORMAT")
                Formatar();
            else if (comando == "HELP" || comando == "?")
                Help();
            else if (comando == "SAIR")
                break;
            else
                Erro($"O comando '{comando}' não foi reconhecido.\nUse 'HELP' para ver a lista de comandos disponíveis.");
        }
    }

    static void Tela()
    {
        Console.Clear();

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("=== TERMINAL DE DIAGNÓSTICO v2.0 ===\n");

        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("[PING]   - Testar conexão com um servidor");
        Console.WriteLine("[RESET]  - Reiniciar o servidor (ação crítica)");
        Console.WriteLine("[FORMAT] - Formatar unidade (apaga todos os dados)");
        Console.WriteLine("[HELP]   - Exibir ajuda");
        Console.WriteLine("[SAIR]   - Encerrar o sistema");

        Console.ResetColor();
    }

    static void Ping()
    {
        Console.Clear();

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("=== DIAGNÓSTICO DE REDE ===");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("Informe o endereço IP no formato: xxx.xxx.xxx.xxx");
        Console.WriteLine("Exemplo válido: 192.168.0.1\n");
        Console.ResetColor();

        Console.Write("Digite o IP de destino: ");
        string ip = Console.ReadLine();

        if (!Regex.IsMatch(ip, @"^\d{1,3}(\.\d{1,3}){3}$"))
        {
            Erro("O valor informado não corresponde a um IP válido.\nUse apenas números e pontos no formato: xxx.xxx.xxx.xxx");
            return;
        }

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("\n[IHC] Enviando pacotes para o endereço informado");
        Console.ResetColor();

        for (int i = 0; i < 3; i++)
        {
            Thread.Sleep(500);
            Console.Write(".");
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\n[IHC] Resposta recebida com sucesso!");
        Console.WriteLine("Latência aproximada: 15ms");
        Console.ResetColor();

        Pausa();
    }

    static void Reiniciar()
    {
        Console.Clear();

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("[AVISO] Você está prestes a reiniciar o servidor.");
        Console.WriteLine("Essa ação pode interromper serviços temporariamente.\n");
        Console.ResetColor();

        Console.Write("Deseja continuar? Digite 'S' para confirmar ou 'N' para cancelar: ");
        string resp = Console.ReadLine().ToUpper();

        if (resp == "S")
        {
            Processando("[IHC] Reiniciando servidor");
            Sucesso("O servidor foi reiniciado com sucesso.");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\n[IHC] Operação cancelada pelo usuário.");
            Console.ResetColor();
            Pausa();
        }
    }

    static void Formatar()
    {
        Console.Clear();

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("=======================================");
        Console.WriteLine("           ⚠️  ALERTA CRÍTICO ⚠️");
        Console.WriteLine("=======================================");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\nVocê está prestes a FORMATAR a unidade.");
        Console.WriteLine("Todos os arquivos serão permanentemente apagados.");
        Console.WriteLine("Essa ação NÃO pode ser desfeita.\n");
        Console.ResetColor();

        Console.WriteLine("Para confirmar, digite exatamente a palavra abaixo:");
        
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("CONFIRMAR");
        Console.ResetColor();

        Console.Write("\nEntrada: ");
        string resp = Console.ReadLine();

        if (resp == "CONFIRMAR")
        {
            Processando("[IHC] Formatando unidade");
            Sucesso("A unidade foi formatada com sucesso.");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\n[IHC] Operação cancelada. Nenhuma alteração foi realizada.");
            Console.ResetColor();
            Pausa();
        }
    }

    static void Help()
    {
        Console.Clear();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("=== CENTRAL DE AJUDA ===\n");

        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine("PING   → Testa a conexão com um endereço IP informado.");
        Console.WriteLine("RESET  → Reinicia o servidor (pode causar indisponibilidade).");
        Console.WriteLine("FORMAT → Formata a unidade e apaga todos os dados.");
        Console.WriteLine("HELP   → Exibe esta tela de ajuda.");
        Console.WriteLine("SAIR   → Encerra o sistema.\n");

        Console.WriteLine("Dica: Você pode digitar os comandos em maiúsculo ou minúsculo.");
        Console.ResetColor();

        Pausa();
    }

    static void Erro(string msg)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"\nERRO:\n{msg}");
        Console.ResetColor();
        Pausa();
    }

    static void Sucesso(string msg)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\nSUCESSO:\n{msg}");
        Console.ResetColor();
        Pausa();
    }

    static void Processando(string msg)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write($"\n{msg}");
        Console.ResetColor();

        for (int i = 0; i < 3; i++)
        {
            Thread.Sleep(500);
            Console.Write(".");
        }

        Console.WriteLine();
    }

    static void Pausa()
    {
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("\nPressione qualquer tecla para continuar...");
        Console.ResetColor();
        Console.ReadKey();
    }
}
