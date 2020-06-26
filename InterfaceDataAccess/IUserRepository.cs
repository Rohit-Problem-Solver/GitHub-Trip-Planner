using InterfaceDataAccess;
using Model_Classes;
using Model_Classes.EF_Model;
using System;
using System.Collections.Generic;

namespace InterfaceDataAccess
{
    public interface IUserRepository
    {
        public User Add(User user);
        public User Delete(int Id);
        public IEnumerable<User> GetAllEmployee();
        public User GetEmployee(int Id);
        public User Update(User UserChanges);
    }
}
