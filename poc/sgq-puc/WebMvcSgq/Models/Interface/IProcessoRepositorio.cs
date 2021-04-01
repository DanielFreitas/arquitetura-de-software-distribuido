using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMvcSgq.Models.Classe;

namespace WebMvcSgq.Models.Interface
{
   public interface IProcessoRepositorio
    {
        IEnumerable<tbl_Processo> GetProcessos();
        tbl_Processo GetProcessoPorID(long processoId);
        void AdicionaProcesso(tbl_Processo processo);
        void DeletaProcesso(long processoId);
        void AtualizaProcesso(tbl_Processo processo);
        tbl_Processo Detalhes(long processoId);
        IList<RelatorioProcesso> GetProcessoRelatorio(ref RelatorioClass relat);
    }
}
