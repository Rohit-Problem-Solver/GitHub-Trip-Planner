using System;
using System.Collections.Generic;
using System.Text;

namespace Model_Classes.Model
{
    class TripDayPlan
    {
        public int DayPlanId { get; set; }
        public int DayId { get; set; }
        public string FromTime { get; set; }
        public string ToTime { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
