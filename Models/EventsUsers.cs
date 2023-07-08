using System.ComponentModel.DataAnnotations.Schema;
using TrabalhoDW.TrabalhoDW.Models;

namespace DW3.Models


{
    public class EventsUsers
    {
        public int UserId { get; set; }
        public Users User { get; set; }

        public int EventId { get; set; }
        public Events Event { get; set; }

    }
}
