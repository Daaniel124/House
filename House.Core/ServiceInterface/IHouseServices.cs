using House.Core.Domain;
using House.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House.Core.ServiceInterface
{
    public interface IHouseServices : IApplicationServices
    {
        Task<HouseDomain> Add(HouseDto dto);
    }
}
