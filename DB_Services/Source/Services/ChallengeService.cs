using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public class ChallengeService : IChallengeService
    {
        private CodenationContext _context;
        public ChallengeService(CodenationContext context)
        {
            _context = context;
        }

        public IList<Models.Challenge> FindByAccelerationIdAndUserId(int accelerationId, int userId)
        {
            
            return _context.Candidates
                .Where(candidate => candidate.UserId == userId && candidate.AccelerationId == accelerationId)
                .Select(candidate => candidate.Acceleration)
                .Select(ac => ac.Challenge)
                .Distinct()
                .ToList();
        }

        public Models.Challenge Save(Models.Challenge challenge)
        {
            if (0 == challenge.Id)
            {
                _context.Challenges.Add(challenge);
            }
            else {
                _context.Challenges.Update(challenge);
            }

            _context.SaveChanges();

            return challenge;
        }
    }
}