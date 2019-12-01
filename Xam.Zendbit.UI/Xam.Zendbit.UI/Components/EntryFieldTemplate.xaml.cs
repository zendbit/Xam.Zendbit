using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;
using Xam.Zendbit.UI.Components.Resources;

namespace Xam.Zendbit.UI.Components
{
    public partial class EntryFieldTemplate : TemplateView
    {
        public EntryFieldTemplate()
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
                typeof(EntryFieldTemplate),
                null,
                BindingMode.TwoWay,
                propertyChanged: (s, o, n) =>
                {
                    if (s is EntryFieldTemplate entryFieldTemplate && n is string newFontFamily)
                    {
                        entryFieldTemplate._fieldLabel.FontFamily =
                        entryFieldTemplate._msgLabel.FontFamily =
                            Device.RuntimePlatform == Device.Android
                            ? $"{newFontFamily}.ttf#{newFontFamily}"
                            : Device.RuntimePlatform == Device.iOS
                            ? newFontFamily
                            : $"Assets/Fonts/{newFontFamily}.ttf#{newFontFamily}";
                    }
                });

        public string LabelText
        {
            get { return (string)GetValue(LabelTextProperty); }
            set { SetValue(LabelTextProperty, value); }
        }

        public static readonly BindableProperty LabelTextProperty =
            BindableProperty.Create(
                nameof(LabelText),
                typeof(string),
                typeof(EntryFieldTemplate),
                null,
                BindingMode.TwoWay);

        public double LabelFontSize
        {
            get { return (double)GetValue(LabelFontSizeProperty); }
            set { SetValue(LabelFontSizeProperty, value); }
        }

        public static readonly BindableProperty LabelFontSizeProperty =
            BindableProperty.Create(
                nameof(LabelFontSize),
                typeof(double),
                typeof(EntryFieldTemplate),
                Device.GetNamedSize(NamedSize.Default, typeof(Label)),
                BindingMode.TwoWay);

        public Color LabelTextColor
        {
            get { return (Color)GetValue(LabelTextColorProperty); }
            set { SetValue(LabelTextColorProperty, value); }
        }

        public static readonly BindableProperty LabelTextColorProperty =
            BindableProperty.Create(
                nameof(LabelTextColor),
                typeof(Color),
                typeof(EntryFieldTemplate),
                null,
                BindingMode.TwoWay);

        public Color LabelBackgroundColor
        {
            get { return (Color)GetValue(LabelBackgroundColorProperty); }
            set { SetValue(LabelBackgroundColorProperty, value); }
        }

        public static readonly BindableProperty LabelBackgroundColorProperty =
            BindableProperty.Create(
                nameof(LabelBackgroundColor),
                typeof(Color),
                typeof(EntryFieldTemplate),
                null,
                BindingMode.TwoWay);

        public string MsgText
        {
            get { return (string)GetValue(MsgTextProperty); }
            set { SetValue(MsgTextProperty, value); }
        }

        public static readonly BindableProperty MsgTextProperty =
            BindableProperty.Create(
                nameof(MsgText),
                typeof(string),
                typeof(EntryFieldTemplate),
                null,
                BindingMode.TwoWay);

        public Color MsgTextColor
        {
            get { return (Color)GetValue(MsgTextColorProperty); }
            set { SetValue(MsgTextColorProperty, value); }
        }

        public static readonly BindableProperty MsgTextColorProperty =
            BindableProperty.Create(
                nameof(MsgTextColor),
                typeof(Color),
                typeof(EntryFieldTemplate),
                null,
                BindingMode.TwoWay);

        public Color EntryFocusBackgroundColor
        {
            get { return (Color)GetValue(EntryFocusBackgroundColorProperty); }
            set { SetValue(EntryFocusBackgroundColorProperty, value); }
        }

        public static readonly BindableProperty EntryFocusBackgroundColorProperty =
            BindableProperty.Create(
                nameof(EntryFocusBackgroundColor),
                typeof(Color),
                typeof(EntryFieldTemplate),
                null,
                BindingMode.TwoWay
            );

        public Color EntryBorderColor
        {
            get { return (Color)GetValue(EntryBorderColorProperty); }
            set { SetValue(EntryBorderColorProperty, value); }
        }

        public static readonly BindableProperty EntryBorderColorProperty =
            BindableProperty.Create(
                nameof(EntryBorderColor),
                typeof(Color),
                typeof(EntryFieldTemplate),
                null,
                BindingMode.TwoWay);

        public float EntryCornerRadius
        {
            get { return (float)GetValue(EntryCornerRadiusProperty); }
            set { SetValue(EntryCornerRadiusProperty, value); }
        }

        public static readonly BindableProperty EntryCornerRadiusProperty =
            BindableProperty.Create(
                nameof(EntryCornerRadius),
                typeof(float),
                typeof(EntryFieldTemplate),
                (float)3,
                BindingMode.TwoWay);

        public View EntryFieldTemplateContent
        {
            get { return (View)GetValue(EntryFieldTemplateContentProperty); }
            set { SetValue(EntryFieldTemplateContentProperty, value); }
        }

        public static readonly BindableProperty EntryFieldTemplateContentProperty =
            BindableProperty.Create(
                nameof(EntryFieldTemplateContent),
                typeof(View),
                typeof(EntryFieldTemplate),
                null,
                BindingMode.TwoWay);

        public new double HeightRequest
        {
            get { return (double)GetValue(HeightRequestProperty); }
            set { SetValue(HeightRequestProperty, value); }
        }

        public new static readonly BindableProperty HeightRequestProperty =
            BindableProperty.Create(
                nameof(HeightRequest),
                typeof(double),
                typeof(EntryFieldTemplate),
                null,
                BindingMode.TwoWay);

        public new double WidthRequest
        {
            get { return (double)GetValue(WidthRequestProperty); }
            set { SetValue(WidthRequestProperty, value); }
        }

        public new static readonly BindableProperty WidthRequestProperty =
            BindableProperty.Create(
                nameof(WidthRequest),
                typeof(double),
                typeof(EntryFieldTemplate),
                null,
                BindingMode.TwoWay);
    }
}
