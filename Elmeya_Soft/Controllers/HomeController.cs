using Elmeya_Soft.IService;
using Elmeya_Soft.Models;
using Elmeya_Soft.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace Elmeya_Soft.Controllers
{
    public class HomeController : Controller
    {
        private readonly IInvoiceService _invoiceService;
        private readonly IClientService _clientService;
        private readonly ITypeService _typeService;
        private readonly ICategoryService _categoryService;

        public HomeController(IInvoiceService invoiceService,
            IClientService clientService,
            ITypeService typeService,
            ICategoryService categoryService
            )
        {
            _invoiceService = invoiceService;
            _clientService = clientService;
            _typeService = typeService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _invoiceService.GetInvoices();
            return View(result);
        }
        public async Task<IActionResult> GetInvoiceById(int? Id)
        {
            if(Id == null)
            {
                return BadRequest("Bad Argument");
            }
            var result =  _invoiceService.GetInvoiceById(Id.Value);
            if(result == null)
            {
                throw new ArgumentNullException("there is no invoice with this Id");
            }
            return View(result);
        }
        [HttpGet]
        public async Task<IActionResult> AddInvoice()
        {
            var Clients = await _clientService.GetAllClients();
            var types = await _typeService.GetAllTypes();
            
            ViewBag.Clients = new SelectList(Clients, "Id", "Name");
            ViewBag.Types = new SelectList(types, "Id", "Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddInvoice(AddInvoiceViewModel addInvoiceViewModel)
        {
            if (ModelState.IsValid)
            {
                _invoiceService.AddInvoice(addInvoiceViewModel);
            }
            return View();

        }

        public async Task<IActionResult> GetCategoryDetails(int typeId)
        {
            var CategoryDetails = await _categoryService
                .GetAllCategories(typeId);
            return Json(new SelectList(CategoryDetails, "Id", "Name"));
        }
        public IActionResult GetPrice(int id)
        {
            var price = _categoryService
                .GetPrice(id);
            return Ok(price);
        }



        public IActionResult Privacy()
        {
            return View();
        }
    }
}