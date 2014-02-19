using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using JoleYe.Model;

namespace JoleYe.View
{
    class str_template : Template
    {
        public str_template()
            : base(new TemplateInfo())
        { 
        
        }
        public string include(string str)
        {
            Regex rg = new Regex("file=\".+?\"", RegexOptions.IgnoreCase);
            if (rg.IsMatch(str))
            {
                Match mt = rg.Match(str);
                string nstr = mt.ToString();
                nstr = nstr.Replace("file=\"", "");
                nstr = nstr.Replace("\"", "");
                return open(TEMPLATEPATH + "/" + nstr);

            }
            else
                return str;
        }


        public string var(string str)
        {
            string nstr = str;
            nstr = nstr.Replace("{", "<%");
            nstr = nstr.Replace("}", "%>");
            return nstr;
        }


        public string str_replace(string str)
        {
            string nstr = str;
            nstr = nstr.Replace("\"", "\\\"");
            return nstr;
        }

        public string evar(string str)
        {
            string nstr = str;
            //判断中间是否有点
            if (Regex.IsMatch(nstr,@"^\@") && Regex.IsMatch(nstr, @"."))
            {
                string attr = Regex.Match(nstr, @"(?<=\.)\S+$").Value;
                nstr = nstr.Replace("." + attr, "[\""+attr+"\"]");
            }


            nstr = Regex.Replace(nstr,@"^\$|^@","");

            if (nstr.IndexOf("|") > -1)
            {
                string[] charstr = nstr.Split('|');

                if (charstr[1].IndexOf("#") > 0)
                {
                    string[] str2 = charstr[1].Split('#');
                    nstr = str2[0]+"("+charstr[0]+".ToString(),"+str2[1]+")";
                }
                else
                    nstr = charstr[1] + "(" + charstr[0] + ".ToString())";
            }

            return nstr;
        }


        public string nvar(string str)
        { 
            Regex rg = new Regex(@"if\(.+?\)|{$|}$|for\(.+?\)|foreach\(.+?\)|.+?else$|while\(.+?\)|do\s\(.+?\)");
            if (rg.IsMatch(str))
                return str;
            else
                return str + ";";
        }


        
    }
}
