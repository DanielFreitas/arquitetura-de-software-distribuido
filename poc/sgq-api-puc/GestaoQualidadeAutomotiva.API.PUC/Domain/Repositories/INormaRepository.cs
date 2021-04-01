using GestaoQualidadeAutomotiva.API.PUC.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoQualidadeAutomotiva.API.PUC.Domain.Repositories
{
    public interface INormaRepository
    {
        Task<IEnumerable<Norma>> ListAsync();
        void Add(Norma norma);
        Task<Norma> FindByIdAsync(int id);
        void Update(Norma norma);
        void Remove(Norma norma);
    }
}
