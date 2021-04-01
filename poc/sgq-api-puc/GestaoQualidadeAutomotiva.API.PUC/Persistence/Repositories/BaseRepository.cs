using GestaoQualidadeAutomotiva.API.PUC.Persistence.Contexts;

namespace sgq_api_puc.Persistence.Repositories
{
    public class BaseRepository
    {
        protected readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }
    }
}
