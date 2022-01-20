using System.Collections.Generic;
using System.Threading.Tasks;
using TrainRes.Model;

namespace TrainRes.Repositories
{
    public interface IVagonRepository
    {
        Task<IEnumerable<Vagon>> Get();
        Task<Vagon> Get(int id);
        Task<Vagon> Create(Vagon vagon);

    }
}
