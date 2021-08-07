using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KosGue2.Penyewa
{
    public class PenyewaRepository
    {
        public List<Penyewa> penyewaRepository { get; set; }

        public PenyewaRepository()
        {
            penyewaRepository = GetPenyewaRepo();
        }

        /* Function: Returns all the records in table
         * with the help of stored procedure
         * Used to populate the Repository (Collection)
         */
        public List<Penyewa> GetPenyewaRepo()
        {
            List<Penyewa> listOfPenyewas = new List<Penyewa>();

            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connString))
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null. Set the value of Connection String in PenyewaCatalog->Properties-?Settings.settings");
                }

                SqlCommand query = new SqlCommand("SELECT * from Penyewa", conn);
                conn.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                foreach (DataRow row in dataTable.Rows)
                {
                    Penyewa m = new Penyewa();
                    m.NIK = Convert.ToInt32(row["NIK"]);
                    m.Nama = row["Nama"].ToString();
                    m.Alamat = row["Alamat"].ToString();
                    m.NoHP = row["NoHP"].ToString();

                    listOfPenyewas.Add(m);
                }

                return listOfPenyewas;
            }
        }


        /*
         * Function: Add new record to the Database
         * with the help of stored procedure
         */
        public void addPenyewa(Penyewa penyewaRecord)
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connString))
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null. Set the value of Connection String in PenyewaCatalog->Properties-?Settings.settings");
                }
                else if (penyewaRecord == null)
                    throw new Exception("The passed argument 'penyewaRecord' is null");

                SqlCommand query = new SqlCommand("addPenyewa", conn);
                conn.Open();
                query.CommandType = CommandType.StoredProcedure;
                SqlParameter param1 = new SqlParameter("pNIK", SqlDbType.Int);
                SqlParameter param2 = new SqlParameter("pNama", SqlDbType.VarChar);
                SqlParameter param3 = new SqlParameter("pAlamat", SqlDbType.VarChar);
                SqlParameter param4 = new SqlParameter("pNoHP", SqlDbType.VarChar);

                param1.Value = penyewaRecord.NIK;
                param2.Value = penyewaRecord.Nama;
                param3.Value = penyewaRecord.Alamat;
                param4.Value = penyewaRecord.NoHP;

                query.Parameters.Add(param1);
                query.Parameters.Add(param2);
                query.Parameters.Add(param3);
                query.Parameters.Add(param4);


                query.ExecuteNonQuery();
            }
        }

        /*
         * Function: Deletes the record with reference to supplied id
         * with the help of stored procedure
         */
        public void DelPenyewa(int id)
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connString))
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null. Set the value of Connection String in PenyewaCatalog->Properties-?Settings.settings");
                }

                SqlCommand query = new SqlCommand("deletePenyewa", conn);
                conn.Open();
                query.CommandType = CommandType.StoredProcedure;
                SqlParameter param1 = new SqlParameter("pNIK", SqlDbType.Int);
                param1.Value = id;
                query.Parameters.Add(param1);

                query.ExecuteNonQuery();
            }
        }

        /*
         * Function: Updates the Penyewa Record with reference to supplied id
         * with the help of stored procedure
         */
        public void UpdatePenyewa(Penyewa penyewaRecord)
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connString))
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null. Set the value of Connection String in PenyewaCatalog->Properties-?Settings.settings");
                }

                SqlCommand query = new SqlCommand("updatePenyewa", conn);
                conn.Open();
                query.CommandType = CommandType.StoredProcedure;
                SqlParameter param1 = new SqlParameter("pNIK", SqlDbType.Int);
                SqlParameter param2 = new SqlParameter("pNama", SqlDbType.VarChar);
                SqlParameter param3 = new SqlParameter("pAlamat", SqlDbType.VarChar);
                SqlParameter param4 = new SqlParameter("pNoHP", SqlDbType.VarChar);

                param1.Value = penyewaRecord.NIK;
                param2.Value = penyewaRecord.Nama;
                param3.Value = penyewaRecord.Alamat;
                param4.Value = penyewaRecord.NoHP;

                query.Parameters.Add(param1);
                query.Parameters.Add(param2);
                query.Parameters.Add(param3);
                query.Parameters.Add(param4);

                query.ExecuteNonQuery();
            }
        }
    }
}
