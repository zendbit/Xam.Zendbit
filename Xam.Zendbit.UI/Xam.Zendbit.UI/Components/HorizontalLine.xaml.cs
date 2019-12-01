using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xam.Zendbit.UI.Components.Resources;

namespace Xam.Zendbit.UI.Components
{
    public partial class HorizontalLine : TemplateView
    {
        public HorizontalLine()
        {
            InitializeComponent();
        }

        public new Color BackgroundColor
        {
            get { return (Color)GetValue(BackgroundColorProperty); }
            set { SetValue(BackgroundColorProperty, value); }
        }

        public new static readonly BindableProperty BackgroundColorProperty =
            BindableProperty.Create(
                nameof(BackgroundColor),
                typeof(Color),
                typeof(HorizontalLine),
                null,
                BindingMode.TwoWay,
                propertyChanged: (s, o, n) =>
                {
                    if (s is HorizontalLine horizontalLine)
                    {
                        horizontalLine._hLine.BackgroundColor = (Color)n;
                    }
                }
            );

        public double LineSize
        {
            get { return (double)GetValue(LineSizeProperty); }
            set { SetValue(LineSizeProperty, value); }
        }

        public static readonly BindableProperty LineSizeProperty =
            BindableProperty.Create(
                nameof(LineSize),
                typeof(double),
                typeof(HorizontalLine),
                null,
                BindingMode.TwoWay,
                propertyChanged: (s, o, n) =>
                {
                    if (s is HorizontalLine horizontalLine)
                    {
                        horizontalLine._hLine.HeightRequest = (double)n;
                    }
                }
            );
    }
}
