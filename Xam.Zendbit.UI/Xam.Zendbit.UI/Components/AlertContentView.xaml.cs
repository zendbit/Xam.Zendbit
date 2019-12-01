using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace Xam.Zendbit.UI.Components
{
    public partial class AlertContentView : PopUpView
    {
        public AlertContentView()
        {
            InitializeComponent();
            OnCloseCmd = OnAlertCloseCmd;
        }

        public ICommand OnAlertCloseCmd
        {
            get { return (ICommand)GetValue(OnAlertCloseCmdProperty); }
            set { SetValue(OnAlertCloseCmdProperty, value); }
        }

        public static readonly BindableProperty OnAlertCloseCmdProperty =
            BindableProperty.Create(
                nameof(OnAlertCloseCmd),
                typeof(ICommand),
                typeof(AlertContentView),
                null,
                BindingMode.TwoWay);
    }
}
