using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace Xam.Zendbit.UI.Components
{
    public partial class TemplatePage : ContentPage
    {
        public TemplatePage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        public View TemplatePageContent
        {
            get { return (View)GetValue(TemplatePageContentProperty); }
            set { SetValue(TemplatePageContentProperty, value); }
        }

        public static readonly BindableProperty TemplatePageContentProperty =
            BindableProperty.Create(
                nameof(TemplatePageContent),
                typeof(View),
                typeof(TemplatePage),
                null,
                BindingMode.TwoWay);

        public void ClosePopUp()
        {
            if (TogglePopup)
            {
                TogglePopup = !TogglePopup;
                PopUpContent = null;

                if (OnPopUpClosedCmd != null && OnPopUpClosedCmd.CanExecute(this))
                {
                    OnPopUpClosedCmd.Execute(this);
                }
            }
        }

        public bool TogglePopup
        {
            get { return (bool)GetValue(TogglePopupProperty); }
            set { SetValue(TogglePopupProperty, value); }
        }

        public static readonly BindableProperty TogglePopupProperty =
            BindableProperty.Create(
                nameof(TogglePopup),
                typeof(bool),
                typeof(TemplatePage),
                false,
                BindingMode.TwoWay
            );

        public ICommand OnPopUpClosedCmd
        {
            get { return (ICommand)GetValue(OnPopUpClosedCmdProperty); }
            set { SetValue(OnPopUpClosedCmdProperty, value); }
        }
        public static readonly BindableProperty OnPopUpClosedCmdProperty =
            BindableProperty.Create(
                nameof(OnPopUpClosedCmd),
                typeof(ICommand),
                typeof(TemplatePage),
                null,
                BindingMode.TwoWay);

        public Color PopUpBackgroundColor
        {
            get { return (Color)GetValue(PopUpBackgroundColorProperty); }
            set { SetValue(PopUpBackgroundColorProperty, value); }
        }

        public static readonly BindableProperty PopUpBackgroundColorProperty =
            BindableProperty.Create(
                nameof(PopUpBackgroundColor),
                typeof(Color),
                typeof(TemplatePage),
                null,
                BindingMode.TwoWay);

        public View PopUpContent
        {
            get { return (View)GetValue(PopUpContentProperty); }
            set { SetValue(PopUpContentProperty, value); }
        }

        public static readonly BindableProperty PopUpContentProperty =
            BindableProperty.Create(
                nameof(PopUpContent),
                typeof(View),
                typeof(TemplatePage),
                null,
                BindingMode.TwoWay);

        public void ShowPopUp(View popUpContent, ICommand onPopUpClosedCmd = null)
        {
            TogglePopup = true;
            PopUpContent = popUpContent;
            if (onPopUpClosedCmd != null)
                OnPopUpClosedCmd = onPopUpClosedCmd;
        }
    }
}
