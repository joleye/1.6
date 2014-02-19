using System;
namespace JoleYe.Model
{
    public class MemberInfo
    {
        private int j_id;
        private string j_username;
        private string j_password;
        private bool j_sex;
        private string j_email;
        private string j_telphone;
        private string j_mobile;
        private string j_qq;
        private string j_birth;
        private string j_ip;
        private string j_address;
        private string j_truename;
        private string j_nickname;
        private DateTime j_regdate;
        private DateTime j_lastlogin;
        private int j_loginnum;

        //id
        public int id
        {
            get { return j_id; }
            set { j_id = value; }
        }

        //username
        public string username
        {
            get { return j_username; }
            set { j_username = value; }
        }

        //password
        public string password
        {
            get { return j_password; }
            set { j_password = value; }
        }

        //sex
        public bool sex
        {
            get { return j_sex; }
            set { j_sex = value; }
        }

        //email
        public string email
        {
            get { return j_email; }
            set { j_email = value; }
        }

        //telphone
        public string telphone
        {
            get { return j_telphone; }
            set { j_telphone = value; }
        }

        //mobile
        public string mobile
        {
            get { return j_mobile; }
            set { j_mobile = value; }
        }

        //qq
        public string qq
        {
            get { return j_qq; }
            set { j_qq = value; }
        }

        //birth
        public string birth
        {
            get { return j_birth; }
            set { j_birth = value; }
        }

        //ip
        public string ip
        {
            get { return j_ip; }
            set { j_ip = value; }
        }

        //address
        public string address
        {
            get { return j_address; }
            set { j_address = value; }
        }

        //truename
        public string truename
        {
            get { return j_truename; }
            set { j_truename = value; }
        }

        //nickname
        public string nickname
        {
            get { return j_nickname; }
            set { j_nickname = value; }
        }

        public DateTime lastlogin
        {
            get { return j_lastlogin; }
            set { j_lastlogin = value; }
        }

        public DateTime regdate
        {
            get { return j_regdate; }
            set { j_regdate = value; }
        }

        public int loginnum
        {
            get { return j_loginnum; }
            set { j_loginnum = value; }
        }



    }
}
