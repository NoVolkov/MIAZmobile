using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinTest
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Auth : ContentPage
    {
        public Auth()
        {
            InitializeComponent();
        }
        private void btn_Enter(object sender, System.EventArgs e)
        {
            Button button = (Button)sender;
            button.Text = "Нажато!";
        }
        private async void btn_Reg(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new RegistratePage());
        }
    }
}