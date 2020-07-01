using System;
using System.Collections.Generic;
using System.Text;
using Model_Classes.Model;

namespace InterfaceDataAccess
{
    public interface ITripRepository
    {
        IEnumerable<TripDetail> GetTripDetails();
        int AddOrEditTrip(TripDetail tripDetail);
        TripDetail GetTrip(int Id);

    }
}
