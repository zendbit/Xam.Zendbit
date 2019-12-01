using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Input;
using Xamarin.Forms;
using Xam.Zendbit.UI.Components.Resources;

namespace Xam.Zendbit.UI.Components
{
    public partial class EntryField : TemplateView
    {
        public EntryField()
        {
            InitializeComponent();
        }

        public string LabelText
        {
            get { return (string)GetValue(LabelTextProperty); }
            set { SetValue(LabelTextProperty, value); }
        }

        public static readonly BindableProperty LabelTextProperty =
            BindableProperty.Create(
                nameof(LabelText),
                typeof(string),
                typeof(EntryField),
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
                typeof(EntryField),
                Device.GetNamedSize(NamedSize.Default, typeof(Label)),
                BindingMode.TwoWay);

        public double EntryFontSize
        {
            get { return (double)GetValue(EntryFontSizeProperty); }
            set { SetValue(EntryFontSizeProperty, value); }
        }

        public static readonly BindableProperty EntryFontSizeProperty =
            BindableProperty.Create(
                nameof(EntryFontSize),
                typeof(double),
                typeof(EntryField),
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
                typeof(EntryField),
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
                typeof(EntryField),
                null,
                BindingMode.TwoWay);

        public Color EntryBackgroundColor
        {
            get { return (Color)GetValue(EntryBackgroundColorProperty); }
            set { SetValue(EntryBackgroundColorProperty, value); }
        }

        public static readonly BindableProperty EntryBackgroundColorProperty =
            BindableProperty.Create(
                nameof(EntryBackgroundColor),
                typeof(Color),
                typeof(EntryField),
                null,
                BindingMode.TwoWay);

        public Color EntryDisabledBackgroundColor
        {
            get { return (Color)GetValue(EntryDisabledBackgroundColorProperty); }
            set { SetValue(EntryDisabledBackgroundColorProperty, value); }
        }

        public static readonly BindableProperty EntryDisabledBackgroundColorProperty =
            BindableProperty.Create(
                nameof(EntryDisabledBackgroundColor),
                typeof(Color),
                typeof(EntryField),
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
                typeof(EntryField),
                true,
                BindingMode.TwoWay,
                propertyChanged: (s, o, n) =>
                {
                    if (s is EntryField entryField)
                    {
                        entryField._entry.IsEnabled = (bool)n;
                        if (entryField._entry.IsEnabled)
                            entryField._entry.BackgroundColor = entryField.EntryBackgroundColor;
                        else
                            entryField._entry.BackgroundColor = entryField.EntryDisabledBackgroundColor;

                    }
                }
            );

        public string TTFontFamily
        {
            get => (string)GetValue(TTFontFamilyProperty);
            set => SetValue(TTFontFamilyProperty, value);
        }

        public static readonly BindableProperty TTFontFamilyProperty =
            BindableProperty.Create(
                nameof(TTFontFamily),
                typeof(string),
                typeof(EntryField),
                null,
                BindingMode.TwoWay,
                propertyChanged: (s, o, n) =>
                {
                    if (s is EntryField entryField && n is string newFontFamily)
                    {
                        entryField._fieldLabel.FontFamily =
                        entryField._msgLabel.FontFamily =
                            Device.RuntimePlatform == Device.Android
                            ? $"{newFontFamily}.ttf#{newFontFamily}"
                            : Device.RuntimePlatform == Device.iOS
                            ? newFontFamily
                            : $"Assets/Fonts/{newFontFamily}.ttf#{newFontFamily}";
                    }
                });

        public string EntryText
        {
            get { return (string)GetValue(EntryTextProperty); }
            set { SetValue(EntryTextProperty, value); }
        }

        public static readonly BindableProperty EntryTextProperty =
            BindableProperty.Create(
                nameof(EntryText),
                typeof(string),
                typeof(EntryField),
                null,
                BindingMode.TwoWay);

        public string EntryPlaceholder
        {
            get { return (string)GetValue(EntryPlaceholderProperty); }
            set { SetValue(EntryPlaceholderProperty, value); }
        }

        public static readonly BindableProperty EntryPlaceholderProperty =
            BindableProperty.Create(
                nameof(EntryPlaceholder),
                typeof(string),
                typeof(EntryField),
                null,
                BindingMode.TwoWay);

