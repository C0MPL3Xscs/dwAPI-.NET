using System.ComponentModel.DataAnnotations.Schema;

namespace TrabalhoDW.TrabalhoDW.Models
{
    /// <summary>
    /// Tags associadas ao Evento
    /// </summary>
    public class Event_Tagging{

        public Event_Tagging(){

        }

        public int Id { get; set; }

        /* ++++++++++++++++++++++++++++++++++++++++++ 
        * Criação das chaves forasteiras
        * ++++++++++++++++++++++++++++++++++++++++++ 
        */

        /// <summary>
        /// FK para o Event_ID
        /// </summary>
        [ForeignKey(nameof(Event))]
        public int EventFK { get; set; }
        public Events Event { get; set; }

        /// <summary>
        /// FK para o Tags_ID
        /// </summary>
        [ForeignKey(nameof(Tags))]
        public int tagFK { get; set;}
        public Event_Tags Tags { get; set; }
    }

    
}
