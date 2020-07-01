using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using InterfaceDataAccess;
using Microsoft.Data.SqlClient;
using Model_Classes.Model;

namespace DataAccess
{
    public class TripRepository : ITripRepository
    {
        private readonly string connString;
        public TripRepository()
        {
            connString = "server = .;database=TripPlanner; Trusted_Connection=true";
        }

        #region Trip Details

        public TripDetail GetTrip(int Id)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                TripDetail tripDetail = new TripDetail();
                SqlCommand cmd = new SqlCommand("Select * from Trip_detail_tbl where Trip_Id=" + Id, con);
                cmd.CommandType = System.Data.CommandType.Text;
                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    tripDetail.TripId = Convert.ToInt32(rdr["Trip_Id"]);
                    tripDetail.NoOfDays = Convert.ToInt32(rdr["No_Of_Days"]);
                    tripDetail.NoOfPeople = Convert.ToInt32(rdr["No_Of_People"]);
                    tripDetail.Budget = Convert.ToInt32(rdr["Budget"]);
                }
                return tripDetail;
            }
        }
        // To Add the Trip Details 
        public int AddOrEditTrip(TripDetail tripDetail)
        {
            try
            {
                int result;
                using (SqlConnection con = new SqlConnection(connString))
                {
                    SqlCommand cmd = new SqlCommand("usp_AddEditTrip", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Trip_Id", tripDetail.TripId);
                    cmd.Parameters.AddWithValue("@No_Of_Days", tripDetail.NoOfDays);
                    cmd.Parameters.AddWithValue("@No_Of_People", tripDetail.NoOfPeople);
                    cmd.Parameters.AddWithValue("@Budget", tripDetail.Budget);

                    SqlParameter outputParam = cmd.Parameters.Add("@out_trip_Id", SqlDbType.Int);
                    outputParam.Direction = ParameterDirection.Output;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    result = (int)cmd.Parameters["@out_trip_Id"].Value;
                }

                return result;

            }
            catch(Exception ex)
            {
                return 0;
            }
        }
        public bool EditTrip(TripDetail tripDetail)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connString))
                {
                    SqlCommand cmd = new SqlCommand("usp_EditTrip", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Trip_Id", tripDetail.TripId);
                    cmd.Parameters.AddWithValue("@No_Of_Days", tripDetail.NoOfDays);
                    cmd.Parameters.AddWithValue("@No_Of_People", tripDetail.NoOfPeople);
                    cmd.Parameters.AddWithValue("@Budget", tripDetail.Budget);

                    con.Open();
                    cmd.ExecuteNonQuery();

                    return true;

                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public IEnumerable<TripDetail> GetTripDetails()
        {
            try
            {
                List<TripDetail> tripDetailsList = new List<TripDetail>();
                using (SqlConnection con = new SqlConnection(connString))
                {

                    SqlCommand cmd = new SqlCommand("Select * from Trip_detail_tbl", con);
                    cmd.CommandType = System.Data.CommandType.Text;
                    con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        TripDetail tripDetails = new TripDetail();
                        tripDetails.TripId = Convert.ToInt32(rdr["Trip_Id"]);
                        tripDetails.NoOfDays = Convert.ToInt32(rdr["No_Of_Days"]);
                        tripDetails.NoOfPeople = Convert.ToInt32(rdr["No_Of_People"]);
                        tripDetails.Budget = Convert.ToInt32(rdr["Budget"]);

                        tripDetailsList.Add(tripDetails);
                    }

                }
                return tripDetailsList;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        #endregion
    }
}
