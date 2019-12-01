using System;
using System.Globalization;
using System.Reflection;
using System.Resources;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xam.Zendbit.Utility.Localization
{
    // You exclude the 'Extension' suffix when using in XAML
    [ContentProperty("Text")]
    public class TranslateExtension : IMarkupExtension
    {
        public readonly CultureInfo ci;
        private readonly string _resourceId;

        public string Text { get; set; }

        public ResourceManager ResMgr()
        {
            return new ResourceManager(
                    _resourceId,
                    Assembly.GetExecutingAssembly()
                );
        }

        public TranslateExtension(string resxResources)
        {
            _resourceId = $"{Assembly.GetExecutingAssembly().GetName().Name}.{resxResources}";

            if (
                Device.RuntimePlatform.Equals(Device.iOS)
                || Device.RuntimePlatform.Equals(Device.Android)
            )
            {
                ci = Localize.Self.GetActiveCulture();
            }
        }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Text is null)
                return string.Empty;

            var translation = ResMgr().GetString(Text, ci);
            if (translation is null)
            {
#if DEBUG
                throw new ArgumentException(
                    $"Key '{Text}' was not found in resources '{_resourceId}' for culture '{ci.Name}'.",
                    nameof(Text));
#else
                translation = Text; // HACK: returns the key, which GETS DISPLAYED TO THE USER
#endif
            }

            return translation;
        }

        public string GetString(string text)
        {
            Text = text;
            return ProvideValue(null).ToString();
        }
    }
}
