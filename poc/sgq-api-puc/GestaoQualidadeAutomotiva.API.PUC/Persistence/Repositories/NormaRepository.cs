using GestaoQualidadeAutomotiva.API.PUC.Domain.Models;
using GestaoQualidadeAutomotiva.API.PUC.Domain.Repositories;
using GestaoQualidadeAutomotiva.API.PUC.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sgq_api_puc.Persistence.Repositories
{
    public class NormaRepository : BaseRepository, INormaRepository
    {
        public NormaRepository(AppDbContext context) : base(context)
        { }

        public void Add(Norma norma)
        {
            _context.Norma.Add(norma);
            _context.SaveChanges();
        }

        public async Task<Norma> FindByIdAsync(int id)
        {
            var entity = await _context.Norma.FindAsync(id);

            if (entity != null)
                _context.Entry(entity).State = EntityState.Detached;

            return entity;
        }

        public async Task<IEnumerable<Norma>> ListAsync()
        {
            return await _context.Norma.AsNoTracking().ToListAsync();
        }

        public void Remove(Norma norma)
        {
            _context.Norma.Remove(norma);
            _context.SaveChanges();
        }

        public void Update(Norma norma)
        {
            _context.Entry(norma).State = EntityState.Modified;
            _context.Norma.Update(norma);
            _context.SaveChanges();
        }
    }
}
