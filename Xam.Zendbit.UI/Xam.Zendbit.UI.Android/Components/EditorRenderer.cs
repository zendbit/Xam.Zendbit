using System;
using System.ComponentModel;
using Android.Content;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Xam.Zendbit.UI.Components.Editor), typeof(Xam.Zendbit.UI.Android.Components.EditorRenderer))]
namespace Xam.Zendbit.UI.Android.Components
{
    public class EditorRenderer : Xamarin.Forms.Platform.Android.EditorRenderer
    {
        public EditorRenderer(Context context) : base(context) { }

        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
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
