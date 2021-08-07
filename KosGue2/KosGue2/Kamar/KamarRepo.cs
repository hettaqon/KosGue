using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KosGue2.Kamar
{
    public class KamarRepository
    {
        public List<Kamar> kamarRepository { get; set; }

        public KamarRepository()
        {
            kamarRepository = GetKamarRepo();
        }

        /* Function: Returns all the records in table
         * with the help of stored procedure
         * Used to populate the Repository (Collection)
         */
        public List<Kamar> GetKamarRepo()
        {
            List<Kamar> listOfKamars = new List<Kamar>();

            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connString))
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null. Set the value of Connection String in KamarCatalog->Properties-?Settings.settings");
                }

                SqlCommand query = new SqlCommand("SELECT * from Kamar", conn);
                conn.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                foreach (DataRow row in dataTable.Rows)
                {
                    Kamar m = new Kamar();
                    m.KodeKamar = Convert.ToInt32(row["KodeKamar"]);
                    m.Tipe = row["Tipe"].ToString();
                    m.Lokasi = row["Lokasi"].ToString();
                    m.Fasilitas = row["Fasilitas"].ToString();
                    m.Status = row["Status"].ToString();
                    m.KodeKos = Convert.ToInt32(row["KodeKos"]);

                    listOfKamars.Add(m);
                }

                return listOfKamars;
            }
        }


        /*
         * Function: Add new record to the Database
         * with the help of stored procedure
         */
        public void addKamar(Kamar kamarRecord)
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connString))
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null. Set the value of Connection String in KamarCatalog->Properties-?Settings.settings");
                }
                else if (kamarRecord == null)
                    throw new Exception("The passed argument 'kamarRecord' is null");

                SqlCommand query = new SqlCommand("addKamar", conn);
                conn.Open();
                query.CommandType = CommandType.StoredProcedure;
                SqlParameter param1 = new SqlParameter("pKodeKamar", SqlDbType.Int);
                SqlParameter param2 = new SqlParameter("pTipe", SqlDbType.VarChar);
                SqlParameter param3 = new SqlParameter("pLokasi", SqlDbType.VarChar);
                SqlParameter param4 = new SqlParameter("pFasilitas", SqlDbType.VarChar);
                SqlParameter param5 = new SqlParameter("pStatus", SqlDbType.VarChar);
                SqlParameter param6 = new SqlParameter("pKodeKos", SqlDbType.Int);


                param1.Value = kamarRecord.KodeKamar;
                param2.Value = kamarRecord.Tipe;
                param3.Value = kamarRecord.Lokasi;
                param4.Value = kamarRecord.Fasilitas;
                param5.Value = kamarRecord.Status;
                param6.Value = kamarRecord.KodeKos;


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
        public void DelKamar(int id)
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connString))
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null. Set the value of Connection String in KamarCatalog->Properties-?Settings.settings");
                }

                SqlCommand query = new SqlCommand("deleteKamar", conn);
                conn.Open();
                query.CommandType = CommandType.StoredProcedure;
                SqlParameter param1 = new SqlParameter("pKodeKamar", SqlDbType.Int);
                param1.Value = id;
                query.Parameters.Add(param1);

                query.ExecuteNonQuery();
            }
        }

        /*
         * Function: Updates the Kamar Record with reference to supplied id
         * with the help of stored procedure
         */
        public void UpdateKamar(Kamar kamarRecord)
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connString))
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null. Set the value of Connection String in KamarCatalog->Properties-?Settings.settings");
                }

                SqlCommand query = new SqlCommand("updateKamar", conn);
                conn.Open();
                query.CommandType = CommandType.StoredProcedure;
                SqlParameter param1 = new SqlParameter("pKodeKamar", SqlDbType.Int);
                SqlParameter param2 = new SqlParameter("pTipe", SqlDbType.VarChar);
                SqlParameter param3 = new SqlParameter("pLokasi", SqlDbType.VarChar);
                SqlParameter param4 = new SqlParameter("pFasilitas", SqlDbType.VarChar);
                SqlParameter param5 = new SqlParameter("pStatus", SqlDbType.VarChar);
                SqlParameter param6 = new SqlParameter("pKodeKos", SqlDbType.Int);


                param1.Value = kamarRecord.KodeKamar;
                param2.Value = kamarRecord.Tipe;
                param3.Value = kamarRecord.Lokasi;
                param4.Value = kamarRecord.Fasilitas;
                param5.Value = kamarRecord.Status;
                param6.Value = kamarRecord.KodeKos;


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
