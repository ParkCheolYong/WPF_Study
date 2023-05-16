using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfControls.Utilities
{
    public static class UIElementUtils
    {
        public static void BringToFront(this UIElement uIElement)
        {
            Panel.SetZIndex(uIElement, int.MaxValue);
        }

        public static void SendToBack(this UIElement uIElement)
        {
            Panel.SetZIndex(uIElement, int.MinValue);
        }
    }
}
