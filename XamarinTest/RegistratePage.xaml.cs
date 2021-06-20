using Android.Content.Res;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.StyleSheets;
using Xamarin.Forms.Xaml;
using XamarinTest.models;

namespace XamarinTest
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistratePage : ContentPage
    {
        public RegistratePage()
        {
            InitializeComponent();
            
        }
        //
        private async void btn_Regist(object sender, System.EventArgs e)
        {
            
            await Navigation.PushModalAsync(new AddPage());
        }
    }
}