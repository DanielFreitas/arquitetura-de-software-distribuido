using GestaoQualidadeAutomotiva.API.PUC.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoQualidadeAutomotiva.API.PUC.Domain.Services
{
    public interface INormaService
    {
        Task<IEnumerable<Norma>> GetListNorma();
        void AddNorma(Norma norma);
        Task<Norma> GetNorma(int id);
        void UpdateNorma(Norma norma);
        void DeleteNorma(Norma norma);
    }
}
