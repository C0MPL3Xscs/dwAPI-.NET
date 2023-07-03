using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace TrabalhoDW.TrabalhoDW.Models
{


    /// <summary>
    /// Dados dos Eventos
    /// </summary>
    public class Events
    {

        public Events()
        {
            // inicializar a lista de Reviews do evento
            listaReviewsEvents = new HashSet<Reviews>();
            // inicializar a lista de Convites do evento
            listaInvitations = new HashSet<Invitations>();
            // inicializar as Tags do evento
            Tags = new HashSet<Event_Tagging>();
            // inicializar a lista de Participantes do evento
            listaParticipants = new HashSet<Participants>();
        }


        public int Id { get; set; }

        public int host_id { get; set; }

        public DateTime created_at { get; set; }

        /// <summary>
        /// Nome do evento
        /// </summary>
        [Required(ErrorMessage = "O nome do evento é de preenchimento obrigatório")]
        [StringLength(maximumLength: 30)]
        [Display(Name = "Nome do evento")]
        public string title { get; set; }

        /// <summary>
        /// Descrição do evento
        /// </summary>
        [Display(Name = "Descrição do evento")]
        public string Description { get; set; }

        /// <summary>
        /// Imagem do evento
        /// </summary>
        /// <summary>
        [Column(TypeName = "nvarchar(MAX)")]
        [DefaultValue("('https://www.wolflair.com/wp-content/uploads/2017/01/placeholder.jpg')")]
        public string Image { get; set; }


        /// <summary>
        /// Data de começo do evento
        /// </summary>
        [Required(ErrorMessage = "A data inicial é de preenchimento obrigatório")]
        [Display(Name = "Data Inicial")]
        [RegularExpression("[1-30]/[1-12]/[2023-2030]")]
        public DateTime start_time { get; set; }

        /// <summary>
        /// Data do termino do evento
        /// </summary>
        [Required(ErrorMessage = "A data final é de preenchimento obrigatório")]
        [RegularExpression("[1-30]/[1-12]/[2023-2030]")]
        public DateTime end_time { get; set; }

        /// <summary>
        /// Local do evento
        /// </summary>
        [Display(Name = "Local")]
        public string location { get; set; }

        /// <summary>
        /// Privacidade do evento
        /// </summary>
        [Required(ErrorMessage = "A privacidade do evento é de preenchimento obrigatório")]
        [Display(Name = "Privacidade do evento")]
        public bool is_private { get; set; }

        /// <summary>
        /// Máximo de participantes do evento
        /// </summary>
        [Required(ErrorMessage = "O Máximo de participantes do evento é de preenchimento obrigatório")]
        [Display(Name = "Máximo de Participantes")]
        public int maxParticipants { get; set; }

        /* ++++++++++++++++++++++++++++++++++++++++++++++++
        * relacionamentos associados aos Eventos
        */

        /// <summary>
        /// Lista das Reviews associadas ao Evento
        /// </summary>
        public ICollection<Reviews> listaReviewsEvents { get; set; }

        /// <summary>
        /// Lista das Convites associados ao Evento
        /// </summary>
        public ICollection<Invitations> listaInvitations { get; set; }

        /// <summary>
        /// Tags associadas ao Evento
        /// </summary>
        public ICollection<Event_Tagging> Tags { get; set; }

        /// <summary>
        /// Lista dos Participantes associados ao Evento
        /// </summary>
        public ICollection<Participants> listaParticipants { get; set; }
    }
}