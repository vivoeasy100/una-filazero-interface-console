using System;
using System.Text;
using System.Threading;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.Title = "FilaZero - Sistema de Login";

        DesenharTela();
        ExecutarLogin();
    }

    static void DesenharTela()
    {
        Console.Clear();

        Console.ForegroundColor = ConsoleColor.Cyan;

        Console.WriteLine("========================================");
        Console.WriteLine();
        Console.WriteLine("            FILAZERO");
        Console.WriteLine("    Sistema Inteligente de Filas");
        Console.WriteLine();
        Console.WriteLine("========================================");
        Console.WriteLine();
        Console.WriteLine("          LOGIN DO USUÁRIO");
        Console.WriteLine();
        Console.WriteLine("========================================");

        Console.ResetColor();
        Console.WriteLine();
    }

    static void ExecutarLogin()
    {
        Console.ForegroundColor = ConsoleColor.White;

        Console.Write("📧 Email: ");
        string email = Console.ReadLine() ?? "";

        Console.Write("🔒 Senha: ");
        string senha = LerSenha();

        Console.WriteLine();
        Console.WriteLine();

        MostrarLoading();

        ValidarLogin(email, senha);
    }

    static string LerSenha()
    {
        StringBuilder senha = new StringBuilder();
        ConsoleKeyInfo tecla;

        while (true)
        {
            tecla = Console.ReadKey(true);

            if (tecla.Key == ConsoleKey.Enter)
                break;

            if (tecla.Key == ConsoleKey.Backspace && senha.Length > 0)
            {
                senha.Remove(senha.Length - 1, 1);
                Console.Write("\b \b");
            }
            else if (!char.IsControl(tecla.KeyChar))
            {
                senha.Append(tecla.KeyChar);
                Console.Write("*");
            }
        }

        return senha.ToString();
    }

    static void MostrarLoading()
    {
        Console.Write("Autenticando ");

        for (int i = 0; i < 5; i++)
        {
            Console.Write(".");
            Thread.Sleep(400);
        }

        Console.WriteLine();
    }

    static void ValidarLogin(string email, string senha)
    {
        Console.WriteLine();

        if (email == "admin@filazero.com" && senha == "123456")
        {
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("✔ Login realizado com sucesso!");
            Console.WriteLine("Bem-vindo ao sistema FilaZero.");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("✖ Falha na autenticação.");
            Console.WriteLine("Email ou senha inválidos.");
        }

        Console.ResetColor();

        Console.WriteLine();
        Console.WriteLine("Pressione qualquer tecla para finalizar...");
        Console.ReadKey();
    }
}