using System;
using System.Collections.Generic;
using System.Text;
using JoleYe.Model;
using JoleYe.Dal;

namespace JoleYe.Bll
{
    public class PassportBll : BllBase
    {

        /// <summary>
        /// ÊÇ·ñµÇÂ½
        /// </summary>
        /// <returns></returns>
        public bool islogin()
        {
            if (getCookie("username") != "" && getCookie("password") != "")
                return true;
            else
                return false;
        }

        /// <summary>
        /// µÇÂ½ÓÃ»§ÐÅÏ¢
        /// </summary>
        /// <returns></returns>
        public MemberInfo get()
        {
            if (islogin())
            {
                MemberDal dal = new MemberDal();

                return dal.view(getCookie("username"));
            }
            else
                return new MemberInfo();
        }


        /// <summary>
        /// µÇÂ½
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool login(string username, string password)
        {
            MemberInfo info = new MemberInfo();
            info.username = username;
            info.password = password;
            MemberDal bal = new MemberDal();
            if (bal.login(info))
            {
                MemberInfo info1 = bal.view(username);
                if (info1.nickname != "" && info.username != null)
                    setCookie("nickname", Server.UrlEncode(info1.nickname));
                else
                    setCookie("nickname", username);

                setCookie("username", username);

                setCookie("password", md5(password));
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// ×¢²á
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public bool register(MemberInfo info)
        {
            MemberDal bal = new MemberDal();
            if (bal.isreg(info.username))
            {
                bal.register(info);
                login(info.username,info.password);
                return true;
            }
            else
                return false;
        }

        public bool register(string username,string nickname, string password)
        {
            MemberDal bal = new MemberDal();
            if (bal.isreg(username))
            {
                bal.register(username, nickname, password);
                login(username, password);
                return true;
            }
            else
            {
                login(username, password);
                return false;
            }
        }

        /// <summary>
        /// ×¢Ïú
        /// </summary>
        /// <returns></returns>
        public bool loginout()
        {
            setCookie("username", "");
            setCookie("password", "");
            setCookie("nickname","");
            return true;
        }


    }
}
