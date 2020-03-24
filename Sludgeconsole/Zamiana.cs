using System;
using System.Collections.Generic;
using System.Text;

namespace Sludgeconsole
{
    class Zamiana
    {

        public string ZamianaNaLiczbe(string doZamiany)
        {
            string _newString = "";
            _newString = doZamiany.Replace("&nbsp;", "");
            _newString = _newString.Replace(",", "");

            return (_newString);
        }



    }
}
