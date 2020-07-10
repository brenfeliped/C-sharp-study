using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public class CompanyService : ICompanyService
    {
        private CodenationContext _context;
        public CompanyService(CodenationContext context)
        {
            _context = context;
        }

        public IList<Company> FindByAccelerationId(int accelerationId)
        {
            return  _context.Candidates
                .Where(c => c.AccelerationId == accelerationId)
                .Select(c => c.Company)
                .ToList();
            
        }

        public Company FindById(int id)
        {
           return  _context.Companies.First(company => company.Id == id);
        }

        public IList<Company> FindByUserId(int userId)
        {
            return _context.Candidates
                .Where(c => c.UserId == userId)
                .Select(c => c.Company)
                .Distinct()
                .ToList();
            
        }

        public Company Save(Company company)
        {
            if (company.Id == 0) {
                _context.Companies.Add(company);
            }
            else
            {
                _context.Companies.Update(company);
            }

            _context.SaveChanges();
            return company;
        }
    }
}