using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace Xam.Zendbit.UI.Components
{
    public partial class Button : Frame
    {
        public Button()
        {
            InitializeComponent();
            PropertyChanged += (sender, evt) =>
            {
                if (PropertyChangedCmd != null)
                    PropertyChangedCmd.Execute(this);
            };
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
                typeof(Button),
                null,
                BindingMode.TwoWay,
                propertyChanged: (s, o, n) =>
                {
                    if (s is Button button && n is string newFontFamily)
                    {
                        button._buttonLabel.FontFamily =
                            Device.RuntimePlatform == Device.Android
                            ? $"{newFontFamily}.ttf#{newFontFamily}"
                            : Device.RuntimePlatform == Device.iOS
                            ? newFontFamily
                            : $"Assets/Fonts/{newFontFamily}.ttf#{newFontFamily}";
                    }
                });

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly BindableProperty TextProperty =
            BindableProperty.Create(
                nameof(Text),
                typeof(string),
                typeof(Button),
                string.Empty,
                BindingMode.TwoWay);

        public Color TextColor
        {
            get { return (Color)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }

        public static readonly BindableProperty TextColorProperty =
            BindableProperty.Create(
                nameof(TextColor),
                typeof(Color),
                typeof(Button),
                null,
                BindingMode.TwoWay);

        public FontAttributes FontAttributes
        {
            get { return (FontAttributes)GetValue(FontAttributesProperty); }
            set { SetValue(FontAttributesProperty, value); }
        }

        public static readonly BindableProperty FontAttributesProperty =
            BindableProperty.Create(
                nameof(FontAttributes),
                typeof(FontAttributes),
                typeof(Button),
                FontAttributes.Bold,
                BindingMode.TwoWay);

        public double FontSize
        {
            get { return (double)GetValue(FontSizeProperty); }
            set { SetValue(FontSizeProperty, value); }
        }

        public static readonly BindableProperty FontSizeProperty =
            BindableProperty.Create(
                nameof(FontSize),
                typeof(double),
                typeof(Button),
                Device.GetNamedSize(NamedSize.Default, typeof(Label)),
                BindingMode.TwoWay);

        public LineBreakMode LineBreakMode
        {
            get { return (LineBreakMode)GetValue(LineBreakModeProperty); }
            set { SetValue(LineBreakModeProperty, value); }
        }

        public static readonly BindableProperty LineBreakModeProperty =
            BindableProperty.Create(
                nameof(LineBreakMode),
                typeof(LineBreakMode),
                typeof(Button),
                LineBreakMode.WordWrap,
                BindingMode.TwoWay);

        public string FontFamily
        {
            get { return (string)GetValue(FontFamilyProperty); }
            set { SetValue(FontFamilyProperty, value); }
        }

        public static readonly BindableProperty FontFamilyProperty =
            BindableProperty.Create(
                nameof(FontFamily),
                typeof(string),
                typeof(Button),
                null,
                BindingMode.TwoWay);

        /*public LayoutOptions HorizontalOptions
        {
            get { return (LayoutOptions)GetValue(HorizontalOptionsProperty); }
            set { SetValue(HorizontalOptionsProperty, value); }
        }

        public static readonly BindableProperty HorizontalOptionsProperty =
            BindableProperty.Create(
                nameof(HorizontalOptions),
                typeof(LayoutOptions),
                typeof(Button),
                null,
                BindingMode.TwoWay);*/

        /*public LayoutOptions VerticalOptions
        {
            get { return (LayoutOptions)GetValue(VerticalOptionsProperty); }
            set { SetValue(VerticalOptionsProperty, value); }
        }

        public static readonly BindableProperty VerticalOptionsProperty =
            BindableProperty.Create(
                nameof(VerticalOptions),
                typeof(LayoutOptions),
                typeof(Button),
                null,
                BindingMode.TwoWay);*/

        /*public float CornerRadius
        {
            get { return (float)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public static readonly BindableProperty CornerRadiusProperty =
            BindableProperty.Create(
                nameof(CornerRadius),
                typeof(float),
                typeof(Button),
                null,
                BindingMode.TwoWay);*/

        /*public Color BorderColor
        {
            get { return (Color)GetValue(BorderColorProperty); }
            set { SetValue(BorderColorProperty, value); }
        }

        public static readonly BindableProperty BorderColorProperty =
            BindableProperty.Create(
                nameof(BorderColor),
                typeof(Color),
                typeof(Button),
                null,
                BindingMode.TwoWay);*/

        public ICommand ButtonTappedCmd
        {
            get { return (ICommand)GetValue(ButtonTappedCmdProperty); }
            set { SetValue(ButtonTappedCmdProperty, value); }
        }

        public static readonly BindableProperty ButtonTappedCmdProperty =
            BindableProperty.Create(
                nameof(ButtonTappedCmd),
                typeof(ICommand),
                typeof(Button),
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
                typeof(Button),
                null,
                BindingMode.TwoWay);

        public object PropertyChangedCmdParameter
        {
            get { return GetValue(PropertyChangedCmdParameterProperty); }
            set { SetValue(PropertyChangedCmdParameterProperty, value); }
        }

        public static readonly BindableProperty PropertyChangedCmdParameterProperty =
            BindableProperty.Create(
                nameof(PropertyChangedCmdParameter),
                typeof(object),
                typeof(Button),
                null,
                BindingMode.TwoWay);

        public ICommand PropertyChangedCmd
        {
            get { return (ICommand)GetValue(PropertyChangedCmdProperty); }
            set { SetValue(PropertyChangedCmdProperty, value); }
        }

        public static readonly BindableProperty PropertyChangedCmdProperty =
            BindableProperty.Create(
                nameof(PropertyChangedCmd),
                typeof(ICommand),
                typeof(Button),
                null,
                BindingMode.TwoWay);

        public ICommand ElementTappedCmd
        {
            get
            {
                return new Command(async (sender) =>
                {
                    await AnimateView.Self.TouchEffect(_button);
                    if (ButtonTappedCmd != null)
                    {
                        if (CommandParameter is null)
                            CommandParameter = this;

                        ButtonTappedCmd.Execute(CommandParameter);
                    }
                });
            }
        }
    }
}
