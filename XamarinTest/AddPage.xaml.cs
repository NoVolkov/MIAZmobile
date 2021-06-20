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
using System.Data.SqlClient;
namespace XamarinTest
{//страница отправки результатов
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddPage : ContentPage
    {

        public AddPage()
        {
            InitializeComponent();
           
            
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
        
}
