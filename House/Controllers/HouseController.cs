using House.Core.Dto;
using House.Core.ServiceInterface;
using House.Data;
using House.Models;
using Microsoft.AspNetCore.Mvc;

namespace House.Controllers
{
    public class HouseController : Controller
    {
        private readonly HouseDbContext _context;
        private readonly IHouseServices _houseServices;

        public HouseController
            (
                HouseDbContext context,
                IHouseServices houseServices
            )
        {
            _context = context;
            _houseServices = houseServices;
        }
        public IActionResult Index()
        {
            var result = _context.House
                .OrderByDescending(y => y.CreatedAt)
                .Select(x => new HouseListViewModel
                {
                    Name = x.Name,
                    Address = x.Address,
                    Square = x.Square,
                    NumberOfRooms = x.NumberOfRooms
                });

            return View(result);
        }
        [HttpGet]
        public IActionResult Add()
        {
            HouseViewModel spaceship = new HouseViewModel();

            return View("Edit");
        }

        [HttpGet]
        public async Task<IActionResult> Add(HouseViewModel vm)
        {
            var dto = new HouseDto()
            {
                Id = vm.Id,
                Name = vm.Name,
                Address = vm.Address,
                Square = vm.Square,
                NumberOfRooms = vm.NumberOfRooms,
                CreatedAt = vm.CreatedAt,
                ModifiedAt = vm.ModifiedAt,

            };

            var result = await _houseServices.Add(dto);
            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), vm);
        }
    }
}
