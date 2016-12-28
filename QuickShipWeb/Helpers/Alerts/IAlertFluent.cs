using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuickShipWeb.Helpers.Alerts
{
    public interface IAlertFluent : IHtmlString
    {
        IAlertFluent Dismissible(bool canDismiss = true);


    }

}