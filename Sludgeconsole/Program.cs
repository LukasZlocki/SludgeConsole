using HtmlAgilityPack;
using System;
using System.Linq;
using System.Net.Http;

using System.IO;
using Sludgeconsole.Model;

namespace Sludgeconsole
{
    class Program
    {

        static void Main(string[] args)
        {
            string UserKey = "";

            UserKey = Menu();

            switch (UserKey)
            {
                case "E":
                    // Exit
                    Environment.Exit(0);
                    break;

                case "A":
                    // Todo : code Topstock();
                    TopStock TopStock = new TopStock();
                    break;

                case "B":
                    //Todo: code code Strefainwestorow();
                    Strefainwestorow StrefaInvestorow = new Strefainwestorow();
                    break;

                case "C":
                    // Todo: code code Bankier();
                    Bankier Bankier = new Bankier();
                    break;

                case "D":
                    // Todo: code code Bankier();
                    Money Money = new Money();
                    break;

                case "F":
                    // Todo: code code Bankier();
                    Biznesradar Biznesradar = new Biznesradar();
                    break;
            }
        }

        /// <summary>
        /// Main Menu
        /// </summary>
        /// <returns></returns>
        private static string Menu()
        {
            string _userKey = "";

            Console.Clear();
            Console.WriteLine("Testing of grabbing methods on www");
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine("MENU SludgeConsole");
            Console.WriteLine(" ");
            Console.WriteLine("[A] TopStock extraction");
            Console.WriteLine("[B] Strefainwestorow extraction");
            Console.WriteLine("[C] Bankier extraction");
            Console.WriteLine("[D] Money extraction");
            Console.WriteLine("[F] Biznesradar extraction");
            Console.WriteLine(" ");
            Console.WriteLine("[E] Exit");
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.Write("-->> ");
            _userKey = Console.ReadLine();
            Console.Clear();

            return _userKey;
        }

    

    }
}
