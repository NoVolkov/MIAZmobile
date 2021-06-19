using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinTest.models;

namespace XamarinTest
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddPage : ContentPage
    {
        public AddPage()
        {
            InitializeComponent();
           
            
        }
        public async void loadPage(string snils)
        {
            HttpClient client = Client.GetClient();
            string result = await client.GetStringAsync(Client.Url+ "/Patient/"+snils);
            Patient p = JsonSerializer.Deserialize<Patient>(result);
            namePatient.Text = p.Surname + " " + p.Name;
            Weight.Text = Convert.ToString(p.Weight);
            Height.Text = Convert.ToString(p.Height);
        }
        private void Add(object sender, System.EventArgs e)
        {
            Button button = (Button)sender;
            button.Text = "Нажато!";
        }
        private void picker_SelectedIndexChanged(object sender, EventArgs e)
        {
        

        }
        private void topCheack(object sender, TextChangedEventArgs e)
        {
            if (!Int32.TryParse(e.NewTextValue, out int p))
            {
                txt_TopPres.Text = "";
            }
            

        }
    
}