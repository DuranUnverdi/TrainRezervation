using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainRes.Model;

namespace TrainRes.Repositories
{
    public class TrainRepository : ITrainRepository
    {
        private readonly Context _context;
        public TrainRepository()
        {
        }
        public TrainRepository(Context context)
        {
            _context = context;
        }
        public async Task<Train> Create(Train train)
        {
            _context.Trains.Add(train);
            await _context.SaveChangesAsync();

            return train;
        }
        public async Task<IEnumerable<Train>> Get()
        {
            return await _context.Trains.Include(x => x.Vagons).ToListAsync();
        }

        public async Task<Train> Get(int id)
        {
            return await _context.Trains.FindAsync(id);
        }

        public ResOutModel TryRes(ResModel res)
        {
            var resOutModel = new ResOutModel();
            List<Detail> listDetail = new();
            var train = _context.Trains.Where(x => x.Id == res.TrainId).Include(x => x.Vagons).FirstOrDefaultAsync();
            var vagons = train.Result.Vagons;
            var ticketCount = res.NumberofPersonstoReservation;
            var dif = res.PersonsDifferentWagons;
            var difticket = res.PersonsDifferentWagons ? 0 : ticketCount;
            foreach (var vagon in vagons)
            {
                if (vagon.Capacity * 0.7 >= (vagon.FullSeat + difticket))
                {
                    if (ticketCount < vagon.Capacity - vagon.FullSeat + difticket && ticketCount > 0)
                    {
                        var bilet = 0;
                        var yervar = Convert.ToInt32((vagon.Capacity * 0.7) - vagon.FullSeat);
                        bilet = yervar < ticketCount ? yervar : ticketCount;
                        listDetail.Add(new Detail()
                        {
                            Name = vagon.Name.ToString(),
                            Count = Convert.ToInt32(bilet)
                        });
                        ticketCount = ticketCount - yervar;
                        if (ticketCount<1)
                        {
                            resOutModel.Available = true;
                        }
                    }
                }
                else
                {
                    resOutModel.Available = false;
                }
                if (ticketCount < 1)
                {
                    break;
                }
            }
            resOutModel.Details = listDetail;
            if (resOutModel.Available==false)
            {
                resOutModel.Details.Clear();
            }
            return resOutModel;
        }
    }
}
