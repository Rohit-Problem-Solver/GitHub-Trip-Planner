using Microsoft.Data.SqlClient;
using Model_Classes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_API
{
    public class TripDetailAPIClass
    {
        public IEnumerable<TripDetails> GetDetails()
        {
            List<TripDetails> tripDetailsList = new List<TripDetails>();
            using (SqlConnection con = 
                new SqlConnection("server = .;database=TripPlanner; Trusted_Connection=true"))
            {
                
                SqlCommand cmd = new SqlCommand("Select * from Trip_detail_tbl", con);
                cmd.CommandType = System.Data.CommandType.Text;
                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();
                while(rdr.Read())
                {
                    TripDetails tripDetails = new TripDetails();
                    tripDetails.TripId = Convert.ToInt32(rdr["Trip_Id"]);
                    tripDetails.NoOfDays = Convert.ToInt32(rdr["No_Of_Days"]);
                    tripDetails.NoOfPeople = Convert.ToInt32(rdr["No_Of_People"]);
                    tripDetails.Budget = Convert.ToInt32(rdr["Budget"]);

                    tripDetailsList.Add(tripDetails);
                }

            }
            return tripDetailsList;
        }
    }
}
