using System;
using System.Collections.Generic;
using System.Text;

namespace Source
{
    class Player
    {
        public Player(long id, long teamId, string name, DateTime bithDate, int skillLevel, decimal salary)
        {
            this.id = id;
            this.teamId = teamId;
            this.name = name;
            this.bithDate = bithDate;
            this.skillLevel = skillLevel;
            this.salary = salary;
        }
        public long id { set; get; }
        public long teamId { set; get; }
        public string name { set; get; }
        public DateTime bithDate { set; get; } 
        public int skillLevel { set; get; }
        public decimal salary { set; get; }
    }
}
