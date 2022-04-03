using Microsoft.EntityFrameworkCore;
using Passenger.API.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Passenger.API.Repository
{
    public class PassengerRespository : IPassengerRespository
    {
        const string cacheKey = "passengerKey";
        private readonly PassengerContext _context;

        public PassengerRespository(PassengerContext context)
        {
            _context = context;
        }

        public async Task<List<Passenger.API.Model.Passenger>> Get()
        {
            return await _context.Passengers.ToListAsync();
        }
        public async Task<Passenger.API.Model.Passenger> GetById(Guid id)
        {
            return await _context.Passengers.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Create(Passenger.API.Model.Passenger data)
        {
            data.Id = Guid.NewGuid();
            _context.Add(data);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Model.Passenger data)
        {
            var passenger = await _context.Passengers.FirstOrDefaultAsync(x => x.Id == data.Id);

            if (passenger == null)
                throw new ArgumentException("Record not found!");

            passenger.DocumentNo = data.DocumentNo;
            passenger.DocumentType = data.DocumentType;
            passenger.Gender = data.Gender;
            passenger.IssueDate = data.IssueDate;
            passenger.Name = data.Name;
            passenger.Surname = data.Surname;

            _context.Passengers.Update(passenger);

            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var passenger = await _context.Passengers.FirstOrDefaultAsync(x => x.Id == id);

            if (passenger == null)
                throw new ArgumentException("Record not found!");

            _context.Passengers.Remove(passenger);
            await _context.SaveChangesAsync();
        }
    }
}