using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Text;


namespace Sludgeconsole.Model
{
    class TopStock
    {
        string Url = @"https://www.topstock.pl/stock/company/KGH";
        string HtmlExtracted = "";

        public TopStock()
        {
            GetHtmlTopStockAsync1(ref HtmlExtracted, Url);  
        }


        /// <summary>
        /// Extracting data from TopStock
        /// </summary>
        /// <param name="htmlExtracted">html data ref to extract</param>
        /// <param name="url"></param>
        private static void GetHtmlTopStockAsync1(ref string htmlExtracted, string url)
        {
            HtmlWeb web2 = new HtmlWeb();
            var htmlDoc2 = web2.Load(url);

           // var htmlBody2 = htmlDoc2.DocumentNode.SelectNodes("//*[@id='stock_company_financial']/div[1]/table[2]/tbody/tr[10]/td[2]");
            var htmlBody2 = htmlDoc2.DocumentNode.SelectSingleNode("//div");
            Console.WriteLine(htmlBody2.OuterHtml);
           
            /*
            foreach (var dane in htmlBody2)
            {
                Console.WriteLine(dane.OuterHtml);
            }
            */
            Console.ReadKey();
        }

    }
}
