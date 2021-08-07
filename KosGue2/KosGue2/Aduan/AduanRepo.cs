using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KosGue2.Aduan
{
    public class AduanRepository
    {
        public List<Aduan> aduanRepository { get; set; }

        public AduanRepository()
        {
            aduanRepository = GetAduanRepo();
        }

        /* Function: Returns all the records in table
         * with the help of stored procedure
         * Used to populate the Repository (Collection)
         */
        public List<Aduan> GetAduanRepo()
        {
            List<Aduan> listOfAduans = new List<Aduan>();

            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connString))
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null. Set the value of Connection String in AduanCatalog->Properties-?Settings.settings");
                }

                SqlCommand query = new SqlCommand("SELECT * from Aduan", conn);
                conn.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                foreach (DataRow row in dataTable.Rows)
                {
                    Aduan m = new Aduan();
                    m.KodeAduan = Convert.ToInt32(row["KodeAduan"]);
                    m.Judul = row["Judul"].ToString();
                    m.Ket = row["Ket"].ToString();
                    m.TglAduan = row["TglAduan"].ToString();
                    m.Kategori = row["Kategori"].ToString();
                    m.NIK = Convert.ToInt32(row["NIK"]);

                    listOfAduans.Add(m);
                }

                return listOfAduans;
            }
        }


        /*
         * Function: Add new record to the Database
         * with the help of stored procedure
         */
        public void addAduan(Aduan aduanRecord)
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connString))
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null. Set the value of Connection String in AduanCatalog->Properties-?Settings.settings");
                }
                else if (aduanRecord == null)
                    throw new Exception("The passed argument 'aduanRecord' is null");

                SqlCommand query = new SqlCommand("addAduan", conn);
                conn.Open();
                query.CommandType = CommandType.StoredProcedure;
                SqlParameter param1 = new SqlParameter("pKodeAduan", SqlDbType.Int);
                SqlParameter param2 = new SqlParameter("pJudul", SqlDbType.VarChar);
                SqlParameter param3 = new SqlParameter("pKet", SqlDbType.VarChar);
                SqlParameter param4 = new SqlParameter("pTglAduan", SqlDbType.VarChar);
                SqlParameter param5 = new SqlParameter("pKategori", SqlDbType.VarChar);
                SqlParameter param6 = new SqlParameter("pNIK", SqlDbType.Int);

                param1.Value = aduanRecord.KodeAduan;
                param2.Value = aduanRecord.Judul;
                param3.Value = aduanRecord.Ket;
                param4.Value = aduanRecord.TglAduan;
                param5.Value = aduanRecord.Kategori;
                param6.Value = aduanRecord.NIK;

                query.Parameters.Add(param1);
                query.Parameters.Add(param2);
                query.Parameters.Add(param3);
                query.Parameters.Add(param4);
                query.Parameters.Add(param5);
                query.Parameters.Add(param6);

                query.ExecuteNonQuery();
            }
        }

        /*
         * Function: Deletes the record with reference to supplied id
         * with the help of stored procedure
         */
        public void DelAduan(int id)
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connString))
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null. Set the value of Connection String in AduanCatalog->Properties-?Settings.settings");
                }

                SqlCommand query = new SqlCommand("deleteAduan", conn);
                conn.Open();
                query.CommandType = CommandType.StoredProcedure;
                SqlParameter param1 = new SqlParameter("pKodeAduan", SqlDbType.Int);
                param1.Value = id;
                query.Parameters.Add(param1);

                query.ExecuteNonQuery();
            }
        }

        /*
         * Function: Updates the Aduan Record with reference to supplied id
         * with the help of stored procedure
         */
        public void UpdateAduan(Aduan aduanRecord)
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connString))
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null. Set the value of Connection String in AduanCatalog->Properties-?Settings.settings");
                }

                SqlCommand query = new SqlCommand("updateAduan", conn);
                conn.Open();
                query.CommandType = CommandType.StoredProcedure;
                SqlParameter param1 = new SqlParameter("pKodeAduan", SqlDbType.Int);
                SqlParameter param2 = new SqlParameter("pJudul", SqlDbType.VarChar);
                SqlParameter param3 = new SqlParameter("pKet", SqlDbType.VarChar);
                SqlParameter param4 = new SqlParameter("pTglAduan", SqlDbType.VarChar);
                SqlParameter param5 = new SqlParameter("pKategori", SqlDbType.VarChar);
                SqlParameter param6 = new SqlParameter("pNIK", SqlDbType.Int);

                param1.Value = aduanRecord.KodeAduan;
                param2.Value = aduanRecord.Judul;
                param3.Value = aduanRecord.Ket;
                param4.Value = aduanRecord.TglAduan;
                param5.Value = aduanRecord.Kategori;
                param6.Value = aduanRecord.NIK;

                query.Parameters.Add(param1);
                query.Parameters.Add(param2);
                query.Parameters.Add(param3);
                query.Parameters.Add(param4);
                query.Parameters.Add(param5);
                query.Parameters.Add(param6);

                query.ExecuteNonQuery();
            }
        }
    }
}
