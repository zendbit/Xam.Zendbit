using System;
using System.Globalization;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Xam.Zendbit.Utility.Localization
{
    public class Localize
    {
        public static Localize Self { get; } = new Localize();

        public void SetLocale(
            CultureInfo culture
        )
        {
            if (
                Device.RuntimePlatform.Equals(Device.iOS)
                || Device.RuntimePlatform.Equals(Device.Android)
            )
            {
                // save culture property
                Application.Current.Properties["Culture"] = culture.Name;
                Application.Current.SavePropertiesAsync();
                DependencyService.Get<ILocalize>()?.SetLocale(culture); // set the Thread for locale-aware methods
            }
        }

        public CultureInfo GetActiveCulture()
        {
            Application.Current.Properties.TryGetValue("Culture", out object culture);
            return culture is null
                ? DependencyService.Get<ILocalize>().GetCurrentCultureInfo()
                : new CultureInfo(culture.ToString());
        }
    }
}
