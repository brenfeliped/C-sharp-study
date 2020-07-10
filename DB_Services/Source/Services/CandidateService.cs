using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;
using System.Linq.Expressions;

namespace Codenation.Challenge.Services
{
    public class CandidateService : ICandidateService
    {
        private CodenationContext _context;
        public CandidateService(CodenationContext context)
        {
            _context = context;
        }

        public IList<Candidate> FindByAccelerationId(int accelerationId)
        {
            return _context.Candidates
                .Where(c => c.AccelerationId == accelerationId)
                .ToList();
        }

        public IList<Candidate> FindByCompanyId(int companyId)
        {
            return _context.Candidates
                .Where(c => c.CompanyId == companyId)
                .ToList();
            
        }

        public Candidate FindById(int userId, int accelerationId, int companyId)
        {
           return _context.Candidates
                .First(canditate => canditate.UserId == userId && canditate.AccelerationId == accelerationId 
                && canditate.CompanyId == companyId);
           
        }

        public Candidate Save(Candidate candidate)
        {
            var hasCandidate =  _context.Candidates
                .Any(c => c.CompanyId == candidate.CompanyId && 
                c.AccelerationId == candidate.AccelerationId 
                && c.UserId == candidate.UserId);

            if (!hasCandidate)
            {
                _context.Candidates.Add(candidate);
            }
            else {
                _context.Candidates.Update(candidate);
            }

            _context.SaveChanges();

            return candidate;
        }
    }
}
