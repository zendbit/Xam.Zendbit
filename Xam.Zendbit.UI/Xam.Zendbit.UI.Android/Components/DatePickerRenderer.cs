using System;
using System.ComponentModel;
using Android.Content;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Xam.Zendbit.UI.Components.DatePicker), typeof(Xam.Zendbit.UI.Android.Components.DatePickerRenderer))]
namespace Xam.Zendbit.UI.Android.Components
{
    public class DatePickerRenderer : Xamarin.Forms.Platform.Android.DatePickerRenderer
    {
        public DatePickerRenderer(Context context) : base(context) { }

        protected override void OnElementChanged(ElementChangedEventArgs<DatePicker> e)
        {
            base.OnElementChanged(e);
            UpdateElement();
        }

        private void UpdateElement()
        {
            Control.SetBackground(null);
            Control.SetPaddingRelative(20, 20, 20, 20);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName.Equals("BackgroundColor"))
            {
                UpdateElement();
                Control.SetBackgroundColor(Element.BackgroundColor.ToAndroid());
            }
        }
    }
}
