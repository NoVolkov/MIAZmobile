using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Description;
using System.ServiceModel.Web;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using WebApplication1.models;

namespace WebApplication1
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Service1
    {
        private string STR_CON = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\dim5d\source\repos\MIATZ\MIATZ\AppData\miazDB.mdf;Integrated Security=True;Connect Timeout=30";
        // Чтобы использовать протокол HTTP GET, добавьте атрибут [WebGet]. (По умолчанию ResponseFormat имеет значение WebMessageFormat.Json.)
        // Чтобы создать операцию, возвращающую XML,
        //     добавьте [WebGet(ResponseFormat=WebMessageFormat.Xml)]
        //     и включите следующую строку в текст операции:
        //         WebOperationContext.Current.OutgoingResponse.ContentType = "text/xml";
        [OperationContract]
        public void DoWork()
        {
            // Добавьте здесь реализацию операции
            return;
        }
       
        [WebInvoke(Method ="POST", RequestFormat =WebMessageFormat.Json,
            UriTemplate ="/addPatient", ResponseFormat =WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped)]
        public void addPatient(string p)
        {
            Patient p1 = JsonSerializer.Deserialize<Patient>(p);
            using (SqlConnection con = new SqlConnection(STR_CON))
            {
                SqlCommand com = new SqlCommand("INSERT INTO Patient (Name, Surname, Patronymic, SNILS, DateOfBirth, Height, Weight) "+
                    "VALUES (@name, @surname, @patronymic, @snils, @date, @height, @weight)", con);
                SqlParameter[] spmt = new SqlParameter[7];
                spmt[0] = new SqlParameter("@name",System.Data.SqlDbType.NVarChar);
                spmt[0].Value = p1.Name;
                spmt[1] = new SqlParameter("@surname", System.Data.SqlDbType.NVarChar);
                spmt[1].Value = p1.Surname;
                spmt[2] = new SqlParameter("@patronymic", System.Data.SqlDbType.NVarChar);
                spmt[2].Value = p1.Patronymic;
                spmt[3] = new SqlParameter("@snils", System.Data.SqlDbType.NVarChar);
                spmt[3].Value = p1.Snils;
                spmt[4] = new SqlParameter("@date", System.Data.SqlDbType.Date);
                spmt[4].Value = p1.DateOfBirthDay;
                spmt[5] = new SqlParameter("@height", System.Data.SqlDbType.Float);
                spmt[5].Value = p1.Height;
                spmt[6] = new SqlParameter("@weight", System.Data.SqlDbType.Float);
                spmt[6].Value = p1.Weight;
                com.Parameters.AddRange(spmt);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();


            }
        }
        [WebGet(UriTemplate = "/Patient/{snils}")]

        public string getPatientBySnils(string snils)
        {
            Patient p = new Patient();
            using (SqlConnection con = new SqlConnection(STR_CON))
            {
                SqlCommand com = new SqlCommand("SELECT * FROM Patient WHERE ID=@id", con);
                SqlParameter par = new SqlParameter("@ID", System.Data.SqlDbType.Int);
                com.Parameters.Add(par);
                SqlDataReader r = com.ExecuteReader();
                while (r.Read())
                {
                    p.Id = (int)r["ID"];
                    p.Name = (string)r["Name"];
                    p.Surname = (string)r["Surname"];
                    p.Weight = (double)r["Weight"];
                    p.Height = (double)r["Height"];
                }
                con.Close();
            }
            return JsonSerializer.Serialize(p);
        }
        // Добавьте здесь дополнительные операции и отметьте их атрибутом [OperationContract]
    }
}
