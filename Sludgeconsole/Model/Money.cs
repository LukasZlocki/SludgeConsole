using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sludgeconsole.Model
{
    class Money
    {
        string Url = @"https://www.money.pl/gielda/spolki-gpw/PLWELTN00012,finanse.html";
        string HtmlExtracted = "";

        public Money()
        {
            GetHtmlStrefainwestorowAsync1(ref HtmlExtracted, Url);
            Console.ReadKey();
        }

        /// <summary>
        /// Wyciaga poszczegolne dane z tabeli fkmtpn-6 exZzot
        /// </summary>
        /// <param name="htmlExtracted"></param>
        /// <param name="url"></param>
        private static void GetHtmlStrefainwestorowAsync1(ref string htmlExtracted, string url)
        {
            HtmlWeb web = new HtmlWeb();
            var htmlDoc = web.Load(url);

            var extractedData = htmlDoc.DocumentNode.SelectNodes("//td[contains(@class, 'fkmtpn-6 exZzot')]");

            foreach( var extracted in extractedData)
            {
                Console.WriteLine("" + extracted.InnerText);
            }

        }

    }
}
