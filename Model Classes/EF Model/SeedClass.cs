using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model_Classes.EF_Model
{
    public static class SeedClass
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
               new User
               {
                   User_Id = 1,
                   First_Name = "Rohit",
                   Last_Name = "Negi",
                   Email_Id = "rohitnegi30@yahoo.com",
                   Password = "Rohit-Solutions"
               }
               //new User
               //{
               //    User_Id = 2,
               //    First_Name = "Sonika",
               //    Last_Name = "Negi",
               //    Email_Id = "Sonika@gmail.com",
               //    Password = "Sonika-Solutions"
               //}
               );
        }

    }
}
