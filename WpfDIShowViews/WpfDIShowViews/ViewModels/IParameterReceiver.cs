using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfDIShowViews.ViewModels
{
    public interface IParameterReceiver
    {
        void ReceiveParameter(object parameter);
    }
}
