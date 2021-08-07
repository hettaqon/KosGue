using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KosGue2.Kos
{
    public class KosRepository
    {
        public List<Kos> kosRepository { get; set; }

        public KosRepository()
        {
            kosRepository = GetKosRepo();
        }

        /* Function: Returns all the records in table
         * with the help of stored procedure
         * Used to populate the Repository (Collection)
         */
        public List<Kos> GetKosRepo()
        {
            List<Kos> listOfKoss = new List<Kos>();

            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connString))
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null. Set the value of Connection String in KosCatalog->Properties-?Settings.settings");
                }

                SqlCommand query = new SqlCommand("SELECT * from Kos", conn);
                conn.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                foreach (DataRow row in dataTable.Rows)
                {
                    Kos m = new Kos();
                    m.KodeKos = Convert.ToInt32(row["KodeKos"]);
                    m.Nama = row["Nama"].ToString();
                    m.Alamat = row["Alamat"].ToString();
                    m.JmlKamar = Convert.ToInt32(row["JmlKamar"]);
                    m.Fasilitas = row["Fasilitas"].ToString();
                    m.KodePetugas = Convert.ToInt32(row["KodePetugas"]);
                    m.Kontak = row["Kontak"].ToString();

                    listOfKoss.Add(m);
                }

                return listOfKoss;
            }
        }


        /*
         * Function: Add new record to the Database
         * with the help of stored procedure
         */
        public void addKos(Kos kosRecord)
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connString))
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null. Set the value of Connection String in KosCatalog->Properties-?Settings.settings");
                }
                else if (kosRecord == null)
                    throw new Exception("The passed argument 'kosRecord' is null");

                SqlCommand query = new SqlCommand("addKos", conn);
                conn.Open();
                query.CommandType = CommandType.StoredProcedure;
                SqlParameter param1 = new SqlParameter("pKodeKos", SqlDbType.Int);
                SqlParameter param2 = new SqlParameter("pNama", SqlDbType.VarChar);
                SqlParameter param3 = new SqlParameter("pAlamat", SqlDbType.VarChar);
                SqlParameter param4 = new SqlParameter("pJmlKamar", SqlDbType.Int);
                SqlParameter param5 = new SqlParameter("pFasilitas", SqlDbType.VarChar);
                SqlParameter param6 = new SqlParameter("pKodePetugas", SqlDbType.Int);
                SqlParameter param7 = new SqlParameter("pKontak", SqlDbType.VarChar);

                param1.Value = kosRecord.KodeKos;
                param2.Value = kosRecord.Nama;
                param3.Value = kosRecord.Alamat;
                param4.Value = kosRecord.JmlKamar;
                param5.Value = kosRecord.Fasilitas;
                param6.Value = kosRecord.KodePetugas;
                param7.Value = kosRecord.Kontak;

                query.Parameters.Add(param1);
                query.Parameters.Add(param2);
                query.Parameters.Add(param3);
                query.Parameters.Add(param4);
                query.Parameters.Add(param5);
                query.Parameters.Add(param6);
                query.Parameters.Add(param7);

                query.ExecuteNonQuery();
            }
        }

        /*
         * Function: Deletes the record with reference to supplied id
         * with the help of stored procedure
         */
        public void DelKos(int id)
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connString))
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null. Set the value of Connection String in KosCatalog->Properties-?Settings.settings");
                }

                SqlCommand query = new SqlCommand("deleteKos", conn);
                conn.Open();
                query.CommandType = CommandType.StoredProcedure;
                SqlParameter param1 = new SqlParameter("pKodeKos", SqlDbType.Int);
                param1.Value = id;
                query.Parameters.Add(param1);

                query.ExecuteNonQuery();
            }
        }

        /*
         * Function: Updates the Kos Record with reference to supplied id
         * with the help of stored procedure
         */
        public void UpdateKos(Kos kosRecord)
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connString))
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null. Set the value of Connection String in KosCatalog->Properties-?Settings.settings");
                }

                SqlCommand query = new SqlCommand("updateKos", conn);
                conn.Open();
                query.CommandType = CommandType.StoredProcedure;
                SqlParameter param1 = new SqlParameter("pKodeKos", SqlDbType.Int);
                SqlParameter param2 = new SqlParameter("pNama", SqlDbType.VarChar);
                SqlParameter param3 = new SqlParameter("pAlamat", SqlDbType.VarChar);
                SqlParameter param4 = new SqlParameter("pJmlKamar", SqlDbType.Int);
                SqlParameter param5 = new SqlParameter("pFasilitas", SqlDbType.VarChar);
                SqlParameter param6 = new SqlParameter("pKodePetugas", SqlDbType.Int);
                SqlParameter param7 = new SqlParameter("pKontak", SqlDbType.VarChar);

                param1.Value = kosRecord.KodeKos;
                param2.Value = kosRecord.Nama;
                param3.Value = kosRecord.Alamat;
                param4.Value = kosRecord.JmlKamar;
                param5.Value = kosRecord.Fasilitas;
                param6.Value = kosRecord.KodePetugas;
                param7.Value = kosRecord.Kontak;

                query.Parameters.Add(param1);
                query.Parameters.Add(param2);
                query.Parameters.Add(param3);
                query.Parameters.Add(param4);
                query.Parameters.Add(param5);
                query.Parameters.Add(param6);
                query.Parameters.Add(param7);

                query.ExecuteNonQuery();
            }
        }
    }
}