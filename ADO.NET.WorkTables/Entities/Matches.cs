using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET.WorkTables.Entities
{
    public class Match
    {
        public int Id { get; set; }

        public int Team1Id { get; set; }
        public SoccerComandModel Team1 { get; set; }

        public int Team2Id { get; set; }
        public SoccerComandModel Team2 { get; set; }

        public int Team1Goals { get; set; }
        public int Team2Goals { get; set; }

        public int ScorerId { get; set; }
        public Player Scorer { get; set; }

        public DateTime MatchDate { get; set; }
    }
}
