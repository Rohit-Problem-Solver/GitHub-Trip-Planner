using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;

namespace Model_Classes.EF_Model
{
    public class User
    {
        [Key]
        public int User_Id { get; set; }
        [Required]
        public string First_Name { get; set; }
        [Required]
        public string Last_Name { get; set; }
        [Required]
        public string Email_Id { get; set; }
        [Required]
        public string Password { get; set; }
        public string Custom_Field { get; set; }

    }
}
