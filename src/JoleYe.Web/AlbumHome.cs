using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace JoleYe.Web
{
    public class AlbumHome : Frontend
    {
        public string album_files;
        public string album_links;
        public string album_texts;
        public AlbumHome()
        {
        
            album_links = "";
            album_texts = "";
            foreach(DataRow dr in get_album_home().Rows)
            {
                album_files += dr["imgUrl"].ToString() + "|";
                album_links += dr["linkUrl"].ToString() + "|";
            }
            album_files = album_files.Substring(0, album_files.Length-1);
            album_links = album_links.Substring(0, album_links.Length - 1);
        }

        public DataTable get_album_home()
        {
            DataSet dt = find("album", 5, "showHome<>0", "orderId,id desc");
            return dt.Tables[0];
        }
    }
}
