using Model_Classes.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace InterfaceBusinessLayer
{
    public interface ITripService
    {
        IEnumerable<TripDetail> GetTripDetails();
        int AddOrEditTrip(TripDetail tripDetail);
        TripDetail GetTrip(int Id);
    }
}
