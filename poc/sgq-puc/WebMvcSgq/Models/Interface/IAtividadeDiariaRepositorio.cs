using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMvcSgq.Models.Classe;

namespace WebMvcSgq.Models.Interface
{
   public interface IAtividadeDiariaRepositorio
    {
        IEnumerable<Tbl_Atividade_Diaria> GetAtividadeDiaria();
        Tbl_Atividade_Diaria GetAtividadePorID(long idAtivDiaria);
        void AdicionaAtividadeDiaria(Tbl_Atividade_Diaria ativDiaria);
        void DeletarAtividadeDiaria(long idAtivDiaria);
        void EditarAtividadeDiaria(Tbl_Atividade_Diaria ativDiaria, List<tbl_atividades> listaAtividades);
        Tbl_Atividade_Diaria Detalhes(int idAtivDiaria);

        #region NovoMetodo Interface
        AtiviModelView GetAtividadeDiariaPorID(long idAtivDiaria);

        void EditarAtividadeDiaria(AtiviModelView ativDiaria);
        #endregion 
    }
}
