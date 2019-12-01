using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace Xam.Zendbit.UI.Components
{
    public partial class PickerField : TemplateView
    {
        public PickerField()
        {
            InitializeComponent();
        }

        public IList<object> ItemSource
        {
            get { return (IList<object>)GetValue(ItemSourceProperty); }
            set { SetValue(ItemSourceProperty, value); }
        }

        public static readonly BindableProperty ItemSourceProperty =
            BindableProperty.Create(
                nameof(ItemSource),
                typeof(IList<object>),
                typeof(PickerField),
                null,
                BindingMode.TwoWay,
                propertyChanged: (s, o, n) =>
                {
                    if (s is PickerField pickerField)
                    {
                        pickerField._picker.ItemsSource = (System.Collections.IList)(IList<object>)n;
                    }
                });

        public int SelectedIndex
        {
            get { return (int)GetValue(SelectedIndexProperty); }
            set { SetValue(SelectedIndexProperty, value); }
        }

        public static readonly BindableProperty SelectedIndexProperty =
            BindableProperty.Create(
                nameof(SelectedIndex),
                typeof(int),
                typeof(PickerField),
                -1,
                BindingMode.TwoWay,
                propertyChanged: (s, o, n) =>
                {
                    if (s is PickerField pickerField)
                    {
                        pickerField._picker.SelectedIndex = (int)n;
                    }
                });

        public object SelectedItem
        {
            get { return (object)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }

        public static readonly BindableProperty SelectedItemProperty =
            BindableProperty.Create(
                nameof(SelectedItem),
                typeof(object),
                typeof(PickerField),
                null,
                BindingMode.TwoWay,
                propertyChanged: (s, o, n) =>
                {
                    if (s is PickerField pickerField)
                    {
                        pickerField._picker.SelectedItem = n;
                    }
                });

        public string ItemDisplayBinding
        {
            get { return (string)GetValue(ItemDisplayBindingProperty); }
            set { SetValue(ItemDisplayBindingProperty, value); }
        }

        public static readonly BindableProperty ItemDisplayBindingProperty =
            BindableProperty.Create(
                nameof(ItemDisplayBinding),
                typeof(string),
                typeof(PickerField),
                null,
                BindingMode.TwoWay);

        public string TTFontFamily
        {
            get => (string)GetValue(TTFontFamilyProperty);
            set => SetValue(TTFontFamilyProperty, value);
        }

        public static readonly BindableProperty TTFontFamilyProperty =
            BindableProperty.Create(
                nameof(TTFontFamily),
                typeof(string),
                typeof(PickerField),
                null,
                BindingMode.TwoWay,
                propertyChanged: (s, o, n) =>
                {
                    if (s is PickerField pickerField && n is string newFontFamily)
                    {
                        pickerField._fieldLabel.FontFamily =
                        pickerField._msgLabel.FontFamily =
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
                typeof(PickerField),
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
                typeof(PickerField),
                Device.GetNamedSize(NamedSize.Default, typeof(Label)),
                BindingMode.TwoWay);

        public double PickerFontSize
        {
            get { return (double)GetValue(PickerFontSizeProperty); }
            set { SetValue(PickerFontSizeProperty, value); }
        }

        public static readonly BindableProperty PickerFontSizeProperty =
            BindableProperty.Create(
                nameof(PickerFontSize),
                typeof(double),
                typeof(PickerField),
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
                typeof(PickerField),
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
                typeof(PickerField),
                null,
                BindingMode.TwoWay);

        public Color PickerBackgroundColor
        {
            get { return (Color)GetValue(PickerBackgroundColorProperty); }
            set { SetValue(PickerBackgroundColorProperty, value); }
        }

        public static readonly BindableProperty PickerBackgroundColorProperty =
            BindableProperty.Create(
                nameof(PickerBackgroundColor),
                typeof(Color),
                typeof(PickerField),
                null,
                BindingMode.TwoWay);

        public Color PickerTextColor
        {
            get { return (Color)GetValue(PickerTextColorProperty); }
            set { SetValue(PickerTextColorProperty, value); }
        }

        public static readonly BindableProperty PickerTextColorProperty =
            BindableProperty.Create(
                nameof(PickerTextColor),
                typeof(Color),
                typeof(PickerField),
                null,
                BindingMode.TwoWay);

        public string PickerText
        {
            get { return (string)GetValue(PickerTextProperty); }
            set { SetValue(PickerTextProperty, value); }
        }

        public static readonly BindableProperty PickerTextProperty =
            BindableProperty.Create(
                nameof(PickerText),
                typeof(string),
                typeof(PickerField),
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
                typeof(PickerField),
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
                typeof(PickerField),
                null,
                BindingMode.TwoWay);

        public Color PickerBorderColor
        {
            get { return (Color)GetValue(PickerBorderColorProperty); }
            set { SetValue(PickerBorderColorProperty, value); }
        }

        public static readonly BindableProperty PickerBorderColorProperty =
            BindableProperty.Create(
                nameof(PickerBorderColor),
                typeof(Color),
                typeof(PickerField),
                null,
                BindingMode.TwoWay);

        public float PickerCornerRadius
        {
            get { return (float)GetValue(PickerCornerRadiusProperty); }
            set { SetValue(PickerCornerRadiusProperty, value); }
        }

        public static readonly BindableProperty PickerCornerRadiusProperty =
            BindableProperty.Create(
                nameof(PickerCornerRadius),
                typeof(float),
                typeof(PickerField),
                (float)3,
                BindingMode.TwoWay);

        public Color PickerFocusBackgroundColor
        {
            get { return (Color)GetValue(PickerFocusBackgroundColorProperty); }
            set { SetValue(PickerFocusBackgroundColorProperty, value); }
        }

        public static readonly BindableProperty PickerFocusBackgroundColorProperty =
            BindableProperty.Create(
                nameof(PickerFocusBackgroundColor),
                typeof(Color),
                typeof(PickerField),
                null,
                BindingMode.TwoWay
            );

        public new bool IsFocused { get => _picker.IsFocused; }
        public new void Focus() => _picker.Focus();
        public new void Unfocus() => _picker.Unfocus();

        public ICommand OnPickerFocusedCmd
        {
            get { return (ICommand)GetValue(OnPickerFocusedCmdProperty); }
            set { SetValue(OnPickerFocusedCmdProperty, value); }
        }

        public static readonly BindableProperty OnPickerFocusedCmdProperty =
            BindableProperty.Create(
                nameof(OnPickerFocusedCmd),
                typeof(ICommand),
                typeof(PickerField),
                null,
                BindingMode.TwoWay);
        private void PickerFocusedEvent(object sender, FocusEventArgs e)
        {
            if (sender is Picker datePicker)
            {
                if (e.IsFocused)
                {
                    if (!PickerFocusBackgroundColor.Equals(PickerBackgroundColor))
                        datePicker.BackgroundColor = PickerFocusBackgroundColor;
                }
                else
                {
                    datePicker.BackgroundColor = PickerBackgroundColor;
                }

                if (OnPickerFocusedCmd != null)
                    OnPickerFocusedCmd.Execute(sender);
            }
        }

        public ICommand SelectedIndexChangedCmd
        {
            get { return (ICommand)GetValue(SelectedIndexChangedCmdProperty); }
            set { SetValue(SelectedIndexChangedCmdProperty, value); }
        }

        public static readonly BindableProperty SelectedIndexChangedCmdProperty =
            BindableProperty.Create(
                nameof(SelectedIndexChangedCmd),
                typeof(ICommand),
                typeof(PickerField),
                null,
                BindingMode.TwoWay
            );

        private void SelectedIndexChangedEvent(object sender, EventArgs e)
        {
            if (sender is Picker picker)
            {
                try
                {
                    SelectedIndex = picker.SelectedIndex;
                    if (SelectedIndex != -1)
                    {
                        SelectedItem = ItemSource[SelectedIndex];
                    }

                    if (SelectedIndexChangedCmd != null)
                    {
                        SelectedIndexChangedCmd.Execute(this);
                    }
                }
                catch (Exception ex) { Debug.WriteLine(ex.StackTrace); }
            }
        }

        public Color PickerDisabledBackgroundColor
        {
            get { return (Color)GetValue(PickerDisabledBackgroundColorProperty); }
            set { SetValue(PickerDisabledBackgroundColorProperty, value); }
        }

        public static readonly BindableProperty PickerDisabledBackgroundColorProperty =
            BindableProperty.Create(
                nameof(PickerDisabledBackgroundColor),
                typeof(Color),
                typeof(PickerField),
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
                typeof(PickerField),
                true,
                BindingMode.TwoWay,
                propertyChanged: (s, o, n) =>
                {
                    if (s is PickerField pickerField)
                    {
                        if (pickerField._picker.IsEnabled)
                            pickerField._picker.BackgroundColor = pickerField.PickerBackgroundColor;
                        else
                            pickerField._picker.BackgroundColor = pickerField.PickerDisabledBackgroundColor;

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
                typeof(PickerField),
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
                typeof(PickerField),
                null,
                BindingMode.TwoWay);
    }
}
