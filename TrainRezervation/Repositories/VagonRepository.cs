using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TrainRes.Model;

namespace TrainRes.Repositories
{
    public class VagonRepository : IVagonRepository
    {
        private readonly Context _context;
        public VagonRepository(Context context)
        {
            _context = context;
        }

        public async Task<Vagon> Create(Vagon vagon)
        {
            _context.Vagons.Add(vagon);
            await _context.SaveChangesAsync();

            return vagon;
        }


        public async Task<IEnumerable<Vagon>> Get()
        {
            return await _context.Vagons.ToListAsync();
        }

        public async Task<Vagon> Get(int id)
        {
            return await _context.Vagons.FindAsync(id);
        }
    }
}
