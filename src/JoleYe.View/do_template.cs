using System;
using System.Collections.Generic;
using System.Text;
using JoleYe.Data;
using JoleYe.Model;
using System.Text.RegularExpressions;

namespace JoleYe.View
{
    class do_template : Template
    {
        //private TemplateInfo j_info;
        public do_template(TemplateInfo info):base(new TemplateInfo())
        {
            j_info = info;
        }

        /// <summary>
        /// 处理include
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public void include()
        {
            Regex rg = new Regex(@"{include.+?}", RegexOptions.IgnoreCase);

            for (Match key = rg.Match(j_info.content); key.Success; key = key.NextMatch())
            {
                j_info.content = j_info.content.Replace(key.ToString(),new str_template().include(key.ToString()));
            }
        }


        /// <summary>
        /// 普通变量处理
        /// </summary>
        public void var()
        {
            Regex rg = new Regex(@"{[\$@].+?}", RegexOptions.IgnoreCase);

            for (Match key = rg.Match(j_info.content); key.Success; key = key.NextMatch())
            {
                j_info.content = j_info.content.Replace(key.ToString(), new str_template().var(key.ToString()));
            }
        }

        public string doif()
        {
            string nstr = "";
            Regex reg = new Regex(@"{if\(\S+?\)}(\s|\S)+?{/if}", RegexOptions.IgnoreCase);

            for (Match key = reg.Match(j_info.content); key.Success; key = key.NextMatch())
            {
                string tempstr = key.ToString();
                string newtmpstr = "";
                Regex inreg = new Regex(@"{if\(\S+?\)}", RegexOptions.IgnoreCase);
                Match inmat = inreg.Match(tempstr);

                string instr = inmat.ToString();
                instr = instr.Replace("{if","if");
                instr = instr.Replace("}", "");

                string paramstr = "<%\r\n"+instr + "\r\n{\r\n%>";
                newtmpstr = Regex.Replace(tempstr, @"^{if\(\S+?\)}", paramstr);
                newtmpstr = newtmpstr.Replace("{else}", "<%\r\n}else{\r\n%>\r\n");
                newtmpstr = newtmpstr.Replace("{/if}", "<%\r\n}\r\n%>\r\n");
                j_info.content = j_info.content.Replace(tempstr, newtmpstr);
            }

            return nstr;
        }

        /// <summary>
        /// 循环
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string loop()
        {
            string nstr = "";
            Regex reg = new Regex(@"{loop \w+=(\w|\(|\)|\,|""|\s|@|\*)+}(\s|\S)+?{/loop}",RegexOptions.IgnoreCase);

            for(Match key=reg.Match(j_info.content);key.Success;key=key.NextMatch())
            {
                string tempstr = key.ToString();
                string newtmpstr = "";
                Regex inreg = new Regex(@"{loop \w+=(\w|\(|\)|\,|""|\s|@|\*)+}", RegexOptions.IgnoreCase);
                Match inmat = inreg.Match(tempstr);

                string instr = inmat.ToString();
                instr = instr.Replace("{loop ","");
                instr = instr.Replace("}", "");

                string[] instrnew = instr.Split('=');

                StringBuilder str = new StringBuilder();
                str.Append("(DataRow ");
                str.Append(instrnew[0]);
                str.Append(" in ");

                str.Append(instrnew[1]);

                if (instrnew[1].IndexOf("(") < 0)
                    str.Append("()");

                str.Append(".Rows)");

                string paramstr =  str.ToString();

                newtmpstr = tempstr.Replace("{/loop}", "\r\n<%\r\n}\r\n%>\r\n");
                newtmpstr = Regex.Replace(newtmpstr, @"{loop \w+=(\w|\(|\)|\,|""|\s|@|\*)+}", "\r\n<%\r\nforeach" + paramstr + "{\r\n%>\r\n");
                
                j_info.content = j_info.content.Replace(tempstr, newtmpstr);
            }
            return nstr;
        }


