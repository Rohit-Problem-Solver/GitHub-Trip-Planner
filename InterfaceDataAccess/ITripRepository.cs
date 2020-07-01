using System;
using System.Collections.Generic;
using System.Text;
using Model_Classes.Model;

namespace InterfaceDataAccess
{
    public interface ITripRepository
    {
        IEnumerable<TripDetail> GetTripDetails();
        bool AddOrEditTrip(TripDetail tripDetail);

    }
}
