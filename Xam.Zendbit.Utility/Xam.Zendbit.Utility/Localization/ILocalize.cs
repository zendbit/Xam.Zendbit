using System;
using System.Globalization;

namespace Xam.Zendbit.Utility.Localization
{
    public interface ILocalize
    {
        CultureInfo GetCurrentCultureInfo();
        void SetLocale(CultureInfo ci);
    }
}
