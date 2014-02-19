using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;

namespace JoleYe.Bll
{
    public class StringUrl : BllBase
    {
        private string j_data;
        public StringUrl()
        { 
        
        }

        public StringUrl(string data)
        {
            j_data = data;
        }


        public string get(string key)
        {
            return Regex.Match(j_data, @"(?<=(" + key + "\\=))(\\w|\\%|_|\\-)+((?=\\&)|$)").Value;
        }

        private Hashtable j_json = new Hashtable();
        public string jget(string key)
        {

                if (j_json.Count > 0)
                    return j_json[key] != null ? j_json[key].ToString() : "";
                else
                {
                    j_data = Regex.Match(j_data, @"(?<=\{)(\s|\S)+(?=\})").Value;
                    if (j_data.IndexOf(",") > -1)
                    {
                        string[] _v = j_data.Split(',');
                        for (int i = 0; i < _v.Length; i++)
                        {
                            _do_string(_v[i]);
                        }
                    }
                    else
                    {
                        _do_string(j_data);
                    }

                    return j_json[key]!=null?j_json[key].ToString():"";
                    //return Regex.Match(j_data, "(?<=(\"" + key + "\":\"))(\\w|)+(?=(\",)|\\})").Value;
                }

        }

        private void _do_string(string str)
        {
            string[] _s = str.Split(':');
            string k = _get_val(_s[0]);
            //print(k + "=" + _get_val(_s[1]) + "\r\n");
            if (_s.Length > 1)
            {
                if (!j_json.ContainsKey(k))
                    j_json.Add(k, _get_val(_s[1]));
                else
                    j_json[k] = _get_val(_s[1]);
            }
        }


        private string _get_val(string str)
        {
            str = str.Trim();
            if (str.IndexOf("\"")>=0)
            {
                return str.Substring(1, str.Length - 2).Trim();
            }
            else
                return str;
        }
    }
}
