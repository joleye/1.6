using System;
using System.Collections.Generic;
using System.Text;
using JoleYe.Dal;
using JoleYe.Model;
using System.Text.RegularExpressions;

namespace JoleYe.Bll
{
    public class Auto_pageBll : BllBase
    {
        private Auto_pageInfo j_info;
        private string j_type;
        public Auto_pageBll(int id,string type)
        {
            Auto_pageDal ap = new Auto_pageDal();
            j_info = ap.view(id);
            j_type = type;
        }

        public string get(string key)
        {
            if (!string.IsNullOrEmpty(j_info.setting) && Regex.IsMatch(j_info.setting, "^" + j_type))
            {
                Regex reg = new Regex(@"(?<=(" + key + ":))\\w+(?=\\;)", RegexOptions.IgnoreCase);
                Match mat = reg.Match(j_info.setting);
                return mat.Value;
            }
            else
                return "";
        }

        public string getcont
        {
            get { return j_info.content; }
        }
    }
}
