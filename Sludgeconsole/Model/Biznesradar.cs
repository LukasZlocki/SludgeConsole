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
            GetHtmlbiznesradarAsync1(ref HtmlExtracted, Url);
            Console.ReadKey();
        }

        /// <summary>
        /// Wyciaga poszczegolne dane z tabeli fkmtpn-6 exZzot
        /// </summary>
        /// <param name="htmlExtracted"></param>
        /// <param name="url"></param>
        private static void GetHtmlbiznesradarAsync1(ref string htmlExtracted, string url)
        {
            HtmlWeb web = new HtmlWeb();
            var htmlDoc = web.Load(url);

            /* OK do wyluskiwania danych z tabeli
            var extractedData = htmlDoc.DocumentNode.SelectNodes("//tr[contains(@data-field, 'IncomeCostOfSales')]/td/span");
            */

            /* OK do wyluskiwania lat z tabeli
            var extractedData = htmlDoc.DocumentNode.SelectNodes("//th[contains(@class, 'thq h')]");
            */

            var extractedData = htmlDoc.DocumentNode.SelectNodes("//tr[contains(@class, 'bold')]/td/span");

            int i = 0;
            string convertedString = "";
            foreach (var extracted in extractedData)
            {
                Console.WriteLine("" + extracted.InnerText);
                StringConverter stringConvert = new StringConverter();
                convertedString = stringConvert.RepleaceString(extracted.InnerText,"\t");
                convertedString = stringConvert.RepleaceString(convertedString, "\n");
                /*
                 try
                 {
                     i = Convert.ToInt32(convertedString);
                     Console.WriteLine("" + i);
                 }
                 catch
                 {
                     Console.WriteLine("Error !" );
                 }
                 */
            }
        }


    }
}
