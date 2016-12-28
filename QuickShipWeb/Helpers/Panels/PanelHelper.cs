using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuickShipWeb.Helpers.Panels
{
    public static class PanelHelper
    {
        public static Panel Panel(this HtmlHelper html, string title, 
            Enums.PanelStyle style = Enums.PanelStyle.Default)
        {
            return new Panel(html, title, style);
        }
    }
}