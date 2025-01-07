using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assigment3_161413
{
    class Text
    {
        string text;

        public string _Text
        {
            get
            {
                return text;
            }

            set
            {
                text = value;
            }
        }
        string[] parts;
        public Text(string s)
        {
            text = s;
            parts = text.Split(new char[] { '\t', ' ', '\n', '\r', ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
        }

        public List<string> allword
        {
            get
            {
                List<string> words = new List<string>();
                foreach(string item in parts)
                {
                    if (item.Length > 1 && char.IsLetter(item[0]))
                        words.Add(item);
                }
                return words;
            }
        }

        



    }
}
