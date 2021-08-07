using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KosGue2.Booking
{
    public class BookingRepository
    {
        public List<Booking> bookingRepository { get; set; }

        public BookingRepository()
        {
            bookingRepository = GetBookingRepo();
        }

        /* Function: Returns all the records in table
         * with the help of stored procedure
         * Used to populate the Repository (Collection)
         */
        public List<Booking> GetBookingRepo()
        {
            List<Booking> listOfBookings = new List<Booking>();

            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connString))
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null. Set the value of Connection String in BookingCatalog->Properties-?Settings.settings");
                }

                SqlCommand query = new SqlCommand("SELECT * from Booking", conn);
                conn.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);

                foreach (DataRow row in dataTable.Rows)
                {
                    Booking m = new Booking();
                    m.KodeBooking = Convert.ToInt32(row["KodeBooking"]);
                    m.KodeKamar = Convert.ToInt32(row["KodeKamar"]);
                    m.TglBooking = row["TglBooking"].ToString();
                    m.TglHabis = row["TglHabis"].ToString();
                    m.NIK = Convert.ToInt32(row["NIK"]);
                    m.KodeBayar = Convert.ToInt32(row["KodeBayar"]);


                    listOfBookings.Add(m);
                }

                return listOfBookings;
            }
        }


        /*
         * Function: Add new record to the Database
         * with the help of stored procedure
         */
        public void addBooking(Booking bookingRecord)
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connString))
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null. Set the value of Connection String in BookingCatalog->Properties-?Settings.settings");
                }
                else if (bookingRecord == null)
                    throw new Exception("The passed argument 'bookingRecord' is null");

                SqlCommand query = new SqlCommand("addBooking", conn);
                conn.Open();
                query.CommandType = CommandType.StoredProcedure;
                SqlParameter param1 = new SqlParameter("pKodeBooking", SqlDbType.Int);
                SqlParameter param2 = new SqlParameter("pKodeKamar", SqlDbType.Int);
                SqlParameter param3 = new SqlParameter("pTglBooking", SqlDbType.VarChar);
                SqlParameter param4 = new SqlParameter("pTglHabis", SqlDbType.VarChar);
                SqlParameter param5 = new SqlParameter("pNIK", SqlDbType.Int);
                SqlParameter param6 = new SqlParameter("pKodeBayar", SqlDbType.Int);

                param1.Value = bookingRecord.KodeBooking;
                param2.Value = bookingRecord.KodeKamar;
                param3.Value = bookingRecord.TglBooking;
                param4.Value = bookingRecord.TglHabis;
                param5.Value = bookingRecord.NIK;
                param6.Value = bookingRecord.KodeBayar;


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
        public void DelBooking(int id)
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connString))
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null. Set the value of Connection String in BookingCatalog->Properties-?Settings.settings");
                }

                SqlCommand query = new SqlCommand("deleteBooking", conn);
                conn.Open();
                query.CommandType = CommandType.StoredProcedure;
                SqlParameter param1 = new SqlParameter("pKodeBooking", SqlDbType.Int);
                param1.Value = id;
                query.Parameters.Add(param1);

                query.ExecuteNonQuery();
            }
        }

        /*
         * Function: Updates the Booking Record with reference to supplied id
         * with the help of stored procedure
         */
        public void UpdateBooking(Booking bookingRecord)
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.connString))
            {
                if (conn == null)
                {
                    throw new Exception("Connection String is Null. Set the value of Connection String in BookingCatalog->Properties-?Settings.settings");
                }

                SqlCommand query = new SqlCommand("updateBooking", conn);
                conn.Open();
                query.CommandType = CommandType.StoredProcedure;
                SqlParameter param1 = new SqlParameter("pKodeBooking", SqlDbType.Int);
                SqlParameter param2 = new SqlParameter("pKodeKamar", SqlDbType.Int);
                SqlParameter param3 = new SqlParameter("pTglBooking", SqlDbType.VarChar);
                SqlParameter param4 = new SqlParameter("pTglHabis", SqlDbType.VarChar);
                SqlParameter param5 = new SqlParameter("pNIK", SqlDbType.Int);
                SqlParameter param6 = new SqlParameter("pKodeBayar", SqlDbType.Int);

                param1.Value = bookingRecord.KodeBooking;
                param2.Value = bookingRecord.KodeKamar;
                param3.Value = bookingRecord.TglBooking;
                param4.Value = bookingRecord.TglHabis;
                param5.Value = bookingRecord.NIK;
                param6.Value = bookingRecord.KodeBayar;


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
