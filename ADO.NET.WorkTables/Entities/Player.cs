using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET.WorkTables.Entities
{
    public class Player
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Country { get; set; }
        public int Number { get; set; }
        public string Position { get; set; }

        public int TeamId { get; set; }
        public SoccerComandModel Team { get; set; }
    }
}
   