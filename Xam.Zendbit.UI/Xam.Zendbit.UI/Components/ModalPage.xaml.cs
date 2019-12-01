using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xam.Zendbit.UI.Components.Resources;

namespace Xam.Zendbit.UI.Components
{
    public partial class ModalPage : TemplatePage
    {
        public ModalPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        public object CommandParameter
        {
            get { return (object)GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        public static readonly BindableProperty CommandParameterProperty =
            BindableProperty.Create(
                nameof(CommandParameter),
                typeof(object),
                typeof(ModalPage),
                null,
                BindingMode.TwoWay);

        public double PaddingOnPlafroms
        {
            get
            {
                switch (Device.RuntimePlatform)
                {
                    case Device.iOS:
                        return 30;
                    case Device.Android:
                        return 0;
                    default:
                        return 0;
                }
            }
        }

        private void PopPage()
        {
            if (TogglePopup)
            {
                ClosePopUp();
            }
            else
            {
                try
                {
                    Navigation.PopAsync(true);
                }
                catch (Exception)
                {
                    Navigation.PopAsync(true);
                }

                if (OnBackCmd != null)
                {
                    if (CommandParameter is null)
                        CommandParameter = this;

                    OnBackCmd.Execute(CommandParameter);
                }
            }
        }

        public ICommand OnBackCmd
        {
            get { return (ICommand)GetValue(OnBackCmdProperty); }
            set { SetValue(OnBackCmdProperty, value); }
        }
        public static readonly BindableProperty OnBackCmdProperty =
            BindableProperty.Create(
                nameof(OnBackCmd),
                typeof(ICommand),
                typeof(ModalPage),
                null,
                BindingMode.TwoWay);

        public ICommand ElementTappedCmd
        {
            get
            {
                return new Command(
                    async (sender) =>
                    {
                        if (sender is Image image)
                        {
                            await AnimateView.Self.TouchEffect(image);

                            if (image.ClassId.Equals("_backIcon"))
                            {
                                PopPage();
                            }
                        }
                    });
            }
        }

        public string TTFontFamily
        {
            get => (string)GetValue(TTFontFamilyProperty);
            set => SetValue(TTFontFamilyProperty, value);
        }

        public static readonly BindableProperty TTFontFamilyProperty =
            BindableProperty.Create(
                nameof(TTFontFamily),
                typeof(string),
                typeof(ModalPage),
                null,
                BindingMode.TwoWay,
                propertyChanged: (s, o, n) =>
                {
                    if (s is ModalPage modalPage && n is string newFontFamily)
                    {
                        modalPage._navigationTextLabel.FontFamily =
                        modalPage._activityTextLabel.FontFamily =
                            Device.RuntimePlatform == Device.Android
                            ? $"{newFontFamily}.ttf#{newFontFamily}"
                            : Device.RuntimePlatform == Device.iOS
                            ? newFontFamily
                            : $"Assets/Fonts/{newFontFamily}.ttf#{newFontFamily}";
                    }
                });

        public string NavigationText
        {
            get { return (string)GetValue(NavigationTextProperty); }
            set { SetValue(NavigationTextProperty, value); }
        }

        public static readonly BindableProperty NavigationTextProperty =
            BindableProperty.Create(
                nameof(NavigationText),
                typeof(string),
                typeof(ModalPage),
                string.Empty,
                BindingMode.TwoWay);

        public double NavigationTextFontSize
        {
            get { return (double)GetValue(NavigationTextFontSizeProperty); }
            set { SetValue(NavigationTextFontSizeProperty, value); }
        }

        public static readonly BindableProperty NavigationTextFontSizeProperty =
            BindableProperty.Create(
                nameof(NavigationTextFontSize),
                typeof(double),
                typeof(ModalPage),
                Device.GetNamedSize(NamedSize.Default, typeof(Label)),
                BindingMode.TwoWay);

        public Color NavigationTextColor
        {
            get { return (Color)GetValue(NavigationTextColorProperty); }
            set { SetValue(NavigationTextColorProperty, value); }
        }

        public static readonly BindableProperty NavigationTextColorProperty =
            BindableProperty.Create(
                nameof(NavigationTextColor),
                typeof(Color),
                typeof(ModalPage),
                null,
                BindingMode.TwoWay);

        public View NavigationRightContent
        {
            get { return (View)GetValue(NavigationRightContentProperty); }
            set { SetValue(NavigationRightContentProperty, value); }
        }

        public static readonly BindableProperty NavigationRightContentProperty =
            BindableProperty.Create(
                nameof(NavigationRightContent),
                typeof(View),
                typeof(ModalPage),
                null,
                BindingMode.TwoWay);

        public View ModalContent
        {
            get { return (View)GetValue(ModalContentProperty); }
            set { SetValue(ModalContentProperty, value); }
        }

        public static readonly BindableProperty ModalContentProperty =
            BindableProperty.Create(
                nameof(ModalContent),
                typeof(View),
                typeof(ModalPage),
                null,
                BindingMode.TwoWay);

        public Color NavigationBackgroundColor
        {
            get { return (Color)GetValue(NavigationBackgroundColorProperty); }
            set { SetValue(NavigationBackgroundColorProperty, value); }
        }

        public static readonly BindableProperty NavigationBackgroundColorProperty =
            BindableProperty.Create(
                nameof(NavigationBackgroundColor),
                typeof(Color),
                typeof(ModalPage),
                null,
                BindingMode.TwoWay);

        public ImageSource BackIcon
        {
            get { return (ImageSource)GetValue(BackIconProperty); }
            set { SetValue(BackIconProperty, value); }
        }

        public static readonly BindableProperty BackIconProperty =
            BindableProperty.Create(
                nameof(BackIcon),
                typeof(ImageSource),
                typeof(ModalPage),
                null,
                BindingMode.TwoWay);

        public double NavigationHeight
        {
            get { return (double)GetValue(NavigationHeightProperty); }
            set { SetValue(NavigationHeightProperty, value); }
        }

        public static readonly BindableProperty NavigationHeightProperty =
            BindableProperty.Create(
                nameof(NavigationHeight),
                typeof(double),
                typeof(ModalPage),
                50.0,
                BindingMode.TwoWay);

        public bool IsActivityRunning
        {
            get { return (bool)GetValue(IsRunningProperty); }
            set { SetValue(IsRunningProperty, value); }
        }

        public static readonly BindableProperty IsRunningProperty =
            BindableProperty.Create(
                nameof(IsActivityRunning),
                typeof(bool),
                typeof(ModalPage),
                false,
                BindingMode.TwoWay);

        public string ActivityText
        {
            get { return (string)GetValue(ActivityTextProperty); }
            set { SetValue(ActivityTextProperty, value); }
        }

        public static readonly BindableProperty ActivityTextProperty =
            BindableProperty.Create(
                nameof(ActivityText),
                typeof(string),
                typeof(ModalPage),
                null,
                BindingMode.TwoWay);

        public Color ActivityTextColor
        {
            get { return (Color)GetValue(ActivityTextColorProperty); }
            set { SetValue(ActivityTextColorProperty, value); }
        }

        public static readonly BindableProperty ActivityTextColorProperty =
            BindableProperty.Create(
                nameof(ActivityTextColor),
                typeof(Color),
                typeof(ModalPage),
                null,
                BindingMode.TwoWay);

        public Color ActivityBackgroundColor
        {
            get { return (Color)GetValue(ActivityBackgroundColorProperty); }
            set { SetValue(ActivityBackgroundColorProperty, value); }
        }

        public static readonly BindableProperty ActivityBackgroundColorProperty =
            BindableProperty.Create(
                nameof(ActivityBackgroundColor),
                typeof(Color),
                typeof(ModalPage),
                null,
                BindingMode.TwoWay);

        protected override bool OnBackButtonPressed()
        {
            PopPage();
            return true;
        }
    }
}
