using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainRes.Model;

namespace TrainRes.Repositories
{
    public interface ITrainRepository
    {
        Task<IEnumerable<Train>> Get();
        Task<Train> Get(int id);
        Task<Train> Create(Train train);
        ResOutModel TryRes(ResModel res);
        

    }
}
