using Microsoft.AspNetCore.Rewrite.Internal.IISUrlRewrite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Codenation.Challenge.Models
{
    [Table("user")]
    public class User
    {   
        [Key, Column("id"), Required]
        public int Id { set; get; }


        [Required, Column("full_name"), MaxLength(100)]
        public string FullName { set; get; }

        [Required, Column("email"),  MaxLength(100)]
        public string Email { set; get; }


        [Required, Column("nickname"), MaxLength(50)]
        public string NickName { set; get; }


        [Required, Column("password"), MaxLength(255)]
        public string Password { set; get; }


        [Required, Column("created_at")]
        public DateTime CreateAt { set; get; }

        public List<Submission> Submissions {get; set; }
        public List<Candidate> Candidates { get; set; }
    }
}
