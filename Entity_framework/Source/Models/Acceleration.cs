using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codenation.Challenge.Models
{
    [Table("acceleration")]
    public class Acceleration
    {
        [Key, Column("id"), Required]
        public int Id { set; get; }

        [Required, Column("name"),MaxLength(100)]
        public string Name { set; get; }

        [Required, Column("slug"), MaxLength(50)]
        public string Slug { set; get; }

        [Required, Column("challenge_id")]
        [ForeignKey("Challenge")]
        public int ChallengeId { get; set; }

     
        public Challenge Challenge { get; set; }

        [Column("created_at"),Required]
        public DateTime CreateAt { get; set; }

        public List<Candidate> Candidates { get; set; }

    }
}
