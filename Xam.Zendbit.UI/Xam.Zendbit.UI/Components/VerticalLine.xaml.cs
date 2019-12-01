using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xam.Zendbit.UI.Components.Resources;

namespace Xam.Zendbit.UI.Components
{
    public partial class VerticalLine : TemplateView
    {
        public VerticalLine()
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
                typeof(VerticalLine),
                null,
                BindingMode.TwoWay,
                propertyChanged: (s, o, n) =>
                {
                    if (s is VerticalLine verticalLine)
                    {
                        verticalLine._vLine.BackgroundColor = (Color)n;
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
                typeof(VerticalLine),
                1.0,
                BindingMode.TwoWay,
                propertyChanged: (s, o, n) =>
                {
                    if (s is VerticalLine verticalLine)
                    {
                        verticalLine._vLine.WidthRequest = (double)n;
                    }
                }
            );
    }
}
