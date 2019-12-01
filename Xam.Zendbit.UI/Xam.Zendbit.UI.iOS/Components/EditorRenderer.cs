using System;
using System.ComponentModel;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using CoreGraphics;

[assembly: ExportRenderer(typeof(Xam.Zendbit.UI.Components.Editor), typeof(Xam.Zendbit.UI.iOS.Components.EditorRenderer))]
namespace Xam.Zendbit.UI.iOS.Components
{
    public class EditorRenderer : Xamarin.Forms.Platform.iOS.EditorRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
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
