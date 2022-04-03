using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Passenger.API.Repository
{
    public interface IPassengerRespository
    {
        Task<List<Passenger.API.Model.Passenger>> Get();
        Task Create(Passenger.API.Model.Passenger data);
        Task<Passenger.API.Model.Passenger> GetById(Guid id);
        Task Update(Passenger.API.Model.Passenger data);
        Task Delete(Guid id);

    }
}