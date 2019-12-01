using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace Xam.Zendbit.UI.Components
{
    public partial class ImageButton : CircleImage
    {
        public ImageButton()
        {
            InitializeComponent();
        }

        public ICommand ButtonTappedCmd
        {
            get { return (ICommand)GetValue(ButtonTappedCmdProperty); }
            set { SetValue(ButtonTappedCmdProperty, value); }
        }

        public static readonly BindableProperty ButtonTappedCmdProperty =
            BindableProperty.Create(
                nameof(ButtonTappedCmd),
                typeof(ICommand),
                typeof(CircleImage),
                null,
                BindingMode.TwoWay);

        public object CommandParameter
        {
            get { return (object)GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        public static readonly BindableProperty CommandParameterProperty =
            BindableProperty.Create(
                nameof(CommandParameter),
                typeof(object),
                typeof(CircleImage),
                null,
                BindingMode.TwoWay);

        public ICommand ElementTappedCmd
        {
            get
            {
                return new Command(async (sender) =>
                {
                    if (sender is CircleImage circleImage)
                    {
                        await AnimateView.Self.TouchEffect(circleImage);
                        if (ButtonTappedCmd != null)
                        {
                            if (CommandParameter is null)
                                CommandParameter = this;

                            ButtonTappedCmd.Execute(CommandParameter);
                        }
                    }
                });
            }
        }
    }
}
