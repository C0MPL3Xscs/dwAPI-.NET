using System.ComponentModel.DataAnnotations;

namespace TrabalhoDW.TrabalhoDW.Models
{

    /// <summary>
    /// Dados dos utilizadores
    /// </summary>
    public class Users{

        public Users(){
            // inicializar a lista de eventos em o utilizador participa
            listaParticipant = new HashSet<Participants>();
            // inicializar a lista de eventos que o utilizador criou
            listaCreated = new HashSet<Events>();

        }

        public int Id { get; set; }

        public DateTime created_at { get; set; }

        /// <summary>
        /// Nome do user
        /// </summary>
        [Required(ErrorMessage = "O Nome é de preenchimento obrigatório")]
        [Display(Name = "Nome")]
        [StringLength(maximumLength:30)]
        public string Name { get; set; }

        /// <summary>
        /// Nome do user
        /// </summary>
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
        public string Email { get; set; }

        /// <summary>
        /// Nome do user
        /// </summary>
        [Required(ErrorMessage = "A {0} é de preenchimento obrigatório")]
        public string Password { get; set; }


        /// <summary>
        /// Nome do user
        /// </summary>
        [Display(Name= "Imagem de perfil")]
        public string img { get; set; }

        /* ++++++++++++++++++++++++++++++++++++++++++++++++
        * relacionamentos associados aos Utilizadores
        */

        /// <summary>
        /// Lista dos eventos em que o utilizador participa
        /// </summary>
        public ICollection<Participants> listaParticipant { get; set; }

        /// <summary>
        /// Lista dos eventos que o utilizador criou
        /// </summary>
        public ICollection<Events> listaCreated { get; set; }
    }
}
