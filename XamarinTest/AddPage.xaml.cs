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
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddPage : ContentPage
    {
        private string STR_CON = @"Data Source = 192.168.66.191,49674; Initial Catalog = miac; Persist Security Info=True;User ID = USER; Password=123456";

        public AddPage()
        {
            InitializeComponent();
            loadPage("12345678901");
            
        }
        public  void loadPage(string snils)
        {
            //WcfService1.Service1 service = new WcfService1.Service1();
            //Patient p = JsonSerializer.Deserialize<Patient>(service.GetPatient(snils));
            namePatient.Text = GetPatient(snils); //p.Surname + " " + p.Name;
           /* Weight.Text = Convert.ToString(p.Weight);
            Height.Text = Convert.ToString(p.Height);*/
        }
        public string GetPatient(string snils)
        {

            Patient p = new Patient();
            using (SqlConnection con =new SqlConnection(STR_CON))
            {
                SqlCommand com = new SqlCommand("SELECT * FROM Patient WHERE SNILS="+snils, con);
               // SqlParameter prm = new SqlParameter("@snils", System.Data.SqlDbType.NVarChar);
               // prm.Value = snils;
              //  com.Parameters.Add(prm);
                con.Open();
                SqlDataReader r = com.ExecuteReader();
                while (r.Read())
                {
                    p.Id = (int)r["ID"];
                    p.Name = r["Name"].ToString();
                    p.Surname = r["Surname"].ToString();
                    p.Patronymic = r["Patronomic"].ToString();
                    p.Snils = r["SNILS"].ToString();
                    p.DateOfBirthDay = (DateTime)r["DateOfBirth"];
                    p.Height = (double)r["Height"];
                    p.Weight = (double)r["Weight"];
                   
                }
                con.Close();
            }
            return JsonSerializer.Serialize(p);
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
