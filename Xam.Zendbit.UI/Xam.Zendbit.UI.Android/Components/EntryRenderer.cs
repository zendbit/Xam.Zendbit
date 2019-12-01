using System;
using Android.Content;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Widget;
using Android.Graphics.Drawables;
using System.ComponentModel;

[assembly: ExportRenderer(typeof(Xam.Zendbit.UI.Components.Entry), typeof(Xam.Zendbit.UI.Android.Components.EntryRenderer))]
namespace Xam.Zendbit.UI.Android.Components
{
    public class EntryRenderer : Xamarin.Forms.Platform.Android.EntryRenderer
    {
        public EntryRenderer(Context context) : base(context) { }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
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
