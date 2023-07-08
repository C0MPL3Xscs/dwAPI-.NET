using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrabalhoDW.TrabalhoDW.Models
{

    /// <summary>
    /// Dados das reviews dos eventos
    /// </summary>
    public class Reviews{

        public Reviews() {
            
        }

        public int id { get; set; }

        public DateTime created_at { get; set; }

        /// <summary>
        /// Rating do evento
        /// </summary>
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
        [RegularExpression("[1-5]")]
        public int rating { get; set; }

        /// <summary>
        /// Comentário da review
        /// </summary>
        [Display(Name = "Comentário")]
        public string comment { get; set; }

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
