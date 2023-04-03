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
                    Id = x.Id,
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
            HouseEditViewModel house = new HouseEditViewModel();

            return View("Edit", house);
        }

        [HttpPost]
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
            if (result is null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), vm);
        }

        [HttpGet]

        public async Task<IActionResult> Edit(Guid id)
        {
            var house = await _houseServices.GetAsync(id);

            if (house == null)
            {
                return NotFound();
            }

            var vm = new HouseEditViewModel()
            {
                Id = house.Id,
                Name = house.Name,
                Address = house.Address,
                Square = house.Square,
                NumberOfRooms = house.NumberOfRooms,
                CreatedAt = house.CreatedAt,
                ModifiedAt = house.ModifiedAt,
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(HouseEditViewModel vm)
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

            var result = await _houseServices.Update(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), vm);
        }
    }
}
