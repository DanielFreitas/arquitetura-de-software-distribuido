using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMvcSgq.Models.Interface
{
    public interface IEtapaRepositorio
    {
        IEnumerable<tbl_etapa> GetEtapas(long processoId);
        tbl_etapa GetEtapaProcessoPorID(long idProcesso);

        tbl_etapa GetEtapaByID(long idEtapa);

        IEnumerable<tbl_etapa> GetEtapas();

        void AdicionaEtapa(tbl_etapa etapa);
        void DeletaEtapa(long etapaId);
        void AtualizaEtapa(tbl_etapa etapa);
        tbl_etapa Detalhes(long etapaId);
    }
}
