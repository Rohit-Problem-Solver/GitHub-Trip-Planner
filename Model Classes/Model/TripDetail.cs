using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Model_Classes.Model
{
    public class TripDetail
    {
        public int TripId { get; set; }
        [Required]
        public int NoOfDays { get; set; }
        [Required]
        public int NoOfPeople { get; set; }
        [Required]
        public int Budget { get; set; }

    }
}
