using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrabalhoDW.TrabalhoDW.Models
{

    /// <summary>
    /// Dados dos convites
    /// </summary>
    public class Invitations{

        public Invitations() {
            
        }

        public int id {  get; set; }

        public bool is_valid { get; set; }

        /// <summary>
        /// Código do convite
        /// </summary>
        [Required(ErrorMessage = "O código é de preenchimento obrigatório")]
        [StringLength(maximumLength:4)]
        public string code { get; set; }

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
