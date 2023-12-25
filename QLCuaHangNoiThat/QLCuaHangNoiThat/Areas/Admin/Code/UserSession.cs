using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLCuaHangNoiThat.Areas.Admin.Code
{
    [Serializable]  //tuan tu hoa đc no ra nhi phan
    public class UserSession
    {
        public string UserName { set; get; }
    }
}