using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public class SubmissionService : ISubmissionService
    {
        private CodenationContext _context;
        public SubmissionService(CodenationContext context)
        {
            _context = context;
        }

        public IList<Submission> FindByChallengeIdAndAccelerationId(int challengeId, int accelerationId)
        {
           
           return _context.Submissions
            .Where(sub => sub.User.Candidates
           .Any(c => c.AccelerationId == accelerationId) && sub.ChallengeId == challengeId)
           .ToList();
           
        }

        public decimal FindHigherScoreByChallengeId(int challengeId)
        {
            return _context.Submissions
                .Where(sub => sub.ChallengeId == challengeId)
                .Select(sub => sub.Score)
                .ToList()
                .Max();
            
        }

        public Submission Save(Submission submission)
        {
            var hasSubmission = _context.Submissions
                .Any(sub => sub.UserId == submission.UserId && sub.ChallengeId == submission.ChallengeId);

            if (!hasSubmission)
            {
                _context.Submissions.Add(submission);
            }
            else {
                _context.Submissions.Update(submission);
            }

            _context.SaveChanges();

            return submission;
        }
    }
}
