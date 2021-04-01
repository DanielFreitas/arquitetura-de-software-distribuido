using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMvcSgq.Models.Classe;

namespace WebMvcSgq.Models.Interface
{
  public  interface INaoConformidadeRepositorio
    {

        IEnumerable<tbl_NaoConformidade> GetNaoConformidade();
        tbl_NaoConformidade GetNaoConformidadePorID(long naoConformidadeId);
        void AdicionaNaoConformidade(tbl_NaoConformidade naoConformidade);
        void DeletaNaoConformidade(long naoConformidadeId);
        void AtualizaNaoConformidade(tbl_NaoConformidade naoConformidade);
        tbl_NaoConformidade Detalhes(long naoConformidadeId);
        IList<NaoConformidades> GetNaoConformidadeRelatorio(ref RelatNaoConformidadeClass relNaoConform);
        tbl_NaoConformidade GetNaoConformidadePorAtividadeDiaria(long idAtividadeDiaria);

    }
}
