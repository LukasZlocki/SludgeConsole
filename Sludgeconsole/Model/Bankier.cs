using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sludgeconsole.Model
{
    class Bankier
    {
        string Url = @"https://www.bankier.pl/gielda/notowania/akcje/KRUK/wyniki-finansowe/skonsolidowany/roczny/standardowy/1";
        string HtmlExtracted = "";
        int PozycjaTabeli = 1;

        public Bankier()
        {
            GetHtmlAsync1(ref HtmlExtracted, Url, PozycjaTabeli);
            Console.ReadKey();
        }

        // wyciagam konkretne dane dla danego roku
        private static void GetHtmlAsync1(ref string htmlExtracted, string url, int pozycjaTabela)
        {
            int _counter = 0;

            HtmlWeb web = new HtmlWeb();
            var htmlDoc = web.Load(url);

            var extractedData = htmlDoc.DocumentNode.SelectNodes("//td[contains(@class, 'textAlignRight')]");

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
        }


    }
}
