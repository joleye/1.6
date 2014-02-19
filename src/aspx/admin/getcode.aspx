<%@ Page Language="C#" AutoEventWireup="true" EnableViewState="false"%>
<%@ Import Namespace="System.Drawing" %>
<%@ Import Namespace="System.Drawing.Drawing2D" %>
<%@ Import Namespace="System.Drawing.Imaging" %>
<%@ Import Namespace="System.IO" %>
<%@ Import Namespace="System.Text" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>��֤��</title>
    <!--��ֹ������ӱ��ػ����е���ҳ��-->
    <meta http-equiv="pragram" content="no-cache" />
    <!--�������¼���ҳ��-->
    <meta http-equiv="cache-control" content="no-cache, must-revalidate" />
    <!--��ҳ�ڻ����еĹ���ʱ��-->
    <meta http-equiv="expires" content="-1" />
    <script type="text/C#" runat="server">
        static readonly char[] codeList = new char[]{'1','2','3','4','5','6','7','8','9',

                     'a','b','c','d','e','f','g','h','i','j','k','l','m','n','p','q','r','s','t','u','v','w','x','y','z',

                     'A','B','C','D','E','F','G','H','I','J','K','L','M','N','P','Q','R','S','T','U','V','W','X','Y','Z'};

 

        string sessionKey = "ValidateCode";//������Session�����õ�KEY
        int codeLength = 6;                //��֤���ַ����� 
        int width = 100;                   //��֤��ͼƬ���
        int height = 30;                   //��֤��ͼƬ�߶�
        int fontSize = 17;                 //��֤�������С

        protected void Page_Load(object sender, EventArgs e)
        {
            //��ȡ��֤���ַ���
            string strCode = GetValidateCode();
            //����֤���ַ������浽Session��
            Session[sessionKey] = strCode;
            //ʵ����ͼƬ
            using (Bitmap img = new Bitmap(width, height))
            {
                //��ȡ����
                using (Graphics g = Graphics.FromImage(img))
                {
                    //������
                    g.FillRectangle(new HatchBrush(HatchStyle.DiagonalBrick, Color.Snow, Color.Snow), 0, 0, width, height);
                    //������֤��
                    using (Font font = new Font("Rockwell", fontSize, FontStyle.Bold | FontStyle.Italic))
                    {
                        g.DrawString(strCode, font, new LinearGradientBrush(new Point(0, 0), new Point(0, 5), Color.Blue, Color.Blue), (width - font.SizeInPoints * codeLength) / 2, (height - font.SizeInPoints) / 3);
                    }
                    using (MemoryStream mStream = new MemoryStream())
                    {
                        //��ͼƬ�����ڴ���
                        img.Save(mStream, ImageFormat.Gif);
                        //��ͼƬ�����ҳ��
                        Response.ClearContent();
                        Response.ContentType = "image/gif";
                        Response.BinaryWrite(mStream.ToArray());
                    }
                }
            }
            Response.End();
        }

        //������֤��
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