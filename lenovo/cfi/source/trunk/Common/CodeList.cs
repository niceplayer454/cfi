using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lenovo.CFI.Common
{
    public class CodeList
    {
        public CodeList(string text)
        {
            this.text = text;
        }

        private string text;
        private string[] list;

        public string Text
        {
            get 
            {
                return text; 
            }
            set
            {
                this.list = null;
                this.text = value;
            }
        }

        public string[] List
        {
            get 
            {
                if (this.list == null)
                {
                    this.list = SplitStringToList(this.text);
                }

                return list; 
            }
        }


        public static string ConvertListToString(params string[] list)
        {
            Array.Sort(list);
            string text = "";
            foreach (string item in list)
            {
                if (text.Length > 0) text += SEPERATOR_STR;
                text += item;
            }
            return text;
        }

        public static string ConvertListToString(List<string> list)
        {
            list.Sort();
            string text = "";
            foreach (string item in list)
            {
                if (text.Length > 0) text += SEPERATOR_STR;
                text += item;
            }
            return text;
        }

        public static string[] SplitStringToList(string text)
        {
            if (text == null) return new string[] { };
            else return text.Split(SEPERATOR, StringSplitOptions.RemoveEmptyEntries);
        }

        public static CodeList CreateByList(params string[] list)
        {
            Array.Sort(list);
            string text = "";
            foreach (string item in list)
            {
                if (text.Length > 0) text += SEPERATOR_STR;
                text += item;
            }
            return new CodeList(text);
        }

        internal static char[] SEPERATOR = new char[] { ';', '；', '\t', '\r', '\n' };
        public static string SEPERATOR_STR = ";";
    }
}
