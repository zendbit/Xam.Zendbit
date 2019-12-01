using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace Xam.Zendbit.UI.Components
{
    public partial class CardView : TemplateView
    {
        public CardView()
        {
            InitializeComponent();
        }

        public bool IsRefresing
        {
            get { return (bool)GetValue(IsRefresingProperty); }
            set { SetValue(IsRefresingProperty, value); }
        }

        public static readonly BindableProperty IsRefresingProperty =
            BindableProperty.Create(
                nameof(IsRefresing),
                typeof(bool),
                typeof(CardView),
                false,
                BindingMode.TwoWay);

        public FlexJustify JustifyContent
        {
            get { return (FlexJustify)GetValue(JustifyContentProperty); }
            set { SetValue(JustifyContentProperty, value); }
        }

        public static readonly BindableProperty JustifyContentProperty =
            BindableProperty.Create(
                nameof(JustifyContent),
                typeof(FlexJustify),
                typeof(CardView),
                FlexJustify.Center,
                BindingMode.TwoWay);

        public bool UseSearch
        {
            get { return (bool)GetValue(UseSearchProperty); }
            set { SetValue(UseSearchProperty, value); }
        }

        public static readonly BindableProperty UseSearchProperty =
            BindableProperty.Create(
                nameof(UseSearch),
                typeof(bool),
                typeof(CardView),
                false,
                BindingMode.TwoWay);

        public new Style Style
        {
            get { return (Style)GetValue(StyleProperty); }
            set { SetValue(StyleProperty, value); }
        }

        public static readonly new BindableProperty StyleProperty =
            BindableProperty.Create(
                nameof(Style),
                typeof(Style),
                typeof(CardView),
                null,
                BindingMode.TwoWay);

        public new IList<View> Children { get => _cardViewLayout.Children; }

        public void AddChild(View child)
        {
            Children.Add(child);
        }

        public void InsertChild(int index, View child)
        {
            Children.Insert(index, child);
        }

        public void RemoveChild(View child)
        {
            Children.Remove(child);
        }

        public void RemoveChildAt(int index)
        {
            Children.RemoveAt(index);
        }

        public int ChildIndex(View child)
        {
            return Children.IndexOf(child);
        }

        public View FindChildByClassId(string classId)
        {
            return (
                from v in Children where v.ClassId.Equals(classId) select v
            ).SingleOrDefault();
        }
    }
}
