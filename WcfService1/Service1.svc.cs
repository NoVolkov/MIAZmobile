using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.Text.Json;
using WcfService1.models;

namespace WcfService1
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы Service1.svc или Service1.svc.cs в обозревателе решений и начните отладку.
    [AspNetCompatibilityRequirements(RequirementsMode =AspNetCompatibilityRequirementsMode.Allowed)]
    public class Service1 : IService1
    {
        private string STR_CON = @"Data Source=192.168.66.191,49674;Initial Catalog=Билетное_обслуживание_пассажиров;Persist Security Info=True;User ID=USER;Password=123456";
        public string GetPatient(string snils)
        {
            Patient p = new Patient();
            using (SqlConnection con =new SqlConnection(STR_CON))
            {
                SqlCommand com = new SqlCommand("SELECT *FROM Patient WHERE SNILS= @snils", con);
                SqlParameter prm = new SqlParameter("@snils", System.Data.SqlDbType.NVarChar);
                com.Parameters.Add(prm);
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

        
    }
}
