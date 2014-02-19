<%@ Page Language="C#" AutoEventWireup="true" EnableViewState="false"%>
<%@ Import Namespace="System.Drawing" %>
<%@ Import Namespace="System.Drawing.Drawing2D" %>
<%@ Import Namespace="System.Drawing.Imaging" %>
<%@ Import Namespace="System.IO" %>
<%@ Import Namespace="System.Text" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>验证码</title>
    <!--禁止浏览器从本地缓存中调阅页面-->
    <meta http-equiv="pragram" content="no-cache" />
    <!--必须重新加载页面-->
    <meta http-equiv="cache-control" content="no-cache, must-revalidate" />
    <!--网页在缓存中的过期时间-->
    <meta http-equiv="expires" content="-1" />
    <script type="text/C#" runat="server">
        static readonly char[] codeList = new char[]{'1','2','3','4','5','6','7','8','9',

                     'a','b','c','d','e','f','g','h','i','j','k','l','m','n','p','q','r','s','t','u','v','w','x','y','z',

                     'A','B','C','D','E','F','G','H','I','J','K','L','M','N','P','Q','R','S','T','U','V','W','X','Y','Z'};

 

        string sessionKey = "ValidateCode";//保存在Session中所用的KEY
        int codeLength = 6;                //验证码字符长度 
        int width = 100;                   //验证码图片宽度
        int height = 30;                   //验证码图片高度
        int fontSize = 17;                 //验证码字体大小

        protected void Page_Load(object sender, EventArgs e)
        {
            //获取验证码字符串
            string strCode = GetValidateCode();
            //将验证码字符串保存到Session中
            Session[sessionKey] = strCode;
            //实例化图片
            using (Bitmap img = new Bitmap(width, height))
            {
                //获取画板
                using (Graphics g = Graphics.FromImage(img))
                {
                    //填充底纹
                    g.FillRectangle(new HatchBrush(HatchStyle.DiagonalBrick, Color.Snow, Color.Snow), 0, 0, width, height);
                    //绘制验证码
                    using (Font font = new Font("Rockwell", fontSize, FontStyle.Bold | FontStyle.Italic))
                    {
                        g.DrawString(strCode, font, new LinearGradientBrush(new Point(0, 0), new Point(0, 5), Color.Blue, Color.Blue), (width - font.SizeInPoints * codeLength) / 2, (height - font.SizeInPoints) / 3);
                    }
                    using (MemoryStream mStream = new MemoryStream())
                    {
                        //将图片存入内存中
                        img.Save(mStream, ImageFormat.Gif);
                        //将图片输出至页面
                        Response.ClearContent();
                        Response.ContentType = "image/gif";
                        Response.BinaryWrite(mStream.ToArray());
                    }
                }
            }
            Response.End();
        }

        //生成验证码
        public string GetValidateCode()
        {
            Random rand = new Random();
            StringBuilder strBuilder = new StringBuilder(codeLength);
            for (int i = 0; i < codeLength; i++)
            {
                strBuilder.Append(codeList[rand.Next(0, codeList.Length)]);
            }
            return strBuilder.ToString();
        }
    </script>
</head>
<body>
</body>
</html>