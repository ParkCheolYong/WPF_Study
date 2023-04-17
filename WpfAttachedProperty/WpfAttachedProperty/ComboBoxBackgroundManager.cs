using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfAttachedProperty
{
    public class ComboBoxBackgroundManager
    {
        private static Brush? _newBrush = null; 
        
        public static Brush GetBackground(DependencyObject obj)
        {
            return (Brush)obj.GetValue(BackgroundProperty);
        }

        public static void SetBackground(DependencyObject obj, Brush value)
        {
            obj.SetValue(BackgroundProperty, value);
        }

        // Using a DependencyProperty as the backing store for Background.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BackgroundProperty =
            DependencyProperty.RegisterAttached("Background", typeof(Brush), typeof(ComboBoxBackgroundManager), new UIPropertyMetadata(Brushes.Transparent, BackgroundChanged));

        private static void BackgroundChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var cmb = d as ComboBox;
            if (cmb == null) return;

            if(e.NewValue != e.OldValue)
            {
                _newBrush = (Brush)e.NewValue;

                cmb.Loaded -= Cmb_Loaded;
                cmb.Loaded += Cmb_Loaded;
                cmb.Unloaded -= Cmb_Unloaded;
                cmb.Unloaded += Cmb_Unloaded;
            }
        }

        private static void Cmb_Unloaded(object sender, RoutedEventArgs e)
        {
            var cmb = (ComboBox)sender;
            cmb.Loaded -= Cmb_Loaded;
            cmb.Unloaded -= Cmb_Unloaded;
            _newBrush = null;
        }

        private static void Cmb_Loaded(object sender, RoutedEventArgs e)
        {
            var cmb = (ComboBox)sender;
            cmb.SetBackground(_newBrush ?? Brushes.Transparent);
        }
    }
}
