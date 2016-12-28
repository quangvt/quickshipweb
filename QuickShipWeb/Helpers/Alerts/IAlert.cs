using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuickShipWeb.Helpers.Alerts
{
    public interface IAlert : IAlertFluent
    {
        IAlertFluent Danger();
        IAlertFluent Info();
        IAlertFluent Success();
        IAlertFluent Warning();
    }
}