        public Color EntryTextColor
        {
            get { return (Color)GetValue(EntryTextColorProperty); }
            set { SetValue(EntryTextColorProperty, value); }
        }

        public static readonly BindableProperty EntryTextColorProperty =
            BindableProperty.Create(
                nameof(EntryTextColor),
                typeof(Color),
                typeof(EntryField),
                null,
                BindingMode.TwoWay);

        public bool IsPassword
        {
            get { return (bool)GetValue(IsPasswordProperty); }
            set { SetValue(IsPasswordProperty, value); }
        }

        public static readonly BindableProperty IsPasswordProperty =
            BindableProperty.Create(
                nameof(IsPassword),
                typeof(bool),
                typeof(EntryField),
                false,
                BindingMode.TwoWay);

        public Color EntryPlaceholderColor
        {
            get { return (Color)GetValue(EntryPlaceholderColorProperty); }
            set { SetValue(EntryPlaceholderColorProperty, value); }
        }

        public static readonly BindableProperty EntryPlaceholderColorProperty =
            BindableProperty.Create(
                nameof(EntryPlaceholderColor),
                typeof(Color),
                typeof(EntryField),
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
                typeof(EntryField),
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
                typeof(EntryField),
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
                typeof(EntryField),
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
                typeof(EntryField),
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
                typeof(EntryField),
                (float)3,
                BindingMode.TwoWay);

        public Keyboard EntryKeyboard
        {
            get { return (Keyboard)GetValue(EntryKeyboardProperty); }
            set { SetValue(EntryKeyboardProperty, value); }
        }

        public static readonly BindableProperty EntryKeyboardProperty =
            BindableProperty.Create(
                nameof(EntryKeyboard),
                typeof(Keyboard),
                typeof(EntryField),
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
                typeof(EntryField),
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
                typeof(EntryField),
                null,
                BindingMode.TwoWay);

        public new bool IsFocused { get => _entry.IsFocused; }
        public new void Focus() => _entry.Focus();
        public new void Unfocus() => _entry.Unfocus();

        public ICommand OnEntryFocusedCmd
        {
            get { return (ICommand)GetValue(OnEntryFocusedCmdProperty); }
            set { SetValue(OnEntryFocusedCmdProperty, value); }
        }

        public static readonly BindableProperty OnEntryFocusedCmdProperty =
            BindableProperty.Create(
                nameof(OnEntryFocusedCmd),
                typeof(ICommand),
                typeof(EntryField),
                null,
                BindingMode.TwoWay);

        public ICommand OnEntryUnfocusedCmd
        {
            get { return (ICommand)GetValue(OnEntryUnfocusedCmdProperty); }
            set { SetValue(OnEntryUnfocusedCmdProperty, value); }
        }

        public static readonly BindableProperty OnEntryUnfocusedCmdProperty =
            BindableProperty.Create(
                nameof(OnEntryUnfocusedCmd),
                typeof(ICommand),
                typeof(EntryField),
                null,
                BindingMode.TwoWay);

        private void EntryFocusedEvent(object sender, FocusEventArgs e)
        {
            if (sender is Entry entry)
            {
                if (e.IsFocused)
                {
                    if (!EntryFocusBackgroundColor.Equals(EntryBackgroundColor))
                        entry.BackgroundColor = EntryFocusBackgroundColor;

                    if (OnEntryFocusedCmd != null)
                    {
                        OnEntryFocusedCmd.Execute(this);
                    }
                }
                else
                {
                    entry.BackgroundColor = EntryBackgroundColor;

                    if (OnEntryUnfocusedCmd != null)
                    {
                        OnEntryUnfocusedCmd.Execute(this);
                    }
                }
            }
        }

        public Action<object, TextChangedEventArgs> OnTextChangedEvent;
        private void TextChangedEvent(object sender, TextChangedEventArgs e)
        {
            if (sender is Entry entry)
            {
                try
                {
                    OnTextChangedEvent.Invoke(this, e);
                }
                catch (Exception ex) { Debug.WriteLine(ex.StackTrace); }
            }
        }
    }
}
