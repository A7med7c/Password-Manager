using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFundamentals.ConsoleApp.projects.password_manager
{
    public class APPS
    {
        private static readonly Dictionary<string, string> _passwoerdEntries = new();


        public static void Run(string[] args)
    {
            ReadPaswords();

            while (true)
            {
                Console.WriteLine("please selsect an option :");
                Console.WriteLine("1. list all passwords");
                Console.WriteLine("2. Add/change passeord");
                Console.WriteLine("3. Get passowrd");
                Console.WriteLine("4. Delete password");
                var SelectedOption = Console.ReadLine();
                if (SelectedOption == "1")
                    ListAllPasswords();
                else if (SelectedOption == "2")
                    AddOrChangePassword();
                else if (SelectedOption == "3")
                    GetPassword();
                else if (SelectedOption == "4")
                    DeletePassword();
                else
                    Console.WriteLine("Invalid Option");
                Console.WriteLine( "=================================");
            }
    }

     

        private static void ListAllPasswords()
        {
            foreach (var entry in _passwoerdEntries)
                Console.WriteLine($"{entry.Key} = {entry.Value} ");
             
        }
        private static void AddOrChangePassword()
        {
            Console.WriteLine("enter website name ");
            var appName = Console.ReadLine();
            Console.WriteLine("enter your password");
            var password = Console.ReadLine();
            if (_passwoerdEntries.ContainsKey(appName))
                _passwoerdEntries[appName] = password;
            else 
                _passwoerdEntries.Add(appName, password);
            SavePaswords();
        }
        private static void GetPassword()
        {
            Console.WriteLine("enter website name ");
            var appName = Console.ReadLine();
            if (_passwoerdEntries.ContainsKey(appName))
                Console.WriteLine($"your password is {_passwoerdEntries[appName]} ");
            else
                Console.WriteLine("password is not found ");
        }

        private static void DeletePassword()
        {
            Console.WriteLine("enter website name ");
            var appName = Console.ReadLine();
            if (_passwoerdEntries.ContainsKey(appName))
                _passwoerdEntries.Remove(appName);
            else
                Console.WriteLine("password is not found ");
            SavePaswords();
        }
        private static void ReadPaswords()
        {
            if (File.Exists("passwords.txt"))
            {
                var PasswordLines = File.ReadAllText("passwords.txt");
                foreach (var Line in PasswordLines.Split(Environment.NewLine))
                {
                    if (!string.IsNullOrEmpty(Line))
                    {
                        var equalIndex = Line.IndexOf('=');
                        var appName = Line.Substring(0, equalIndex);
                        var password = Line.Substring(equalIndex + 1);
                        _passwoerdEntries.Add(appName, EncryptingandDecrypying.Decrypt(password));
                    }
                }
            }

        }
        private static void SavePaswords()
        {
            var sb = new StringBuilder();
            foreach (var entry in _passwoerdEntries)
            {
                sb.Append($"{entry.Key} = {EncryptingandDecrypying.Encrypt(entry.Value)}");
                File.WriteAllText("password.txt", sb.ToString());
            }
        }


    }
}
