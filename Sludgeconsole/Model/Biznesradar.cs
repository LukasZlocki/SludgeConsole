using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sludgeconsole.Model
{
    class Biznesradar
    {
        string Url = @"https://www.biznesradar.pl/raporty-finansowe-rachunek-zyskow-i-strat/WIELTON";
        string HtmlExtracted = "";

        //ctor
        public Biznesradar()
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

            var extractedData = htmlDoc.DocumentNode.SelectNodes("//th[contains(@class, 'thq h')]");

            foreach (var extracted in extractedData)
            {
                Console.WriteLine("" + extracted.InnerText);
            }

        }

    }
}
