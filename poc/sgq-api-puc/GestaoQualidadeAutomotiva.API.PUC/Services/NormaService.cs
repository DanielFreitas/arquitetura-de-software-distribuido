using System.Collections.Generic;
using GestaoQualidadeAutomotiva.API.PUC.Domain.Models;
using System.Threading.Tasks;
using GestaoQualidadeAutomotiva.API.PUC.Domain.Repositories;
using GestaoQualidadeAutomotiva.API.PUC.Domain.Services;

namespace GestaoQualidadeAutomotiva.API.PUC.Services
{
    public class NormaService : INormaService
    {
        private readonly INormaRepository _normaRepository;

        public NormaService(INormaRepository context)
        {
            _normaRepository = context;
        }

        public void AddNorma(Norma norma)
        {
            _normaRepository.Add(norma);
        }

        public void DeleteNorma(Norma norma)
        {
            _normaRepository.Remove(norma);
        }

        public Task<IEnumerable<Norma>> GetListNorma()
        {
            return _normaRepository.ListAsync();
        }

        public Task<Norma> GetNorma(int id)
        {
            return _normaRepository.FindByIdAsync(id);
        }

        public void UpdateNorma(Norma norma)
        {
            _normaRepository.Update(norma);
        }
    }
}
