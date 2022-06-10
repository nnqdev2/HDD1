using HDD.Infrastructure.Identity;
using HDD.Web.Interfaces;
using HDD.Web.Services;
using HDD.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HDD.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHDDRepository _dataService;
        //private readonly IFileUploadService _uploadService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IVinService _vinService;
        private readonly IVinOwnershipService _vinOwnershipService;
        private string? userId;
        private ApplicationUser? user;

        public HomeController(ILogger<HomeController> logger, IHDDRepository dataService
            , UserManager<ApplicationUser> userManager
            , IVinService vinService, IVinOwnershipService vinOwnershipService)
        {
            _logger = logger;
            _dataService = dataService;
            _userManager = userManager;
            _vinService = vinService;
            _vinOwnershipService = vinOwnershipService;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
             userId = _userManager.GetUserId(User); // get user Id
            user = await _userManager.GetUserAsync(User); // get user's all data
            if (user == null)
            {
                return View();
            }
            return RedirectToAction("GetVins", "Home");
        }
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([Bind("Vin,Plate")] IndexViewModel vpevm)
        {
            if (vpevm.Vin is not null)
            {
                if (await _vinService.IsVinRegulated(vpevm.Vin))
                {
                    ModelState.AddModelError(String.Empty, "VIN is regulated.  Please register or log in to apply for certification.");
                }
                else
                {
                    ModelState.AddModelError("Vin", "VIN is not regulated.");
                }
            } else
            {
                if (await _vinService.IsPlateRegulated(vpevm.Plate))
                {
                    ModelState.AddModelError(String.Empty, "Plate is regulated.  Please register or log in to apply for certification.");
                }
                else
                {
                    ModelState.AddModelError("Plate", "Plate  is not regulated.");
                }
            }
            return View(vpevm);
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetVins()
        {
            userId = _userManager.GetUserId(User); // get user Id
            //user = await _userManager.GetUserAsync(User); // get user's all data
            //var result = _dataService.GetVins(userId);
            //var x = await _vinOwnershipService.GetSecondaryOwners("aaf7efd0-ae13-48e9-9d72-83e713ef8100");
            //return View("GetVins", result); 
            var result = await _vinService.GetVinsByOwnerIdAsync(userId);
            return View(result);
        }
        [Authorize]
        [HttpGet]
        public IActionResult ClaimAVin()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}