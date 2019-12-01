using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using UIKit;
using CoreGraphics;
using System.Drawing;

[assembly: ExportRenderer(typeof(Xam.Zendbit.UI.Components.DatePicker), typeof(Xam.Zendbit.UI.iOS.Components.DatePickerRenderer))]
namespace Xam.Zendbit.UI.iOS.Components
{
    public class DatePickerRenderer : Xamarin.Forms.Platform.iOS.DatePickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<DatePicker> e)
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
