using System;
using MVCProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using MVCProject.ViewModels;

using Microsoft.AspNetCore.Mvc;

namespace MVCProject.Controllers
{
    public class ReservationController : Controller
    {
        private readonly UserManager<User> _userManager;

        private IData _tempdata;

        public ReservationController(IData tempData, UserManager<User> userManager)
        {
            _tempdata = tempData;
            _userManager = userManager;
        }

        public IActionResult Details(int? id)
        {
            var model = _tempdata.GetReservation(id);
            if(model==null)
            {
                return NotFound();
            }
            return View(model);
        }
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"User cannot be found";
                return View("NotFound");
            }


            ViewBag.userEmail = user.Email;//user.

            IndexViewModel model = new IndexViewModel(); //check if admin, if not =="user email"

            model.Reservations = _tempdata.InitializeData();



            return View(model);
        }
        [Authorize(Roles = "Customer")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Customer")]
        public IActionResult Create(Reservation obj)
        {
            if(ModelState.IsValid)
            {
                _tempdata.AddReservation(obj);
            }
            return View();
        }
        [Authorize(Roles = "Customer")]
        public IActionResult Delete(int id)
        {
            _tempdata.DeleteReservation(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Update(int id)
        {
            Reservation obj = _tempdata.GetReservation(id);
            return View(obj);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Update(Reservation obj, int id)
        {
            obj.Id = id;
            _tempdata.UpdateReservation(obj);
            return RedirectToAction("Index");
        }
    }
}
