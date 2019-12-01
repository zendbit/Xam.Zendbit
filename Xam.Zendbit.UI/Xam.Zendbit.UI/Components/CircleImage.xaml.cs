using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Xam.Zendbit.UI.Components
{
    public partial class CircleImage : TemplateView
    {
        public CircleImage()
        {
            InitializeComponent();
        }

        public ImageSource Source
        {
            get { return (ImageSource)GetValue(SourceProperty); }
            set { SetValue(SourceProperty, value); }
        }

        public static readonly BindableProperty SourceProperty =
            BindableProperty.Create(
                nameof(Source),
                typeof(ImageSource),
                typeof(CircleImage),
                null,
                BindingMode.TwoWay);

        public Aspect Aspect
        {
            get { return (Aspect)GetValue(AspectProperty); }
            set { SetValue(AspectProperty, value); }
        }

        public static readonly BindableProperty AspectProperty =
            BindableProperty.Create(
                nameof(Aspect),
                typeof(Aspect),
                typeof(CircleImage),
                Aspect.AspectFill,
                BindingMode.TwoWay);

        public new double Padding
        {
            get { return (double)GetValue(PaddingProperty); }
            set { SetValue(PaddingProperty, value); }
        }

        public new static readonly BindableProperty PaddingProperty =
            BindableProperty.Create(
                nameof(Padding),
                typeof(double),
                typeof(CircleImage),
                0.0,
                BindingMode.TwoWay);

        public Color BorderColor
        {
            get { return (Color)GetValue(BorderColorProperty); }
            set { SetValue(BorderColorProperty, value); }
        }

        public static readonly BindableProperty BorderColorProperty =
            BindableProperty.Create(
                nameof(BorderColor),
                typeof(Color),
                typeof(CircleImage),
                null,
                BindingMode.TwoWay);

        public float CornerRadius
        {
            get { return (float)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public static readonly BindableProperty CornerRadiusProperty =
            BindableProperty.Create(
                nameof(CornerRadius),
                typeof(float),
                typeof(CircleImage),
                (float)0,
                BindingMode.TwoWay);

        public new double HeightRequest
        {
            get { return (double)GetValue(HeightRequestProperty); }
            set { SetValue(HeightRequestProperty, value); }
        }

        public new static readonly BindableProperty HeightRequestProperty =
            BindableProperty.Create(
                nameof(HeightRequest),
                typeof(double),
                typeof(CircleImage),
                null,
                BindingMode.TwoWay);

        public new double WidthRequest
        {
            get { return (double)GetValue(WidthRequestProperty); }
            set { SetValue(WidthRequestProperty, value); }
        }

        public new static readonly BindableProperty WidthRequestProperty =
            BindableProperty.Create(
                nameof(WidthRequest),
                typeof(double),
                typeof(CircleImage),
                null,
                BindingMode.TwoWay);

        public new Color BackgroundColor
        {
            get { return (Color)GetValue(BackgroundColorProperty); }
            set { SetValue(BackgroundColorProperty, value); }
        }

        public new static readonly BindableProperty BackgroundColorProperty =
            BindableProperty.Create(
                nameof(BackgroundColor),
                typeof(Color),
                typeof(CircleImage),
                Color.Transparent,
                BindingMode.TwoWay);
    }
}
