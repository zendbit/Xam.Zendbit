using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;
using Xam.Zendbit.UI.Components;

namespace Xam.Zendbit.UI.Components
{
    public partial class PopUpView : TemplateView
    {
        public PopUpView()
        {
            InitializeComponent();
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
                typeof(PopUpView),
                null,
                BindingMode.TwoWay,
                propertyChanged: (s, o, n) =>
                {
                    if (s is PopUpView popUpView && n is string newFontFamily)
                    {
                        popUpView._navigationTextLabel.FontFamily =
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
                typeof(PopUpView),
                null,
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
                typeof(PopUpView),
                Device.GetNamedSize(NamedSize.Default, typeof(Label)),
                BindingMode.TwoWay);

        public ImageSource NavigationCloseIcon
        {
            get { return (ImageSource)GetValue(NavigationCloseIconProperty); }
            set { SetValue(NavigationCloseIconProperty, value); }
        }

        public static readonly BindableProperty NavigationCloseIconProperty =
            BindableProperty.Create(
                nameof(NavigationCloseIcon),
                typeof(ImageSource),
                typeof(PopUpView),
                null,
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
                typeof(PopUpView),
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
                typeof(PopUpView),
                null,
                BindingMode.TwoWay);

        public new Color BackgroundColor
        {
            get { return (Color)GetValue(BackgroundColorProperty); }
            set { SetValue(BackgroundColorProperty, value); }
        }

        public new static readonly BindableProperty BackgroundColorProperty =
            BindableProperty.Create(
                nameof(BackgroundColor),
                typeof(Color),
                typeof(PopUpView),
                null,
                BindingMode.TwoWay);

        public View PopUpContent
        {
            get { return (View)GetValue(PopUpContentProperty); }
            set { SetValue(PopUpContentProperty, value); }
        }

        public static readonly BindableProperty PopUpContentProperty =
            BindableProperty.Create(
                nameof(PopUpContent),
                typeof(View),
                typeof(PopUpView),
                null,
                BindingMode.TwoWay);

        public double NavigationHeight
        {
            get { return (double)GetValue(NavigationHeightProperty); }
            set { SetValue(NavigationHeightProperty, value); }
        }

        public static readonly BindableProperty NavigationHeightProperty =
            BindableProperty.Create(
                nameof(PopUpContent),
                typeof(double),
                typeof(PopUpView),
                50.0,
                BindingMode.TwoWay);

        public float CornerRadius
        {
            get { return (float)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public static readonly BindableProperty CornerRadiusProperty =
            BindableProperty.Create(
                nameof(CornerRadius),
                typeof(float),
                typeof(PopUpView),
                (float)0,
                BindingMode.TwoWay);

        public ICommand OnCloseCmd
        {
            get { return (ICommand)GetValue(OnCloseCmdProperty); }
            set { SetValue(OnCloseCmdProperty, value); }
        }

        public static readonly BindableProperty OnCloseCmdProperty =
            BindableProperty.Create(
                nameof(OnCloseCmd),
                typeof(ICommand),
                typeof(PopUpView),
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

                            if (image.ClassId.Equals("_closeIcon"))
                            {
                                if (Application.Current.MainPage is NavigationPage navigationPage)
                                {
                                    if (navigationPage.CurrentPage is TemplatePage templatePage)
                                        templatePage.ClosePopUp();

                                    if (OnCloseCmd != null)
                                    {
                                        OnCloseCmd.Execute(this);
                                    }
                                }
                            }
                        }
                    });
            }
        }
    }
}
