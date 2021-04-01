using System;
using System.ComponentModel.DataAnnotations;

namespace GestaoQualidadeAutomotiva.API.PUC.Domain.Models
{
    public class Norma 
    {
        
        [Key]
        public int NormaId { get; set; }
        public String Titulo { get; set; }
        public DateTime DataPublicacao { get; set; }
        public String Comite { get; set; }
        public String Status { get; set; }
        public String Organismo { get; set; }
        public String Objetivo { get; set; }
        public String UrlDocumento { get; set; }

        public Norma()
        {

        }

        public Norma(int normaId, string titulo, DateTime dataPublicacao, string comite, string status, string organismo, string objetivo, string urlDocumento)
        {
            NormaId = normaId;
            Titulo = titulo;
            DataPublicacao = dataPublicacao;
            Comite = comite;
            Status = status;
            Organismo = organismo;
            Objetivo = objetivo;
            UrlDocumento = urlDocumento;
        }
    }
}
