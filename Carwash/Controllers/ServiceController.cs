using Carwash.Models;
using Carwash.Services;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;

namespace Carwash.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IMainService _mainService;

        public ServiceController(IMainService mainService)
        {
            _mainService = mainService;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        public async Task<DataSourceResult> Data_Kendo([DataSourceRequest] DataSourceRequest request)
        {
            var query = _mainService.GetAllServices();
            return await query.ToDataSourceResultAsync(request);
        }

        [HttpPost]
        public async Task<OkResult> Create(ServiceModel model)
        {
            await _mainService.CreateService(model);
            return Ok();
        }

        [HttpGet]
        public async Task<OkResult> Completed(long id)
        {
            await _mainService.CompletedService(id);
            return Ok();
        }
        
        [HttpGet]
        public async Task<JsonResult> Car_Read()
        {
            var result = await _mainService.GetAllCars();
            return Json(result);
        }
    }
}
