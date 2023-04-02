using House.Core.Domain;
using House.Core.Dto;
using House.Core.ServiceInterface;
using House.Data;
using Microsoft.EntityFrameworkCore;

namespace House.ApplicationServices.Services
{
    public class HouseServices : IHouseServices
    {
        private readonly HouseDbContext _context;

        public HouseServices
            (
                HouseDbContext context
            )
        {
            _context = context;
        }

        public async Task<HouseDomain> Add(HouseDto dto)
        {
            HouseDomain house = new HouseDomain();

            house.Id = dto.Id;
            house.Name = dto.Name;
            house.Address = dto.Address;
            house.Square = dto.Square;
            house.NumberOfRooms = dto.NumberOfRooms;
            house.CreatedAt = dto.CreatedAt;
            house.ModifiedAt = dto.ModifiedAt;

            await _context.House.AddAsync(house);
            await _context.SaveChangesAsync();

            return house;
        }
    }
}
