using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KosGue2.Pembayaran
{
    public class PembayaranRepository
    {
        public List<Pembayaran> pembayaranRepository { get; set; }

        public PembayaranRepository()
        {
            pembayaranRepository = GetPembayaranRepo();
        }

        /* Function: Returns all the records in table
         * with the help of stored procedure
         * Used to populate the Repository (Collection)
         */
        public List<Pembayaran> GetPembayaranRepo()
        {
            List<Pembayaran> listOfPembayarans = new List<Pembayaran>();

            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connString))
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null. Set the value of Connection String in PembayaranCatalog->Properties-?Settings.settings");
                }

                SqlCommand query = new SqlCommand("SELECT * from Pembayaran", conn);
                conn.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                foreach (DataRow row in dataTable.Rows)
                {
                    Pembayaran m = new Pembayaran();
                    m.KodeBayar = Convert.ToInt32(row["KodeBayar"]);
                    m.TglBayar = row["TglBayar"].ToString();
                    m.JmlBayar = row["JmlBayar"].ToString();
                    m.Bukti = row["Bukti"].ToString();
                    m.Status = row["Status"].ToString();

                    listOfPembayarans.Add(m);
                }

                return listOfPembayarans;
            }
        }


        /*
         * Function: Add new record to the Database
         * with the help of stored procedure
         */
        public void addPembayaran(Pembayaran pembayaranRecord)
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connString))
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null. Set the value of Connection String in PembayaranCatalog->Properties-?Settings.settings");
                }
                else if (pembayaranRecord == null)
                    throw new Exception("The passed argument 'pembayaranRecord' is null");

                SqlCommand query = new SqlCommand("addPembayaran", conn);
                conn.Open();
                query.CommandType = CommandType.StoredProcedure;
                SqlParameter param1 = new SqlParameter("pKodeBayar", SqlDbType.Int);
                SqlParameter param2 = new SqlParameter("pTglBayar", SqlDbType.VarChar);
                SqlParameter param3 = new SqlParameter("pJmlBayar", SqlDbType.VarChar);
                SqlParameter param4 = new SqlParameter("pBukti", SqlDbType.VarChar);
                SqlParameter param5 = new SqlParameter("pStatus", SqlDbType.VarChar);

                param1.Value = pembayaranRecord.KodeBayar;
                param2.Value = pembayaranRecord.TglBayar;
                param3.Value = pembayaranRecord.JmlBayar;
                param4.Value = pembayaranRecord.Bukti;
                param5.Value = pembayaranRecord.Status;

                query.Parameters.Add(param1);
                query.Parameters.Add(param2);
                query.Parameters.Add(param3);
                query.Parameters.Add(param4);
                query.Parameters.Add(param5);

                query.ExecuteNonQuery();
            }
        }

        /*
         * Function: Deletes the record with reference to supplied id
         * with the help of stored procedure
         */
        public void DelPembayaran(int id)
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connString))
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null. Set the value of Connection String in PembayaranCatalog->Properties-?Settings.settings");
                }

                SqlCommand query = new SqlCommand("deletePembayaran", conn);
                conn.Open();
                query.CommandType = CommandType.StoredProcedure;
                SqlParameter param1 = new SqlParameter("pKodeBayar", SqlDbType.Int);
                param1.Value = id;
                query.Parameters.Add(param1);

                query.ExecuteNonQuery();
            }
        }

        /*
         * Function: Updates the Pembayaran Record with reference to supplied id
         * with the help of stored procedure
         */
        public void UpdatePembayaran(Pembayaran pembayaranRecord)
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connString))
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null. Set the value of Connection String in PembayaranCatalog->Properties-?Settings.settings");
                }

                SqlCommand query = new SqlCommand("updatePembayaran", conn);
                conn.Open();
                query.CommandType = CommandType.StoredProcedure;
                SqlParameter param1 = new SqlParameter("pKodeBayar", SqlDbType.Int);
                SqlParameter param2 = new SqlParameter("pTglBayar", SqlDbType.VarChar);
                SqlParameter param3 = new SqlParameter("pJmlBayar", SqlDbType.VarChar);
                SqlParameter param4 = new SqlParameter("pBukti", SqlDbType.VarChar);
                SqlParameter param5 = new SqlParameter("pStatus", SqlDbType.VarChar);

                param1.Value = pembayaranRecord.KodeBayar;
                param2.Value = pembayaranRecord.TglBayar;
                param3.Value = pembayaranRecord.JmlBayar;
                param4.Value = pembayaranRecord.Bukti;
                param5.Value = pembayaranRecord.Status;

                query.Parameters.Add(param1);
                query.Parameters.Add(param2);
                query.Parameters.Add(param3);
                query.Parameters.Add(param4);
                query.Parameters.Add(param5);

                query.ExecuteNonQuery();
            }
        }
    }
}
