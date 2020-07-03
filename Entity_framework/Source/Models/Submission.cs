using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Codenation.Challenge.Models
{
    [Table("submission")]
    public class Submission
    {
        [Column("user_id"), Required]
        [ForeignKey("User")]
        public int UserID { set; get; }

    
        public User User { set; get; }

        [Column("challenge_id"),Required]
        [ForeignKey("Challenge")]
        public int ChallengeId { set; get; }

        
        public Challenge Challenge { set; get; }

        [Column("score"), Required]
        public decimal Score { set; get; }

        [Column("created_at") ,Required]
        public DateTime CreateAt { set; get; }
    }
}
