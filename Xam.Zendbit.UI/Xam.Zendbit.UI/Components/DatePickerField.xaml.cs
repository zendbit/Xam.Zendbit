using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Input;
using Xamarin.Forms;

namespace Xam.Zendbit.UI.Components
{
    public partial class DatePickerField : TemplateView
    {
        public DatePickerField()
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
                typeof(DatePickerField),
                null,
                BindingMode.TwoWay,
                propertyChanged: (s, o, n) =>
                {
                    if (s is DatePickerField datePickerField && n is string newFontFamily)
                    {
                        datePickerField._fieldLabel.FontFamily =
                        datePickerField._msgLabel.FontFamily =
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
                typeof(DatePickerField),
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
                typeof(DatePickerField),
                Device.GetNamedSize(NamedSize.Default, typeof(Label)),
                BindingMode.TwoWay);

        public double DateFontSize
        {
            get { return (double)GetValue(DateFontSizeProperty); }
            set { SetValue(DateFontSizeProperty, value); }
        }

        public static readonly BindableProperty DateFontSizeProperty =
            BindableProperty.Create(
                nameof(DateFontSize),
                typeof(double),
                typeof(DatePickerField),
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
                typeof(DatePickerField),
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
                typeof(DatePickerField),
                null,
                BindingMode.TwoWay);

        public Color DateBackgroundColor
        {
            get { return (Color)GetValue(DateBackgroundColorProperty); }
            set { SetValue(DateBackgroundColorProperty, value); }
        }

        public static readonly BindableProperty DateBackgroundColorProperty =
            BindableProperty.Create(
                nameof(DateBackgroundColor),
                typeof(Color),
                typeof(DatePickerField),
                null,
                BindingMode.TwoWay);

        public DateTime Date
        {
            get { return (DateTime)GetValue(DateProperty); }
            set { SetValue(DateProperty, value); }
        }

        public static readonly BindableProperty DateProperty =
            BindableProperty.Create(
                nameof(Date),
                typeof(DateTime),
                typeof(DatePickerField),
                null,
                BindingMode.TwoWay);

        public string DateFormat
        {
            get { return (string)GetValue(DateFormatProperty); }
            set { SetValue(DateFormatProperty, value); }
        }

        public static readonly BindableProperty DateFormatProperty =
            BindableProperty.Create(
                nameof(DateFormat),
                typeof(string),
                typeof(DatePickerField),
                null,
                BindingMode.TwoWay);

        public DateTime MinDate
        {
            get { return (DateTime)GetValue(MinDateProperty); }
            set { SetValue(MinDateProperty, value); }
        }

        public static readonly BindableProperty MinDateProperty =
            BindableProperty.Create(
                nameof(MinDate),
                typeof(DateTime),
                typeof(DatePickerField),
                null,
                BindingMode.TwoWay,
                propertyChanged: (s, o, n) =>
                {
                    if (s is DatePickerField datePickerField)
                    {
                        datePickerField._datePicker.MinimumDate = (DateTime)n;
                    }
                });

        public DateTime MaxDate
        {
            get { return (DateTime)GetValue(MaxDateProperty); }
            set { SetValue(MaxDateProperty, value); }
        }

        public static readonly BindableProperty MaxDateProperty =
            BindableProperty.Create(
                nameof(MaxDate),
                typeof(DateTime),
                typeof(DatePickerField),
                null,
                BindingMode.TwoWay,
                propertyChanged: (s, o, n) =>
                {
                    if (s is DatePickerField datePickerField)
                    {
                        datePickerField._datePicker.MaximumDate = (DateTime)n;
                    }
                });

        public Color DateTextColor
        {
            get { return (Color)GetValue(DateTextColorProperty); }
            set { SetValue(DateTextColorProperty, value); }
        }


        public static readonly BindableProperty DateTextColorProperty =
            BindableProperty.Create(
                nameof(DateTextColor),
                typeof(Color),
                typeof(DatePickerField),
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
                typeof(DatePickerField),
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
                typeof(DatePickerField),
                null,
                BindingMode.TwoWay);

        public Color DateBorderColor
        {
            get { return (Color)GetValue(DateBorderColorProperty); }
            set { SetValue(DateBorderColorProperty, value); }
        }

        public static readonly BindableProperty DateBorderColorProperty =
            BindableProperty.Create(
                nameof(DateBorderColor),
                typeof(Color),
                typeof(DatePickerField),
                null,
                BindingMode.TwoWay);

        public float DateCornerRadius
        {
            get { return (float)GetValue(DateCornerRadiusProperty); }
            set { SetValue(DateCornerRadiusProperty, value); }
        }

        public static readonly BindableProperty DateCornerRadiusProperty =
            BindableProperty.Create(
                nameof(DateCornerRadius),
                typeof(float),
                typeof(DatePickerField),
                (float)3,
                BindingMode.TwoWay);

        public Color DateFocusBackgroundColor
        {
            get { return (Color)GetValue(DateFocusBackgroundColorProperty); }
            set { SetValue(DateFocusBackgroundColorProperty, value); }
        }

        public static readonly BindableProperty DateFocusBackgroundColorProperty =
            BindableProperty.Create(
                nameof(DateFocusBackgroundColor),
                typeof(Color),
                typeof(DatePickerField),
                null,
                BindingMode.TwoWay
            );

        public new bool IsFocused { get => _datePicker.IsFocused; }
        public new void Focus() => _datePicker.Focus();
        public new void Unfocus() => _datePicker.Unfocus();

        public ICommand OnDatePickerFocusedCmd
        {
            get { return (ICommand)GetValue(OnDatePickerFocusedCmdProperty); }
            set { SetValue(OnDatePickerFocusedCmdProperty, value); }
        }

        public static readonly BindableProperty OnDatePickerFocusedCmdProperty =
            BindableProperty.Create(
                nameof(OnDatePickerFocusedCmd),
                typeof(ICommand),
                typeof(DatePickerField),
                null,
                BindingMode.TwoWay);

        private void DatePickerFocusedEvent(object sender, FocusEventArgs e)
        {
            if (sender is DatePicker datePicker)
            {
                if (e.IsFocused)
                {
                    if (!DateFocusBackgroundColor.Equals(DateBackgroundColor))
                        datePicker.BackgroundColor = DateFocusBackgroundColor;
                }
                else
                {
                    datePicker.BackgroundColor = DateBackgroundColor;
                }

                if (OnDatePickerFocusedCmd != null)
                    OnDatePickerFocusedCmd.Execute(sender);
            }
        }

        public ICommand OnDateSelectedCmd
        {
            get { return (ICommand)GetValue(OnDateSelectedCmdProperty); }
            set { SetValue(OnDateSelectedCmdProperty, value); }
        }

        public static readonly BindableProperty OnDateSelectedCmdProperty =
            BindableProperty.Create(
                nameof(OnDateSelectedCmd),
                typeof(ICommand),
                typeof(DatePickerField),
                null,
                BindingMode.TwoWay);

        private void DateSelectedEvent(object sender, DateChangedEventArgs e)
        {
            if (sender is DatePicker)
            {
                if (OnDateSelectedCmd != null)
                    OnDateSelectedCmd.Execute(sender);
            }
        }

        public Color DateDisabledBackgroundColor
        {
            get { return (Color)GetValue(DateDisabledBackgroundColorProperty); }
            set { SetValue(DateDisabledBackgroundColorProperty, value); }
        }

        public static readonly BindableProperty DateDisabledBackgroundColorProperty =
            BindableProperty.Create(
                nameof(DateDisabledBackgroundColor),
                typeof(Color),
                typeof(DatePickerField),
                null,
                BindingMode.TwoWay
            );

        public new double HeightRequest
        {
            get { return (double)GetValue(HeightRequestProperty); }
            set { SetValue(HeightRequestProperty, value); }
        }

        public new static readonly BindableProperty HeightRequestProperty =
            BindableProperty.Create(
                nameof(HeightRequest),
                typeof(double),
                typeof(DatePickerField),
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
                typeof(DatePickerField),
                null,
                BindingMode.TwoWay);

        public new bool IsEnabled
        {
            get { return (bool)GetValue(IsEnabledProperty); }
            set { SetValue(IsEnabledProperty, value); }
        }

        public new static readonly BindableProperty IsEnabledProperty =
            BindableProperty.Create(
                nameof(IsEnabled),
                typeof(bool),
                typeof(DatePickerField),
                true,
                BindingMode.TwoWay,
                propertyChanged: (s, o, n) =>
                {
                    if (s is DatePickerField datePickerField)
                    {
                        if (datePickerField._datePicker.IsEnabled)
                            datePickerField._datePicker.BackgroundColor = datePickerField.DateBackgroundColor;
                        else
                            datePickerField._datePicker.BackgroundColor = datePickerField.DateDisabledBackgroundColor;

                    }
                }
            );
    }
}
