using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuickShipWeb.Helpers
{
    public class Enums
    {
        public enum ButtonStyle
        {
            Default,
            Primary,
            Success,
            Info,
            Warning,
            Danger,
            Link
        }

        public enum ButtonSize
        {
            Large,
            Small,
            ExtraSmall,
            Normal
        }

        public enum AlertStyle
        {
            Danger,
            Info,
            Success,
            Warning,
        }

        public enum PanelStyle
        {
            Default,
            Primary,
            Success,
            Info,
            Warning,
            Danger
        }
    }
}