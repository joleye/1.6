using System;
using System.Collections.Generic;
using System.Text;
using JoleYe.Model;
using JoleYe.Data;
using System.Data;
using System.Data.OleDb;

namespace JoleYe.Dal
{
    public class MemberDal : Base
    {
        public bool register(string username,string nickname,string password) 
        {
            this.DataSetExecuteAddText("member",
                 "username", username,
                 "nickname",nickname,
                 "password", md5(password)
                 );
            return true;
        }
        public int register(MemberInfo info)
        {
            //this.DataSetExecuteAddText("member", 
            //     "username", info.username,
            //     "password", md5(info.password),
            //     "sex",info.sex,
            //     "email",info.email,
            //     "telphone",info.telphone,
            //     "mobile",info.mobile,
            //     "qq",info.qq,
            //     "birth",info.birth,
            //     "ip",info.ip,
            //     "address",info.address,
            //     "truename",info.truename
            //     );
            //return 0;
            return this.add("member",
                 "username", 2, info.username.Length, info.username,
                 "password", 2, 32, md5(info.password),
                 "sex", 5, 1, info.sex,
                 "email", 2, info.email.Length, info.email,
                 "telphone", 2, info.telphone.Length, info.telphone,
                 "mobile", 2, info.mobile.Length, info.mobile,
                 "qq", 2, info.qq.Length, info.qq,
                 "birth", 2, info.birth.Length, info.birth,
                 "ip", 2, info.ip.Length, info.ip,
                 "address", 2, info.address.Length, info.address,
                 "truename", 2, info.truename.Length, info.truename
                 );
        }

        public bool edit(MemberInfo info,int id)
        {
            int sex;
            if (info.sex)
                sex = 1;
            else
                sex = 0;
            MemberInfo oldinfo = this.view(id);

            if (string.IsNullOrEmpty(info.nickname))
                info.nickname = oldinfo.nickname;

            return this.DataSetEdit("member", id.ToString(),
                 "username",info.username,
                 "password",info.password,
                 "sex",sex,
                 "email",info.email,
                 "telphone", info.telphone,
                 "mobile",info.mobile,
                 "qq",info.qq,
                 "birth",info.birth,
                 "address",info.address,
                 "truename",info.truename,
                 "nickname",info.nickname
                 );
        }

        public bool login(MemberInfo info)
        {

            DataSet ds = DataSetExecuteText("select * from " + label_table + "member where username=@username and password=@password", 
                "@username",info.username,
                "@password",md5(info.password)
                );


            DataSetExecuteText("update " + label_table + "member set lastlogin=@lastlogin where username=@username",
                "@lastlogin",DateTime.Now.ToString(),
                "@username",info.username);

           if (ds.Tables[0].Rows.Count > 0)
               return true;
           else
               return false;
        }

        public bool isreg(string username)
        {
            DataSet ds = DataSetExecuteText("select * from " + label_table + "member where username=@username",
                        "@username", username
                 );



            if (ds.Tables[0].Rows.Count > 0)
                return false;
            else
                return true;
        }

        public bool drop(int id)
        {
            drop("member", id.ToString());
            return true;
        }

        public List<MemberInfo> get_list(int page, int pagesize)
        {
            List<MemberInfo> list = new List<MemberInfo>();
            DataSet ds = DataSetPageFind("member", page, pagesize);
            if (ds.Tables.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    MemberInfo info = new MemberInfo();
                    info.id = int.Parse(dr["id"].ToString());
                    info.username = dr["username"].ToString();
                    info.truename = dr["truename"].ToString();
                    info.telphone = dr["telphone"].ToString();
                    list.Add(info);
                }
            }
            return list;
        }

        public MemberInfo view(string username)
        {
            DataSet ds = DataSetFind("member", "username", username);
            MemberInfo info = new MemberInfo();
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = ds.Tables[0].Rows[0];

                    info.id = int.Parse(dr["id"].ToString());
                    info.username = dr["username"].ToString();
                    info.password = dr["password"].ToString();
                    info.truename = dr["truename"].ToString();
                    info.sex = bool.Parse(dr["sex"].ToString());
                    info.telphone = dr["telphone"].ToString();
                    info.mobile = dr["mobile"].ToString();
                    info.birth = dr["birth"].ToString();
                    info.address = dr["address"].ToString();
                    info.qq = dr["qq"].ToString();
                    info.email = dr["email"].ToString();
                    info.nickname = dr["nickname"].ToString();
                }
            }
            return info;
        }
        /// <summary>
        /// 用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public MemberInfo view(int id)
        {
            DataSet ds = DataSetFind("member", "id", id.ToString());
            MemberInfo info = new MemberInfo();
            if (ds.Tables.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                info.id = int.Parse(dr["id"].ToString());
                info.username = dr["username"].ToString();
                info.password = dr["password"].ToString();
                info.truename = dr["truename"].ToString();
                info.sex = bool.Parse(dr["sex"].ToString());
                info.telphone = dr["telphone"].ToString();
                info.mobile = dr["mobile"].ToString();
                info.birth = dr["birth"].ToString();
                info.address = dr["address"].ToString();
                info.qq = dr["qq"].ToString();
                info.email = dr["email"].ToString();
                info.nickname = dr["nickname"].ToString();
            }
            return info;
        }
    }
}
