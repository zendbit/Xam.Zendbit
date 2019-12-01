using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Input;
using Xamarin.Forms;

namespace Xam.Zendbit.UI.Components
{
    public partial class TimePickerField : TemplateView
    {
        public TimePickerField()
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
                typeof(TimePickerField),
                null,
                BindingMode.TwoWay,
                propertyChanged: (s, o, n) =>
                {
                    if (s is TimePickerField timePickerField && n is string newFontFamily)
                    {
                        timePickerField._fieldLabel.FontFamily =
                        timePickerField._msgLabel.FontFamily =
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
                typeof(TimePickerField),
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
                typeof(TimePickerField),
                Device.GetNamedSize(NamedSize.Default, typeof(Label)),
                BindingMode.TwoWay);

        public double TimePickerFontSize
        {
            get { return (double)GetValue(TimePickerFontSizeProperty); }
            set { SetValue(TimePickerFontSizeProperty, value); }
        }

        public static readonly BindableProperty TimePickerFontSizeProperty =
            BindableProperty.Create(
                nameof(TimePickerFontSize),
                typeof(double),
                typeof(TimePickerField),
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
                typeof(TimePickerField),
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
                typeof(TimePickerField),
                null,
                BindingMode.TwoWay);

        public Color TimeBackgroundColor
        {
            get { return (Color)GetValue(TimeBackgroundColorProperty); }
            set { SetValue(TimeBackgroundColorProperty, value); }
        }

        public static readonly BindableProperty TimeBackgroundColorProperty =
            BindableProperty.Create(
                nameof(TimeBackgroundColor),
                typeof(Color),
                typeof(TimePickerField),
                null,
                BindingMode.TwoWay);

        public TimeSpan Time
        {
            get { return (TimeSpan)GetValue(TimeProperty); }
            set { SetValue(TimeProperty, value); }
        }

        public static readonly BindableProperty TimeProperty =
            BindableProperty.Create(
                nameof(Time),
                typeof(TimeSpan),
                typeof(TimePickerField),
                null,
                BindingMode.TwoWay);

        public string TimeFormat
        {
            get { return (string)GetValue(TimeFormatProperty); }
            set { SetValue(TimeFormatProperty, value); }
        }

        public static readonly BindableProperty TimeFormatProperty =
            BindableProperty.Create(
                nameof(TimeFormat),
                typeof(string),
                typeof(TimePickerField),
                null,
                BindingMode.TwoWay);

        public Color TimeTextColor
        {
            get { return (Color)GetValue(TimeTextColorProperty); }
            set { SetValue(TimeTextColorProperty, value); }
        }


        public static readonly BindableProperty TimeTextColorProperty =
            BindableProperty.Create(
                nameof(TimeTextColor),
                typeof(Color),
                typeof(TimePickerField),
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
                typeof(TimePickerField),
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
                typeof(TimePickerField),
                null,
                BindingMode.TwoWay);

        public Color TimeBorderColor
        {
            get { return (Color)GetValue(TimeBorderColorProperty); }
            set { SetValue(TimeBorderColorProperty, value); }
        }

        public static readonly BindableProperty TimeBorderColorProperty =
            BindableProperty.Create(
                nameof(TimeBorderColor),
                typeof(Color),
                typeof(TimePickerField),
                null,
                BindingMode.TwoWay);

        public float TimeCornerRadius
        {
            get { return (float)GetValue(TimeCornerRadiusProperty); }
            set { SetValue(TimeCornerRadiusProperty, value); }
        }

        public static readonly BindableProperty TimeCornerRadiusProperty =
            BindableProperty.Create(
                nameof(TimeCornerRadius),
                typeof(float),
                typeof(TimePickerField),
                (float)3,
                BindingMode.TwoWay);

        public Color TimeFocusBackgroundColor
        {
            get { return (Color)GetValue(TimeFocusBackgroundColorProperty); }
            set { SetValue(TimeFocusBackgroundColorProperty, value); }
        }

        public static readonly BindableProperty TimeFocusBackgroundColorProperty =
            BindableProperty.Create(
                nameof(TimeFocusBackgroundColor),
                typeof(Color),
                typeof(TimePickerField),
                null,
                BindingMode.TwoWay
            );

        public new bool IsFocused { get => _timePicker.IsFocused; }
        public new void Focus() => _timePicker.Focus();
        public new void Unfocus() => _timePicker.Unfocus();

        public ICommand OnTimePickerFocusedCmd
        {
            get { return (ICommand)GetValue(OnTimePickerFocusedCmdProperty); }
            set { SetValue(OnTimePickerFocusedCmdProperty, value); }
        }

        public static readonly BindableProperty OnTimePickerFocusedCmdProperty =
            BindableProperty.Create(
                nameof(OnTimePickerFocusedCmd),
                typeof(ICommand),
                typeof(TimePickerField),
                null,
                BindingMode.TwoWay);

        private void TimePickerFocusedEvent(object sender, FocusEventArgs e)
        {
            if (sender is TimePicker timePicker)
            {
                if (e.IsFocused)
                {
                    if (!TimeFocusBackgroundColor.Equals(TimeBackgroundColor))
                        timePicker.BackgroundColor = TimeFocusBackgroundColor;
                }
                else
                {
                    timePicker.BackgroundColor = TimeBackgroundColor;
                }

                if (OnTimePickerFocusedCmd != null)
                    OnTimePickerFocusedCmd.Execute(sender);
            }
        }

        public ICommand OnTimeSelectedCmd
        {
            get { return (ICommand)GetValue(OnTimeSelectedCmdProperty); }
            set { SetValue(OnTimeSelectedCmdProperty, value); }
        }

        public static readonly BindableProperty OnTimeSelectedCmdProperty =
            BindableProperty.Create(
                nameof(OnTimeSelectedCmd),
                typeof(ICommand),
                typeof(TimePickerField),
                null,
                BindingMode.TwoWay);

        public Color TimeDisabledBackgroundColor
        {
            get { return (Color)GetValue(TimeDisabledBackgroundColorProperty); }
            set { SetValue(TimeDisabledBackgroundColorProperty, value); }
        }

        public static readonly BindableProperty TimeDisabledBackgroundColorProperty =
            BindableProperty.Create(
                nameof(TimeDisabledBackgroundColor),
                typeof(Color),
                typeof(TimePickerField),
                null,
                BindingMode.TwoWay
            );

        public new bool IsEnabled
        {
            get { return (bool)GetValue(IsEnabledProperty); }
            set { SetValue(IsEnabledProperty, value); }
        }

        public new static readonly BindableProperty IsEnabledProperty =
            BindableProperty.Create(
                nameof(IsEnabled),
                typeof(bool),
                typeof(TimePickerField),
                true,
                BindingMode.TwoWay,
                propertyChanged: (s, o, n) =>
                {
                    if (s is TimePickerField timePickerField)
                    {
                        if (timePickerField._timePicker.IsEnabled)
                            timePickerField._timePicker.BackgroundColor = timePickerField.TimeBackgroundColor;
                        else
                            timePickerField._timePicker.BackgroundColor = timePickerField.TimeDisabledBackgroundColor;

                    }
                }
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
                typeof(TimePickerField),
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
                typeof(TimePickerField),
                null,
                BindingMode.TwoWay);
    }
}
