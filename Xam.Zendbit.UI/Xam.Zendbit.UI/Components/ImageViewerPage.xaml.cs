using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Xam.Zendbit.UI.Components
{
    public partial class ImageViewerPage : ModalPage
    {
        public ImageViewerPage()
        {
            InitializeComponent();
        }

        public Aspect Aspect
        {
            get { return (Aspect)GetValue(AspectProperty); }
            set { SetValue(AspectProperty, value); }
        }

        public static readonly BindableProperty AspectProperty =
            BindableProperty.Create(
                nameof(Aspect),
                typeof(Aspect),
                typeof(ImageViewerPage),
                Aspect.AspectFill,
                BindingMode.TwoWay);

        public ImageSource Source
        {
            get { return (ImageSource)GetValue(SourceProperty); }
            set { SetValue(SourceProperty, value); }
        }

        public static readonly BindableProperty SourceProperty =
            BindableProperty.Create(
                nameof(Source),
                typeof(ImageSource),
                typeof(ImageViewerPage),
                null,
                BindingMode.TwoWay);
    }
}
