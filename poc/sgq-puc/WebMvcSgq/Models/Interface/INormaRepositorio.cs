using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebMvcSgq.Models.Classe;

namespace WebMvcSgq.Models.Interface
{
   public interface INormaRepositorio
    {
        IEnumerable<LinksWrapper<Content>> GetAll();
        LinksWrapper<Content> GetNormaById(Int64 normaId);

        void Atualiza(ICollection<Tbl_NaoConformidade_x_Norma> naoConformidade_x_Norma);
        void DeleteNaoConformidade_x_Norma(ICollection<Tbl_NaoConformidade_x_Norma> naoConformidade_x_Norma);
        void AdicionaNaoConformidade_x_Norma(ICollection<Tbl_NaoConformidade_x_Norma> naoConformidade_x_Norma);     
    }
}