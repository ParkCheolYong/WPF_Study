using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace WpfAttachedProperty
{
    public static class ComboBoxBackgroundExtension
    {
        public static void SetBackground(this ComboBox combo, Brush brush)
        {
            var toggleButton = (ToggleButton)combo.Template.FindName("toggleButton", combo);
            if (toggleButton != null)
            {
                var border = (Border)toggleButton.Template.FindName("templateRoot", toggleButton);
                if (border != null)
                {
                    border.Background = brush;
                }

            }

            var textBox = (TextBox)combo.Template.FindName("PART_EditableTextBox", combo);
            if (textBox != null)
            {
                var parent = (Border)textBox.Parent;
                parent.Background = brush;
            }
        }
    }
}
