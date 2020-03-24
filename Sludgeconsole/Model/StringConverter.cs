using System;
using System.Collections.Generic;
using System.Text;

namespace Sludgeconsole.Model
{
    class StringConverter
    {



        public string RepleaceString(string toRepleace, string stringToCut)
        {
            string _newString = "";
            _newString = toRepleace.Replace(stringToCut, "");
            return (_newString);
        }

    }
}
