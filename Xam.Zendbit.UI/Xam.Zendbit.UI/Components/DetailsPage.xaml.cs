using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xam.Zendbit.UI.Components.Resources;

namespace Xam.Zendbit.UI.Components
{
    public partial class DetailsPage : TemplatePage
    {
        public DetailsPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        protected override bool OnBackButtonPressed()
        {
            if (ToggleFlyout)
            {
                ToggleFlyout = !ToggleFlyout;
                return !ToggleFlyout;
            }
            else if (TogglePopup)
            {
                ClosePopUp();
                return !TogglePopup;
            }

            return base.OnBackButtonPressed();
        }

        bool _isElementTappedCmd;
        public ICommand ElementTappedCmd
        {
            get
            {
                return new Command(
                    async (sender) =>
                    {
                        if (_isElementTappedCmd) return;

                        _isElementTappedCmd = !_isElementTappedCmd;

                        if (sender is Image image)
                        {
                            await AnimateView.Self.TouchEffect(image);

                            if (image.ClassId.Equals("_menuIcon"))
                            {
                                ToggleFlyout = !ToggleFlyout;
                            }
                        }
                        else if (sender is BoxView boxView)
                        {
                            if (boxView.ClassId.Equals("_flyoutBgOverlay"))
                            {
                                if (boxView.Parent is Grid parent)
                                {
                                    parent.TranslationX -= parent.Width;
                                    ToggleFlyout = !ToggleFlyout;
                                    await parent.TranslateTo(0, 0, 300, Easing.SinInOut);
                                }
                            }
                        }

                        _isElementTappedCmd = !_isElementTappedCmd;
                    }
                );
            }
        }

        public bool ToggleFlyout
        {
            get { return (bool)GetValue(ToggleFlyoutProperty); }
            set { SetValue(ToggleFlyoutProperty, value); }
        }

        public static readonly BindableProperty ToggleFlyoutProperty =
            BindableProperty.Create(
                nameof(ToggleFlyout),
                typeof(bool),
                typeof(DetailsPage),
                false,
                BindingMode.TwoWay
            );

        public double PaddingOnPlafroms
        {
            get
            {
                switch (Device.RuntimePlatform)
                {
                    case Device.iOS:
                        return 25;
                    case Device.Android:
                        return 0;
                    default:
                        return 0;
                }
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
                typeof(DetailsPage),
                null,
                BindingMode.TwoWay,
                propertyChanged: (s, o, n) =>
                {
                    if (s is DetailsPage detailsPage && n is string newFontFamily)
                    {
                        detailsPage._navigationTextLabel.FontFamily =
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
                typeof(DetailsPage),
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
                typeof(DetailsPage),
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
                typeof(DetailsPage),
                null,
                BindingMode.TwoWay);

        public Color FlyoutBackgroundColor
        {
            get { return (Color)GetValue(FlyoutBackgroundColorProperty); }
            set { SetValue(FlyoutBackgroundColorProperty, value); }
        }

        public static readonly BindableProperty FlyoutBackgroundColorProperty =
            BindableProperty.Create(
                nameof(FlyoutBackgroundColor),
                typeof(Color),
                typeof(DetailsPage),
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
                typeof(DetailsPage),
                null,
                BindingMode.TwoWay);

        public View DetailsContent
        {
            get { return (View)GetValue(DetailsContentProperty); }
            set { SetValue(DetailsContentProperty, value); }
        }

        public static readonly BindableProperty DetailsContentProperty =
            BindableProperty.Create(
                nameof(DetailsContent),
                typeof(View),
                typeof(DetailsPage),
                null,
                BindingMode.TwoWay);

        public View FlyoutContent
        {
            get { return (View)GetValue(FlyoutContentProperty); }
            set { SetValue(FlyoutContentProperty, value); }
        }

        public static readonly BindableProperty FlyoutContentProperty =
            BindableProperty.Create(
                nameof(FlyoutContent),
                typeof(View),
                typeof(DetailsPage),
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
                typeof(DetailsPage),
                null,
                BindingMode.TwoWay);

        public ImageSource MenuIcon
        {
            get { return (ImageSource)GetValue(MenuIconProperty); }
            set { SetValue(MenuIconProperty, value); }
        }

        public static readonly BindableProperty MenuIconProperty =
            BindableProperty.Create(
                nameof(MenuIcon),
                typeof(ImageSource),
                typeof(DetailsPage),
                null,
                BindingMode.TwoWay,
                propertyChanged: (s, o, n) =>
                {
                    if (s is DetailsPage detailsPage)
                    {
                        detailsPage._menuIcon.Source = (ImageSource)n;
                    }
                }
            );

        public double NavigationHeight
        {
            get { return (double)GetValue(NavigationHeightProperty); }
            set { SetValue(NavigationHeightProperty, value); }
        }

        public static readonly BindableProperty NavigationHeightProperty =
            BindableProperty.Create(
                nameof(NavigationHeight),
                typeof(double),
                typeof(DetailsPage),
                50.0,
                BindingMode.TwoWay);
    }
}
