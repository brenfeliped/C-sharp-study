using Codenation.Challenge.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Codenation.Challenge.Models
{
     [Table("candidate")]
    public class Candidate
    {
        [Required, Column("user_id")]
        [ForeignKey("User")]
        public int UserId { get; set; }
        
      
        public User User { get; set; }

        [Required, Column("acceleration_id")]
        [ForeignKey("Acceleration")]
        public int AccelerationId { get; set; }
        
   
        public Acceleration Acceleration { get; set; }

        [Required, Column("company_id")]
        [ForeignKey("Company")]
        public int CompanyId { get; set; }

    
        public Company Company { get; set; }

        [Required, Column("status")]
        public int Status { get; set;}

        [Required, Column("created_at")]
        public DateTime CreateAt { get; set; }
    }
}