        public void display(string filename)
        {
            string tempstr = j_info.content;
            bool flg = false;
            tempstr = tempstr.Replace("<%","\r\n<%\r\n");
            tempstr = tempstr.Replace("%>", "\r\n%>\r\n");

            string restr = "<%@ Page language=\"c#\" AutoEventWireup=\"false\" EnableViewState=\"false\" Inherits=\"JoleYe.Web." + filename + "\" %>\r\n";
            restr += "<%@ Import namespace=\"System.Data\" %>\r\n";
            restr += "<%@ Import namespace=\"JoleYe.Model\" %>\r\n";
            restr += "<%\r\n";
            restr += "      //此文件由JoleYe系统自动生成生成时间：" + DateTime.Now.ToString() + "\r\n\r\n";
            restr += "  StringBuilder templatestr = new StringBuilder();\r\n";
            string[] temp = Regex.Split(tempstr, "\r\n");
            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i].IndexOf("<%") != -1)
                {
                    flg = true;
                    continue;
                }
                if (temp[i].IndexOf("%>") != -1)
                {
                    flg = false;
                    continue;
                }

                if (flg)
                {
                    if (!string.IsNullOrEmpty(temp[i]))
                    {
                        if (temp[i].IndexOf("$") == 0 || temp[i].IndexOf("@") == 0)
                            restr += "  templatestr.Append(" + new str_template().evar(temp[i]) + ");\r\n";
                        else
                        {
                            restr += "  " + new str_template().nvar(temp[i]) + "\r\n";
                        }
                    }
                }
                else
                {
                    if (temp.Length > i + 1)
                    {
                        if (temp[i + 1].IndexOf("<%") != -1)
                        {
                            if (!string.IsNullOrEmpty(temp[i]))
                                restr += "  templatestr.Append(\"" + new str_template().str_replace(temp[i]) + "\");\r\n";
                        }
                        else
                        {
                            if(!string.IsNullOrEmpty(temp[i]))
                                restr += "  templatestr.Append(\"" + new str_template().str_replace(temp[i]) + "\\r\\n\");\r\n";

                        }
                    }
                    else
                        restr += "  templatestr.Append(\"" + new str_template().str_replace(temp[i]) + "\\r\\n\");\r\n";
                }

            }
            restr += "  Response.Write(templatestr.ToString());\r\n";
            restr += "%>";
            
            j_info.content = restr;
        }

        /// <summary>
        /// 
        /// </summary>
        public string for_each()
        {
            string nstr = "";
            Regex reg = new Regex(@"{foreach datatype\=\w+ info\=\w+ from\=\S+}(\s|\S)+?{/foreach}", RegexOptions.IgnoreCase);

            for (Match key = reg.Match(j_info.content); key.Success; key = key.NextMatch())
            {
                string tempstr = key.ToString();
                string newtmpstr = "";
                Regex inreg = new Regex(@"{foreach datatype\=\w+ info\=\w+ from\=\S+}", RegexOptions.IgnoreCase);
                Match inmat = inreg.Match(tempstr);

                string instr = inmat.ToString();

                string paramstr = "("+_get_eqval(instr,"datatype")+" " + _get_eqval(instr,"info") + " in " + _get_eqval(instr,"from") + ")";
                newtmpstr = tempstr.Replace("{/foreach}", "\r\n<%\r\n}\r\n%>\r\n");
                newtmpstr = Regex.Replace(newtmpstr, @"{foreach datatype\=\w+ info\=\w+ from\=\S+}", "\r\n<%\r\nforeach" + paramstr + "{\r\n%>\r\n");
                j_info.content = j_info.content.Replace(tempstr, newtmpstr);
            }
            return nstr;
        }

        public void write()
        {
            Regex reg = new Regex(@"{write (\s|\S)+?}", RegexOptions.IgnoreCase);

            for (Match key = reg.Match(j_info.content); key.Success; key = key.NextMatch())
            {
                string tempstr = key.ToString();
                string newtmpstr = tempstr.Replace("{write ", "\r\n<%\r\n$");
                newtmpstr = newtmpstr.Replace("}", "\r\n%>\r\n");

                j_info.content = j_info.content.Replace(tempstr, newtmpstr);
            }
        }

        private string _get_eqval(string str,string pattern)
        {
            return Regex.Match(str, @"(?<=("+pattern+"\\=))(\\w|\\(|\\)|\\[|\\]|\\.|\")+").Value;
        }

        internal void assign()
        {
            Regex reg = new Regex(@"{assign (\s|\S)+?}", RegexOptions.IgnoreCase);

            for (Match key = reg.Match(j_info.content); key.Success; key = key.NextMatch())
            {
                string tempstr = key.ToString();
                string newtmpstr = tempstr.Replace("{assign ", "<%");
                newtmpstr = newtmpstr.Replace("}", "%>");

                j_info.content = j_info.content.Replace(tempstr, newtmpstr);
            }
            //die(j_info.content);
        }
    }

   


}
