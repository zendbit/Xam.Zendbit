using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Input;
using Xamarin.Forms;
using Xam.Zendbit.UI.Components.Resources;

namespace Xam.Zendbit.UI.Components
{
    public partial class AlertView : PopUpView
    {
        public AlertView()
        {
            InitializeComponent();
            OnCloseCmd = OnAlertClosedCmd;
        }

        public string ConfirmText
        {
            get { return (string)GetValue(ConfirmTextProperty); }
            set { SetValue(ConfirmTextProperty, value); }
        }

        public static readonly BindableProperty ConfirmTextProperty =
            BindableProperty.Create(
                nameof(ConfirmText),
                typeof(string),
                typeof(AlertView),
                null,
                BindingMode.TwoWay);

        public Color ConfirmTextColor
        {
            get { return (Color)GetValue(ConfirmTextColorProperty); }
            set { SetValue(ConfirmTextColorProperty, value); }
        }

        public static readonly BindableProperty ConfirmTextColorProperty =
            BindableProperty.Create(
                nameof(ConfirmTextColor),
                typeof(Color),
                typeof(AlertView),
                null,
                BindingMode.TwoWay);

        public string PositiveButtonText
        {
            get { return (string)GetValue(PositiveButtonTextProperty); }
            set { SetValue(PositiveButtonTextProperty, value); }
        }

        public static readonly BindableProperty PositiveButtonTextProperty =
            BindableProperty.Create(
                nameof(PositiveButtonText),
                typeof(string),
                typeof(AlertView),
                null,
                BindingMode.TwoWay);

        public Color PositiveButtonTextColor
        {
            get { return (Color)GetValue(PositiveButtonTextColorProperty); }
            set { SetValue(PositiveButtonTextColorProperty, value); }
        }

        public static readonly BindableProperty PositiveButtonTextColorProperty =
            BindableProperty.Create(
                nameof(PositiveButtonTextColor),
                typeof(Color),
                typeof(AlertView),
                ComponentResources.Self.GetResource(
                    "TextColorWhite", ComponentResourcesEnum.ViewResources),
                BindingMode.TwoWay);

        public Color PositiveButtonBackgroundColor
        {
            get { return (Color)GetValue(PositiveButtonBackgroundColorProperty); }
            set { SetValue(PositiveButtonBackgroundColorProperty, value); }
        }

        public static readonly BindableProperty PositiveButtonBackgroundColorProperty =
            BindableProperty.Create(
                nameof(PositiveButtonBackgroundColor),
                typeof(Color),
                typeof(AlertView),
                ComponentResources.Self.GetResource(
                    "ButtonBackgroundColorTosca", ComponentResourcesEnum.ViewResources),
                BindingMode.TwoWay);

        public string NegativeButtonText
        {
            get { return (string)GetValue(NegativeButtonTextProperty); }
            set { SetValue(NegativeButtonTextProperty, value); }
        }

        public static readonly BindableProperty NegativeButtonTextProperty =
            BindableProperty.Create(
                nameof(NegativeButtonText),
                typeof(string),
                typeof(AlertView),
                null,
                BindingMode.TwoWay);

        public Color NegativeButtonTextColor
        {
            get { return (Color)GetValue(NegativeButtonTextColorProperty); }
            set { SetValue(NegativeButtonTextColorProperty, value); }
        }

        public static readonly BindableProperty NegativeButtonTextColorProperty =
            BindableProperty.Create(
                nameof(NegativeButtonTextColor),
                typeof(Color),
                typeof(AlertView),
                ComponentResources.Self.GetResource(
                    "TextColorWhite", ComponentResourcesEnum.ViewResources),
                BindingMode.TwoWay);

        public Color NegativeButtonBackgroundColor
        {
            get { return (Color)GetValue(NegativeButtonBackgroundColorProperty); }
            set { SetValue(NegativeButtonBackgroundColorProperty, value); }
        }

        public static readonly BindableProperty NegativeButtonBackgroundColorProperty =
            BindableProperty.Create(
                nameof(NegativeButtonBackgroundColor),
                typeof(Color),
                typeof(AlertView),
                ComponentResources.Self.GetResource(
                    "ButtonBackgroundColorRed", ComponentResourcesEnum.ViewResources),
                BindingMode.TwoWay);

        public double ButtonHeight
        {
            get { return (double)GetValue(ButtonHeightProperty); }
            set { SetValue(ButtonHeightProperty, value); }
        }

        public static readonly BindableProperty ButtonHeightProperty =
            BindableProperty.Create(
                nameof(ButtonHeight),
                typeof(double),
                typeof(AlertView),
                0.0,
                BindingMode.TwoWay,
                propertyChanged: (s, o, n) =>
                {
                    if (s is AlertView alertView)
                    {
                        if (n is double height && height > 0)
                        {
                            alertView._negativeButton.HeightRequest =
                            alertView._positiveButton.HeightRequest = height;
                        }
                    }
                });

        public ICommand OnAlertClosedCmd
        {
            get { return (ICommand)GetValue(OnAlertClosedCmdProperty); }
            set { SetValue(OnAlertClosedCmdProperty, value); }
        }

        public static readonly BindableProperty OnAlertClosedCmdProperty =
            BindableProperty.Create(
                nameof(OnAlertClosedCmd),
                typeof(ICommand),
                typeof(AlertView),
                null,
                BindingMode.TwoWay);

        public ICommand OnPositiveButtonCmd
        {
            get { return (ICommand)GetValue(OnPositiveButtonCmdProperty); }
            set { SetValue(OnPositiveButtonCmdProperty, value); }
        }

        public static readonly BindableProperty OnPositiveButtonCmdProperty =
            BindableProperty.Create(
                nameof(OnPositiveButtonCmd),
                typeof(ICommand),
                typeof(AlertView),
                null,
                BindingMode.TwoWay);

        public ICommand OnNegativeButtonCmd
        {
            get { return (ICommand)GetValue(OnNegativeButtonCmdProperty); }
            set { SetValue(OnNegativeButtonCmdProperty, value); }
        }

        public static readonly BindableProperty OnNegativeButtonCmdProperty =
            BindableProperty.Create(
                nameof(OnNegativeButtonCmd),
                typeof(ICommand),
                typeof(AlertView),
                null,
                BindingMode.TwoWay);

        public ICommand ElmTappedCmd
        {
            get
            {
                return new Command(
                    (sender) =>
                    {
                        if (sender is Button button)
                        {
                            if (button.ClassId == "_positiveButton")
                            {
                                if (OnPositiveButtonCmd is Command positiveButton)
                                    positiveButton.Execute(this);
                            }
                            else if (button.ClassId == "_negativeButton")
                            {
                                if (OnNegativeButtonCmd is Command negativeButton)
                                    negativeButton.Execute(this);
                            }
                        }
                    });
            }
        }
    }
}
