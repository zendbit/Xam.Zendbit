using System;
using Xamarin.Forms;
using System.ComponentModel;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using CoreGraphics;
using System.Drawing;

[assembly: ExportRenderer(typeof(Xam.Zendbit.UI.Components.Entry), typeof(Xam.Zendbit.UI.iOS.Components.EntryRenderer))]
namespace Xam.Zendbit.UI.iOS.Components
{
    public class EntryRenderer : Xamarin.Forms.Platform.iOS.EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.BackgroundColor = Element?.BackgroundColor.ToUIColor();
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName.Equals("BackgroundColor"))
            {
                Control.BackgroundColor = Element.BackgroundColor.ToUIColor();
            }
        }
    }
}
