using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuickShipWeb.Models
{
    public class CMB_DELIVERY_ORDER_PACKAGE
    {
        public List<SHP_DELIVERY_ORDER> Delivery_Orders { get; set; }
        public List<SHP_PACKAGE> Packages { get; set; }
    }
}