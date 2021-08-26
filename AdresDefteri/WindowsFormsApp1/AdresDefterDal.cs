using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace WindowsFormsApp1
{
    public class AdresDefterDal
    {
        SqlConnection connection = new SqlConnection("Data Source=IDEA\\SQLEXPRESS;Initial Catalog=Crud;Integrated Security=True");
        public DataTable GetAll()
        {
            // ; ;
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            else
            {
                ///
            }
            SqlCommand command = new SqlCommand("Select * From Person", connection);
            SqlDataReader reader = command.ExecuteReader();
            DataTable db = new DataTable();
            db.Load(reader);
            reader.Close();
            connection.Close();
            return db;
        }
        public void Ekle(Adresler adres)

        {
            string kayit = "Insert Into Person(ad,soyad,telefon,email,adres,il,ilce) values (@ad,@soyad,@telefon,@email,@adres,@il,@ilce)";

            if (connection.State == ConnectionState.Closed)

            {
                connection.Open();
            }

            SqlCommand ekle = new SqlCommand(kayit, connection);
            ekle.Parameters.AddWithValue("@ad", adres.Ad);
            ekle.Parameters.AddWithValue("@soyad", adres.Soyad);
            ekle.Parameters.AddWithValue("@telefon", adres.Telefon);
            ekle.Parameters.AddWithValue("@email", adres.Email);
            ekle.Parameters.AddWithValue("@adres", adres.Adres);
            ekle.Parameters.AddWithValue("@il", adres.Il);
            ekle.Parameters.AddWithValue("@ilce", adres.Ilce);
            ekle.ExecuteNonQuery();
            connection.Close();


        }

        public void ConnectionKontrol()
        {

            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }

        }

        public void Delete(int id)
        {

            ConnectionKontrol();


            SqlCommand command = new SqlCommand("Delete from Person where id=@id", connection);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void Update(Adresler adres)
        {

            ConnectionKontrol();


            SqlCommand cmd = new SqlCommand("Update Person Set ad=@ad, soyad=@soyad, telefon=@telefon,email=@email,adres=@adres,il=@il,ilce=@ilce where id=@id", connection);

            cmd.Parameters.AddWithValue("@ad", adres.Ad);
            cmd.Parameters.AddWithValue("@soyad", adres.Soyad);
            cmd.Parameters.AddWithValue("@telefon", adres.Telefon);
            cmd.Parameters.AddWithValue("@email", adres.Email);
            cmd.Parameters.AddWithValue("@adres", adres.Adres);
            cmd.Parameters.AddWithValue("@il", adres.Il);
            cmd.Parameters.AddWithValue("@ilce", adres.Ilce);
            cmd.Parameters.AddWithValue("@id", adres.id);
            cmd.ExecuteNonQuery();
            connection.Close();
        }
    }
}
