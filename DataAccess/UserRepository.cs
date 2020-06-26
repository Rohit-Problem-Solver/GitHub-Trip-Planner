using InterfaceDataAccess;
using Model_Classes;
//using Microsoft.EntityFrameworkCore;
using Model_Classes.EF_Model;
using System;
using System.Collections.Generic;

namespace DataAccess
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _context;

        public UserRepository(UserContext context)
        {
            _context = context;
        }
        //Create
        public User Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public User Delete(int Id)
        {
            User user = _context.Users.Find(Id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
            return user;
        }

        public IEnumerable<User> GetAllEmployee()
        {
            return _context.Users;
        }

        public User GetEmployee(int Id)
        {
            return _context.Users.Find(Id);
        }

        public User Update(User UserChanges)
        {
            var user = _context.Users.Attach(UserChanges);
            user.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return UserChanges;
        }
    }
}
