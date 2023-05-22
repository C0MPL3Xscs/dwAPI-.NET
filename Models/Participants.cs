using System.ComponentModel.DataAnnotations.Schema;

namespace TrabalhoDW.TrabalhoDW.Models
{
    /// <summary>
    /// Dados dos participantes dos eventos
    /// </summary>
    public class Participants{

        public Participants() { }

        public int Id { get; set; }



        /* ++++++++++++++++++++++++++++++++++++++++++ 
        * Criação das chaves forasteiras
        * ++++++++++++++++++++++++++++++++++++++++++ 
        */

        /// <summary>
        /// FK para o User_ID
        /// </summary>
        [ForeignKey(nameof(User))]
        public int UserFK { get; set; }
        public Users User { get; set; }

        /// <summary>
        /// FK para o Event_ID
        /// </summary>
        [ForeignKey(nameof(Event))]
        public int EventFK { get; set; }
        public Events Event { get; set; }
    }
}
