namespace TrabalhoDW.TrabalhoDW.Models
{
    /// <summary>
    /// Tags
    /// </summary>
    public class Event_Tags{

        public Event_Tags() {
            // inicializar as Tags do evento
            eventTags = new HashSet<Event_Tagging>();
        }

        public int id { get; set; }

        /* ++++++++++++++++++++++++++++++++++++++++++++++++
        * relacionamentos associados aos Eventos
        */


        /// <summary>
        /// Tags associadas ao Evento
        /// </summary>
        public ICollection<Event_Tagging> eventTags { get; set; }

    }
}
