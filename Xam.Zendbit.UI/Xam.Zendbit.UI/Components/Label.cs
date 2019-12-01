using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace Xam.Zendbit.UI.Components
{
    public class Label : Xamarin.Forms.Label
    {
        public string TTFontFamily
        {
            get => (string)GetValue(TTFontFamilyProperty);
            set => SetValue(TTFontFamilyProperty, value);
        }

        public static readonly BindableProperty TTFontFamilyProperty =
            BindableProperty.Create(
                nameof(TTFontFamily),
                typeof(string),
                typeof(Label),
                null,
                BindingMode.TwoWay,
                propertyChanged: (s, o, n) =>
                {
                    if (s is Label label && n is string newFontFamily)
                    {
                        label.FontFamily =
                            Device.RuntimePlatform == Device.Android
                            ? $"{newFontFamily}.ttf#{newFontFamily}"
                            : Device.RuntimePlatform == Device.iOS
                            ? newFontFamily
                            : $"Assets/Fonts/{newFontFamily}.ttf#{newFontFamily}";
                    }
                });
    }
}
