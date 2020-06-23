using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Source
{
    class Team
    {
        public Team(long id, string name, DateTime createDate, string mainShirtColor, string secondaryShirtColor)
        {
            this.id = id;

            this.name = name;

            this.createDate = createDate;

            this.mainShirtColor = mainShirtColor;

            this.secondaryShirtColor = secondaryShirtColor;

            this.IdCaptain = null;

        }

        


        public long id { set; get; }
        public string name { set; get; }
        public DateTime createDate { set; get; }
        public string mainShirtColor { set; get; }
        public string secondaryShirtColor { set; get; }

        public Nullable<long> IdCaptain { set; get; }

    }
}
