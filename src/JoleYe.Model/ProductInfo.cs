using System;
namespace JoleYe.Model
{
    public class ProductInfo
    {
        private int j_Id;
        private int j_TypeId;
        private string j_productName;
        private string j_title1;
        private string j_title2;
        private string j_content;
        private string j_content1;
        private DateTime j_postDate;
        private int j_HitNum;
        private int j_adminId;
        private string j_productImgUrl;
        private string j_productImgUrl_S;
        private int j_showId;
        private bool j_showHome;
        private string j_content2;
        private string j_content3;
        private Price j_price;
        //Id
        public int Id
        {
            get { return j_Id; }
            set { j_Id = value; }
        }

        //TypeId
        public int TypeId
        {
            get { return j_TypeId; }
            set { j_TypeId = value; }
        }

        //produceName
        public string productName
        {
            get { return j_productName; }
            set { j_productName = value; }
        }

        //title1
        public string title1
        {
            get { return j_title1; }
            set { j_title1 = value; }
        }

        //title2
        public string title2
        {
            get { return j_title2; }
            set { j_title2 = value; }
        }

        //content
        public string content
        {
            get { return j_content; }
            set { j_content = value; }
        }

        //content1
        public string content1
        {
            get { return j_content1; }
            set { j_content1 = value; }
        }

        //postDate
        public DateTime postDate
        {
            get { return j_postDate; }
            set { j_postDate = value; }
        }

        //HitNum
        public int HitNum
        {
            get { return j_HitNum; }
            set { j_HitNum = value; }
        }

        //adminId
        public int adminId
        {
            get { return j_adminId; }
            set { j_adminId = value; }
        }

        //productImgUrl
        public string productImgUrl
        {
            get { return j_productImgUrl; }
            set { j_productImgUrl = value; }
        }

        //productImgUrl_S
        public string productImgUrl_S
        {
            get { return j_productImgUrl_S; }
            set { j_productImgUrl_S = value; }
        }

        //showId
        public int showId
        {
            get { return j_showId; }
            set { j_showId = value; }
        }

        //showHome
        public bool showHome
        {
            get { return j_showHome; }
            set { j_showHome = value; }
        }

        //content2
        public string content2
        {
            get { return j_content2; }
            set { j_content2 = value; }
        }

        //content3
        public string content3
        {
            get { return j_content3; }
            set { j_content3 = value; }
        }

        public Price price
        {
            get { return j_price; }
            set { j_price = value; }
        }

    }
}