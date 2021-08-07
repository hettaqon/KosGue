using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KosGue2.Petugas
{
    public class PetugasRepository
    {
        public List<Petugas> petugasRepository { get; set; }

        public PetugasRepository()
        {
            petugasRepository = GetPetugasRepo();
        }

        /* Function: Returns all the records in table
         * with the help of stored procedure
         * Used to populate the Repository (Collection)
         */
        public List<Petugas> GetPetugasRepo()
        {
            List<Petugas> listOfPetugass = new List<Petugas>();

            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connString))
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null. Set the value of Connection String in PetugasCatalog->Properties-?Settings.settings");
                }

                SqlCommand query = new SqlCommand("SELECT * from Petugas", conn);
                conn.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                foreach (DataRow row in dataTable.Rows)
                {
                    Petugas m = new Petugas();
                    m.KodePetugas = Convert.ToInt32(row["KodePetugas"]);
                    m.Nama = row["Nama"].ToString();
                    m.NoHP = row["NoHP"].ToString();
                    m.Job = row["Job"].ToString();
                    m.Shift = row["Shift"].ToString();

                    listOfPetugass.Add(m);
                }

                return listOfPetugass;
            }
        }


        /*
         * Function: Add new record to the Database
         * with the help of stored procedure
         */
        public void addPetugas(Petugas petugasRecord)
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connString))
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null. Set the value of Connection String in PetugasCatalog->Properties-?Settings.settings");
                }
                else if (petugasRecord == null)
                    throw new Exception("The passed argument 'petugasRecord' is null");

                SqlCommand query = new SqlCommand("addPetugas", conn);
                conn.Open();
                query.CommandType = CommandType.StoredProcedure;
                SqlParameter param1 = new SqlParameter("pKodePetugas", SqlDbType.Int);
                SqlParameter param2 = new SqlParameter("pNama", SqlDbType.VarChar);
                SqlParameter param3 = new SqlParameter("pNoHP", SqlDbType.VarChar);
                SqlParameter param4 = new SqlParameter("pJob", SqlDbType.VarChar);
                SqlParameter param5 = new SqlParameter("pShift", SqlDbType.VarChar);

                param1.Value = petugasRecord.KodePetugas;
                param2.Value = petugasRecord.Nama;
                param3.Value = petugasRecord.NoHP;
                param4.Value = petugasRecord.Job;
                param5.Value = petugasRecord.Shift;

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
        public void DelPetugas(int id)
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connString))
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null. Set the value of Connection String in PetugasCatalog->Properties-?Settings.settings");
                }

                SqlCommand query = new SqlCommand("deletePetugas", conn);
                conn.Open();
                query.CommandType = CommandType.StoredProcedure;
                SqlParameter param1 = new SqlParameter("pKodePetugas", SqlDbType.Int);
                param1.Value = id;
                query.Parameters.Add(param1);

                query.ExecuteNonQuery();
            }
        }

        /*
         * Function: Updates the Petugas Record with reference to supplied id
         * with the help of stored procedure
         */
        public void UpdatePetugas(Petugas petugasRecord)
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connString))
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null. Set the value of Connection String in PetugasCatalog->Properties-?Settings.settings");
                }

                SqlCommand query = new SqlCommand("updatePetugas", conn);
                conn.Open();
                query.CommandType = CommandType.StoredProcedure;
                SqlParameter param1 = new SqlParameter("pKodePetugas", SqlDbType.Int);
                SqlParameter param2 = new SqlParameter("pNama", SqlDbType.VarChar);
                SqlParameter param3 = new SqlParameter("pNoHP", SqlDbType.VarChar);
                SqlParameter param4 = new SqlParameter("pJob", SqlDbType.VarChar);
                SqlParameter param5 = new SqlParameter("pShift", SqlDbType.VarChar);

                param1.Value = petugasRecord.KodePetugas;
                param2.Value = petugasRecord.Nama;
                param3.Value = petugasRecord.NoHP;
                param4.Value = petugasRecord.Job;
                param5.Value = petugasRecord.Shift;

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
