using System;
using System.Collections.Generic;
using System.Text;
using InterfaceBusinessLayer;
using InterfaceDataAccess;
using Model_Classes.Model;

namespace BusinessLayer
{
    public class TripService : ITripService
    {
        private ITripRepository _ITripRepository;

        public TripService(ITripRepository TripRepository)
        {
            _ITripRepository = TripRepository;
        }

        public IEnumerable<TripDetail> GetTripDetails()
        {
            IEnumerable<TripDetail> tripDetail = _ITripRepository.GetTripDetails();
            return tripDetail;
        }
        public bool AddOrEditTrip(TripDetail tripDetail)
        {
            _ITripRepository.AddOrEditTrip(tripDetail);
            return true;
        }
       
    }
}
