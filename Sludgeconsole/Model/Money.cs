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


        private static void GetHtmlStrefainwestorowAsync1(ref string htmlExtracted, string url)
        {
            HtmlWeb web = new HtmlWeb();
            var htmlDoc = web.Load(url);

            // var htmlBody2 = htmlDoc2.DocumentNode.SelectNodes("//*[@id='stock_company_financial']/div[1]/table[2]/tbody/tr[10]/td[2]");
            var htmlBody = htmlDoc.DocumentNode.SelectSingleNode("//tbody");
            Console.WriteLine(htmlBody.OuterHtml);

            /*
            foreach (var dane in htmlBody2)
            {
                Console.WriteLine(dane.OuterHtml);
            }
            */
        }

    }
}
