using MVCProject.Models;

using Microsoft.AspNetCore.Mvc;

namespace MVCProject.Controllers
{
    public class ReservationController : Controller
    {
        private IData _tempdata;

        public ReservationController(IData tempData)
        {
            _tempdata = tempData;
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
        public IActionResult Index()
        {
            IndexViewModel model = new IndexViewModel();
            model.Reservations = _tempdata.InitializeData();
            return View(model);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Reservation obj)
        {
            if(ModelState.IsValid)
            {
                _tempdata.AddReservation(obj);
            }
            return View();
        }
        public IActionResult Delete(int id)
        {
            _tempdata.DeleteReservation(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            Reservation obj = _tempdata.GetReservation(id);
            return View(obj);
        }
        [HttpPost]
        public IActionResult Update(Reservation obj, int id)
        {
            obj.Id = id;
            _tempdata.UpdateReservation(obj);
            return RedirectToAction("Index");
        }
    }
}
