using System;
using System.Collections.Generic;
using System.Text;

namespace JoleYe.Model
{
    /// <summary>
    /// 实体类JOLE_JM 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class JmInfo
    {
        public JmInfo()
        { }
        #region Model
        private int? _id;
        private string _uname;
        private string _sex;
        private string _age;
        private string _xueli;
        private string _address;
        private string _code;
        private string _telphone;
        private string _fax;
        private string _zhiye;
        private string _company;
        private string _zhuying;
        private string _comaddress;
        private string _zijin;
        private string _jmdq;
        private string _fhls;
        private string _fsdsc;
        private string _renkou;
        private string _czrk;
        private string _ldrk;
        private string _nsr;
        private string _yxdp;
        private string _mianji;
        private string _nzj;
        private string _mmk;
        private string _jmsf;
        private string _yyfs;
        private string _hzrs;
        private string _jzpp;
        private string _yesjmpp;
        private string _brandname;
        private string _jmqixian;
        private string _pifa;
        private string _linshou;
        private string _jynone;
        private string _dc_renshi;
        private string _ddc_ys;
        private string _dc_jl;
        private DateTime _jm_date;
        private string j_content;
        /// <summary>
        /// 
        /// </summary>
        public int? Id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string uname
        {
            set { _uname = value; }
            get { return _uname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string sex
        {
            set { _sex = value; }
            get { return _sex; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string age
        {
            set { _age = value; }
            get { return _age; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string xueli
        {
            set { _xueli = value; }
            get { return _xueli; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string address
        {
            set { _address = value; }
            get { return _address; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string code
        {
            set { _code = value; }
            get { return _code; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string telphone
        {
            set { _telphone = value; }
            get { return _telphone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string fax
        {
            set { _fax = value; }
            get { return _fax; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string zhiye
        {
            set { _zhiye = value; }
            get { return _zhiye; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string company
        {
            set { _company = value; }
            get { return _company; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string zhuying
        {
            set { _zhuying = value; }
            get { return _zhuying; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string comaddress
        {
            set { _comaddress = value; }
            get { return _comaddress; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string zijin
        {
            set { _zijin = value; }
            get { return _zijin; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string jmdq
        {
            set { _jmdq = value; }
            get { return _jmdq; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string fhls
        {
            set { _fhls = value; }
            get { return _fhls; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string fsdsc
        {
            set { _fsdsc = value; }
            get { return _fsdsc; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string renkou
        {
            set { _renkou = value; }
            get { return _renkou; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string czrk
        {
            set { _czrk = value; }
            get { return _czrk; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ldrk
        {
            set { _ldrk = value; }
            get { return _ldrk; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string nsr
        {
            set { _nsr = value; }
            get { return _nsr; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string yxdp
        {
            set { _yxdp = value; }
            get { return _yxdp; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string mianji
        {
            set { _mianji = value; }
            get { return _mianji; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string nzj
        {
            set { _nzj = value; }
            get { return _nzj; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string mmk
        {
            set { _mmk = value; }
            get { return _mmk; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string jmsf
        {
            set { _jmsf = value; }
            get { return _jmsf; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string yyfs
        {
            set { _yyfs = value; }
            get { return _yyfs; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string hzrs
        {
            set { _hzrs = value; }
            get { return _hzrs; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string jzpp
        {
            set { _jzpp = value; }
            get { return _jzpp; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string yesjmpp
        {
            set { _yesjmpp = value; }
            get { return _yesjmpp; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string brandName
        {
            set { _brandname = value; }
            get { return _brandname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string jmqixian
        {
            set { _jmqixian = value; }
            get { return _jmqixian; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string pifa
        {
            set { _pifa = value; }
            get { return _pifa; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string linshou
        {
            set { _linshou = value; }
            get { return _linshou; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string jynone
        {
            set { _jynone = value; }
            get { return _jynone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string dc_renshi
        {
            set { _dc_renshi = value; }
            get { return _dc_renshi; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ddc_ys
        {
            set { _ddc_ys = value; }
            get { return _ddc_ys; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string dc_jl
        {
            set { _dc_jl = value; }
            get { return _dc_jl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime jm_date
        {
            set { _jm_date = value; }
            get { return _jm_date; }
        }

        public string content
        {
            set { j_content = value; }
            get { return j_content; }
        }
        #endregion Model

    }
}

