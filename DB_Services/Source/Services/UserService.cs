using System.Collections.Generic;
using Codenation.Challenge.Models;
using System.Linq;

namespace Codenation.Challenge.Services
{
    public class UserService : IUserService
    {
        private CodenationContext _context;
        public UserService(CodenationContext context)
        {
            _context = context;
        }

        public IList<User> FindByAccelerationName(string name)
        {
           return _context.Candidates
                .Where(c => c.Acceleration.Name == name)
                .Select(c => c.User)
                .Distinct()
                .ToList();
        }

        public IList<User> FindByCompanyId(int companyId)
        {
             return _context.Candidates
                .Where(c => c.CompanyId == companyId)
                .Select(c => c.User)
                .Distinct()
                .ToList();
        }

        public User FindById(int id)
        {
           return  _context.Users.First(user => user.Id == id);
        }

        public User Save(User user)
        {
            var userSave = _context.Users.Where(u => u.Id == user.Id);
            if (user.Id == 0)
            {
                _context.Users.Add(user);
            }
            else {
               _context.Users.Update(user);
            }
            _context.SaveChanges();

            return user;
        }
    }
}
