﻿using Model_Data.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLCuaHangNoiThat.Models
{
    public class CartItem
    {
        public Product Product  {set;get;}
        public int Quantity { set; get; }
    }
}