using System;
using System.Collections.Generic;
using System.Text;
using JoleYe.Dal;

namespace JoleYe.Bll
{
    public class MemberBll : BllBase
    {
        public int drop(int[] ids)
        {
            MemberDal dal = new MemberDal();
            int c = 0;
            foreach (int id in ids)
            {
                if (dal.drop(id))
                    c++;
            }

            return c;
        }
    }
}
