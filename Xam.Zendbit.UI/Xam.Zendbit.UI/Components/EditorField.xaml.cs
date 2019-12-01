using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Input;
using Xamarin.Forms;

namespace Xam.Zendbit.UI.Components
{
    public partial class EditorField : TemplateView
    {
        public EditorField()
        {
            InitializeComponent();
        }

        public EditorAutoSizeOption AutoSize
        {
            get { return (EditorAutoSizeOption)GetValue(AutoSizeProperty); }
            set { SetValue(AutoSizeProperty, value); }
        }

        public static readonly BindableProperty AutoSizeProperty =
            BindableProperty.Create(
                nameof(AutoSize),
                typeof(EditorAutoSizeOption),
                typeof(EditorField),
                EditorAutoSizeOption.TextChanges,
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
                typeof(EditorField),
                Device.GetNamedSize(NamedSize.Default, typeof(Label)),
                BindingMode.TwoWay);

        public double EditorFontSize
        {
            get { return (double)GetValue(EditorFontSizeProperty); }
            set { SetValue(EditorFontSizeProperty, value); }
        }

        public static readonly BindableProperty EditorFontSizeProperty =
            BindableProperty.Create(
                nameof(EditorFontSize),
                typeof(double),
                typeof(EditorField),
                Device.GetNamedSize(NamedSize.Default, typeof(Label)),
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
                typeof(EditorField),
                null,
                BindingMode.TwoWay,
                propertyChanged: (s, o, n) =>
                {
                    if (s is EditorField editorField && n is string newFontFamily)
                    {
                        editorField._fieldLabel.FontFamily =
                        editorField._msgLabel.FontFamily =
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
                typeof(EditorField),
                null,
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
                typeof(EditorField),
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
                typeof(EditorField),
                null,
                BindingMode.TwoWay);

        public Color EditorBackgroundColor
        {
            get { return (Color)GetValue(EditorBackgroundColorProperty); }
            set { SetValue(EditorBackgroundColorProperty, value); }
        }

        public static readonly BindableProperty EditorBackgroundColorProperty =
            BindableProperty.Create(
                nameof(EditorBackgroundColor),
                typeof(Color),
                typeof(EditorField),
                null,
                BindingMode.TwoWay);

        public Color EditorDisabledBackgroundColor
        {
            get { return (Color)GetValue(EditorDisabledBackgroundColorProperty); }
            set { SetValue(EditorDisabledBackgroundColorProperty, value); }
        }

        public static readonly BindableProperty EditorDisabledBackgroundColorProperty =
            BindableProperty.Create(
                nameof(EditorDisabledBackgroundColor),
                typeof(Color),
                typeof(EditorField),
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
                typeof(EditorField),
                true,
                BindingMode.TwoWay,
                propertyChanged: (s, o, n) =>
                {
                    if (s is EditorField EditorField)
                    {
                        EditorField._editor.IsEnabled = (bool)n;
                        if (EditorField._editor.IsEnabled)
                            EditorField._editor.BackgroundColor = EditorField.EditorBackgroundColor;
                        else
                            EditorField._editor.BackgroundColor = EditorField.EditorDisabledBackgroundColor;

                    }
                }
            );

        public string EditorText
        {
            get { return (string)GetValue(EditorTextProperty); }
            set { SetValue(EditorTextProperty, value); }
        }

        public static readonly BindableProperty EditorTextProperty =
            BindableProperty.Create(
                nameof(EditorText),
                typeof(string),
                typeof(EditorField),
                null,
                BindingMode.TwoWay);

        public string EditorPlaceholder
        {
            get { return (string)GetValue(EditorPlaceholderProperty); }
            set { SetValue(EditorPlaceholderProperty, value); }
        }

        public static readonly BindableProperty EditorPlaceholderProperty =
            BindableProperty.Create(
                nameof(EditorPlaceholder),
                typeof(string),
                typeof(EditorField),
                null,
                BindingMode.TwoWay);

        public Color EditorTextColor
        {
            get { return (Color)GetValue(EditorTextColorProperty); }
            set { SetValue(EditorTextColorProperty, value); }
        }

        public static readonly BindableProperty EditorTextColorProperty =
            BindableProperty.Create(
                nameof(EditorTextColor),
                typeof(Color),
                typeof(EditorField),
                null,
                BindingMode.TwoWay);

        public Color EditorPlaceholderColor
        {
            get { return (Color)GetValue(EditorPlaceholderColorProperty); }
            set { SetValue(EditorPlaceholderColorProperty, value); }
        }

        public static readonly BindableProperty EditorPlaceholderColorProperty =
            BindableProperty.Create(
                nameof(EditorPlaceholderColor),
                typeof(Color),
                typeof(EditorField),
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
                typeof(EditorField),
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
                typeof(EditorField),
                null,
                BindingMode.TwoWay);

        public Color EditorFocusBackgroundColor
        {
            get { return (Color)GetValue(EditorFocusBackgroundColorProperty); }
            set { SetValue(EditorFocusBackgroundColorProperty, value); }
        }

        public static readonly BindableProperty EditorFocusBackgroundColorProperty =
            BindableProperty.Create(
                nameof(EditorFocusBackgroundColor),
                typeof(Color),
                typeof(EditorField),
                null,
                BindingMode.TwoWay
            );

        public Color EditorBorderColor
        {
            get { return (Color)GetValue(EditorBorderColorProperty); }
            set { SetValue(EditorBorderColorProperty, value); }
        }

        public static readonly BindableProperty EditorBorderColorProperty =
            BindableProperty.Create(
                nameof(EditorBorderColor),
                typeof(Color),
                typeof(EditorField),
                null,
                BindingMode.TwoWay);

        public float EditorCornerRadius
        {
            get { return (float)GetValue(EditorCornerRadiusProperty); }
            set { SetValue(EditorCornerRadiusProperty, value); }
        }

        public static readonly BindableProperty EditorCornerRadiusProperty =
            BindableProperty.Create(
                nameof(EditorCornerRadius),
                typeof(float),
                typeof(EditorField),
                (float)3,
                BindingMode.TwoWay);

        public Keyboard EditorKeyboard
        {
            get { return (Keyboard)GetValue(EditorKeyboardProperty); }
            set { SetValue(EditorKeyboardProperty, value); }
        }

        public static readonly BindableProperty EditorKeyboardProperty =
            BindableProperty.Create(
                nameof(EditorKeyboard),
                typeof(Keyboard),
                typeof(EditorField),
                null,
                BindingMode.TwoWay);

        public new bool IsFocused { get => _editor.IsFocused; }
        public new void Focus() => _editor.Focus();
        public new void Unfocus() => _editor.Unfocus();

        public ICommand OnEditorFocusedCmd
        {
            get { return (ICommand)GetValue(OnEditorFocusedCmdProperty); }
            set { SetValue(OnEditorFocusedCmdProperty, value); }
        }

        public static readonly BindableProperty OnEditorFocusedCmdProperty =
            BindableProperty.Create(
                nameof(OnEditorFocusedCmd),
                typeof(ICommand),
                typeof(EditorField),
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
                typeof(EditorField),
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
                typeof(EditorField),
                null,
                BindingMode.TwoWay);

        public ICommand OnEditorUnfocusedCmd
        {
            get { return (ICommand)GetValue(OnEditorUnfocusedCmdProperty); }
            set { SetValue(OnEditorUnfocusedCmdProperty, value); }
        }

        public static readonly BindableProperty OnEditorUnfocusedCmdProperty =
            BindableProperty.Create(
                nameof(OnEditorUnfocusedCmd),
                typeof(ICommand),
                typeof(EditorField),
                null,
                BindingMode.TwoWay);

        private void EditorFocusedEvent(object sender, FocusEventArgs e)
        {
            if (sender is Editor Editor)
            {
                if (e.IsFocused)
                {
                    if (!EditorFocusBackgroundColor.Equals(EditorBackgroundColor))
                        Editor.BackgroundColor = EditorFocusBackgroundColor;

                    if (OnEditorFocusedCmd != null)
                    {
                        OnEditorFocusedCmd.Execute(this);
                    }
                }
                else
                {
                    Editor.BackgroundColor = EditorBackgroundColor;

                    if (OnEditorFocusedCmd != null)
                    {
                        OnEditorFocusedCmd.Execute(this);
                    }
                }
            }
        }

        public Action<object, TextChangedEventArgs> OnTextChangedEvent;
        private void TextChangedEvent(object sender, TextChangedEventArgs e)
        {
            if (sender is Editor Editor)
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
