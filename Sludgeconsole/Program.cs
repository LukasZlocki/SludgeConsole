using HtmlAgilityPack;
using System;
using System.Linq;
using System.Net.Http;

using System.IO;

namespace Sludgeconsole
{
    class Program
    {

        static void Main(string[] args)
        {
            string UserKey = "";

            string Url = @"https://www.bankier.pl/gielda/notowania/akcje/KRUK/wyniki-finansowe/skonsolidowany/roczny/standardowy/1";
            //string Url = @"https://www.topstock.pl/stock/company/KGH";
            string HtmlExtracted = "";
            int PozycjaTabela = 1;



            UserKey = Menu();

            switch (UserKey)
            {
                case "E":
                    Environment.Exit(0);
                    break;

                case "A":
                    // Todo : code Topstock();
                    break;

                case "B":
                    //Todo: code code Strefainwestorow();
                    break;

                case "C":
                    // Todo: code code Bankier();
                    break;
            }


            // GetHtmlAsync1(ref HtmlExtracted, Url);
            GetHtmlAsync3(ref HtmlExtracted, Url, PozycjaTabela);
            Console.WriteLine(HtmlExtracted);

            Console.ReadKey();
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
            Console.WriteLine(" ");
            Console.WriteLine("[E] Exit");
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.Write("-->> ");
            _userKey = Console.ReadLine();
            Console.Clear();

            return _userKey;
        }


        #region Dane dla spolek TopStock
        private static void GetHtmlAsync2(ref string htmlExtracted, string url)
        {
            HtmlWeb web2 = new HtmlWeb();
            var htmlDoc2 = web2.Load(url);

            var htmlBody2 = htmlDoc2.DocumentNode.SelectNodes("//*[@id='stock_company_financial']/div[1]/table[2]/tbody/tr[10]/td[2]");
            // var htmlBody2 = htmlDoc2.DocumentNode.SelectSingleNode("//div");
            // Console.WriteLine(htmlBody2.OuterHtml);
            foreach (var dane in htmlBody2)
            {
                Console.WriteLine(dane.OuterHtml);
            }
            Console.ReadKey();
        }
        #endregion


        #region Dane dla spolek z strefainwestorow
        // wyciagam najwazniejsze dane , tam gdzie sa dane spolek
        private static void GetHtmlAsync1(ref string htmlExtracted, string url)
        {

            #region Wyciagniecie lat za ktore jest analiza
            HtmlWeb web0 = new HtmlWeb();
            var htmlDoc0 = web0.Load(url);

            //var htmlBody0 = htmlDoc0.DocumentNode.SelectNodes("//strong");
            var htmlBody0 = htmlDoc0.DocumentNode.SelectNodes("//th[contains(@class, 'textAlignCenter')]");

            foreach (var dane in htmlBody0)
            {
                Console.WriteLine("***** Zakres Lat ***");
                Console.WriteLine(dane.InnerText);
            }
            Console.ReadKey();
            #endregion



            #region Wyciagniecie podstawowych danych
            HtmlWeb web1 = new HtmlWeb();
            var htmlDoc1 = web1.Load(url);

            var htmlBody1 = htmlDoc1.DocumentNode.SelectSingleNode("//tbody");

            Console.WriteLine(htmlBody1.OuterHtml);

            Console.ReadKey();
            #endregion


            #region wyciagniecie konkretnych danych liczbowych z tabeli
            HtmlWeb web2 = new HtmlWeb();
            var htmlDoc2 = web2.Load(url);

            var extractedData = htmlDoc2.DocumentNode.SelectNodes("//td[contains(@class, 'textAlignRight')]");

            Console.WriteLine("************");
            foreach (var informacja in extractedData)
            {
                string _finalnaLiczba = "";
                string _tempString = "";

                //Console.WriteLine(informacja.OuterHtml);
                Console.WriteLine(informacja.InnerText);
                _tempString = Convert.ToString(informacja.InnerHtml);

                Zamiana zamiana = new Zamiana();
                _finalnaLiczba = zamiana.ZamianaNaLiczbe(_tempString);
                Console.WriteLine("Po Trimie ->>" + _finalnaLiczba);

            }

            Console.ReadKey();
            #endregion           
        }
        #endregion


        #region Wyciagniecie danych z konkretnej tabeli
        // wyciagam konkretne dane dla danego roku
        private static void GetHtmlAsync3(ref string htmlExtracted, string Url, int pozycjaTabela)
        {
            int _counter = 0;

            HtmlWeb web2 = new HtmlWeb();
            var htmlDoc2 = web2.Load(Url);

            var extractedData = htmlDoc2.DocumentNode.SelectNodes("//td[contains(@class, 'textAlignRight')]");

            Console.WriteLine("Extrakcja danych z tabeli finansowej");
            foreach (var daneFin in extractedData)
            {

                //  Console.WriteLine("***** dane finansowe ***");
                //  Console.WriteLine(daneFin.InnerText);

                if (_counter == pozycjaTabela)
                {
                    string _zamienione = "";

                    Zamiana zamiana = new Zamiana();
                    _zamienione = zamiana.ZamianaNaLiczbe(daneFin.InnerText);

                    Console.WriteLine("Wyciagniete dane ------------------>> " + _zamienione);
                }

                _counter++;
                if (_counter == 4) { _counter = 0; }

            }
            Console.ReadKey();
        }
        #endregion


    }
}
