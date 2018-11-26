using System;
using BLL.Interface.Entities;
using BLL.Interface.Services;
using DependencyResolver;
using Ninject;

namespace ConsolePL
{
    class Program
    {
        private static readonly IKernel resolver;

        static Program()
        {
            resolver = new StandardKernel();
            resolver.ConfigurateResolver();
        }

        static void Main(string[] args)
        {
            IBankService service = resolver.Get<IBankService>();
            IAccountNumberGenerator accGenerator = resolver.Get<IAccountNumberGenerator>();
            IHolderNumberGenerator holGenerator = resolver.Get<IHolderNumberGenerator>();

            while (true)
            {
                StartMenu();

                ConsoleKeyInfo key = Console.ReadKey();

                switch (key.KeyChar)
                {
                    case '1':
                        Console.WriteLine();
                        int temp = 0;
                        foreach (var item in service.GetAllAccounts())
                        {
                            Console.WriteLine(item.ToString());
                            temp++;
                        }

                        if (temp == 0)
                        {
                            Console.WriteLine("List is empty.");
                        }
                        Console.WriteLine();
                        break;

                    case '2':
                        Console.WriteLine("\nInput first name, last name and email:");
                        var account = new AccountEntity(
                            new HolderEntity(
                                Console.ReadLine(),
                                Console.ReadLine(),
                                Console.ReadLine(),
                                holGenerator
                            ), accGenerator
                        );
                        service.OpenAccount(account);
                        Console.WriteLine();
                        break;

                    case '3':
                        Console.WriteLine();
                        Console.WriteLine("Input account number:");
                        service.CloseAccount(
                            Console.ReadLine());
                        Console.WriteLine();
                        break;

                    case '4':
                        Console.WriteLine();
                        Console.WriteLine("Input account number and amount of money:");
                        service.Withdraw(
                            Console.ReadLine(),
                            decimal.Parse(Console.ReadLine()));
                        Console.WriteLine();
                        break;

                    case '5':
                        Console.WriteLine();
                        Console.WriteLine("Input account number and amount of money:");
                        service.Deposit(
                            Console.ReadLine(),
                            decimal.Parse(Console.ReadLine()));
                        Console.WriteLine();
                        break;

                    case '6':
                        Console.WriteLine();
                        Console.WriteLine(
                            "Input account number of sender, account number of recipient and amount of money:");
                        service.Transfer(
                            Console.ReadLine(),
                            Console.ReadLine(),
                            decimal.Parse(Console.ReadLine()));
                        Console.WriteLine();
                        break;

                    case '7':
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("\nInvalid input.\n");
                        break;

                }
            } 
        }

        public static void StartMenu()
        {
            Console.WriteLine("MENU");
            Console.WriteLine("1. List of accounts");
            Console.WriteLine("2. Add new account");
            Console.WriteLine("3. Remove account");
            Console.WriteLine("4. Withdraw money");
            Console.WriteLine("5. Deposit money");
            Console.WriteLine("6. Transfer money");
            Console.WriteLine("7. Exit\n");
        }
    }
}
