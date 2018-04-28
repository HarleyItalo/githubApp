using System;
using System.Collections.Generic;

using Xamarin.Forms;
using GitHub.ViewModels;

namespace GitHub.Views
{
    public partial class SourceCodePage : ContentPage
    {
        public SourceCodePage()
        {
            InitializeComponent();
            this.BindingContext = new SourceCodePageViewModel();
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {

            if (WebViewData.CanGoBack)
            {
                WebViewData.GoBack();
            }
        }
    }
}
