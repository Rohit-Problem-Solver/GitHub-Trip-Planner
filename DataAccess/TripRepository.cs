using System;
using System.Collections.Generic;
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
        // To Add the Trip Details 
        public bool AddOrEditTrip(TripDetail tripDetail)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connString))
                {
                    SqlCommand cmd = new SqlCommand("usp_AddTrip", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@Trip_Id", tripDetail.TripId);
                    cmd.Parameters.AddWithValue("@No_Of_Days", tripDetail.NoOfDays);
                    cmd.Parameters.AddWithValue("@No_Of_People", tripDetail.NoOfPeople);
                    cmd.Parameters.AddWithValue("@Budget", tripDetail.Budget);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    return true;

                }
            }
            catch(Exception ex)
            {
                return false;
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
