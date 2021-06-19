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
            /*Button button = (Button)sender;
            button.Text = "Нажато!";*/
            /* Patient p = new Patient(
                 txt_Snils.Text,txt_Name.Text,txt_Surname.Text,txt_Patronymic.Text,new DateTime().Date,Double.Parse(txt_Height.Text), Double.Parse(txt_Weight.Text)
                 );
             string jsonPatient = JsonSerializer.Serialize(p);
             HttpClient client = Client.GetClient();
             var response = await client.PostAsync(Client.Url+ "/addPatient",
                 new StringContent(
                     jsonPatient,
                     Encoding.UTF8, "application/json")); */
            await Navigation.PushAsync(new AddPage());
        }
    }
}