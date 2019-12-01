using System;
using System.IO;
using Xamarin.Forms;

namespace Xam.Zendbit.UI.Components.Resources
{
    public class Base64ImageResources
    {
        private ImageSource Base64ToImageSource(string base64Image)
        {
            byte[] Base64Stream = Convert.FromBase64String(base64Image);
            return ImageSource.FromStream(() => new MemoryStream(Base64Stream));
        }
    }
}
