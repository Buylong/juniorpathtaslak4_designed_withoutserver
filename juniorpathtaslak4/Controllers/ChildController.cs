using juniorpathtaslak4.Models;
using juniorpathtaslak4.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace juniorpathtaslak4.Controllers
{
    public class ChildController : Controller
    {
        private readonly ChildRepository _repository;

        public ChildController()
        {
            _repository = new ChildRepository();
        }

        public IActionResult Index()
        {
            var children = _repository.GetAll();
            return View(children);
        }

        public IActionResult Details(int id)
        {
            var child = _repository.GetById(id);
            if (child == null)
            {
                return NotFound();
            }
            return View(child);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Child child)
        {
            if (ModelState.IsValid)
            {
                _repository.Add(child);
                return RedirectToAction(nameof(Index));
            }
            return View(child);
        }

        public IActionResult Edit(int id)
        {
            var child = _repository.GetById(id);
            if (child == null)
            {
                return NotFound();
            }
            return View(child);
        }

        [HttpPost]
        public IActionResult Edit(Child child)
        {
            if (ModelState.IsValid)
            {
                _repository.Update(child);
                return RedirectToAction(nameof(Index));
            }
            return View(child);
        }

        public IActionResult Delete(int id)
        {
            var child = _repository.GetById(id);
            if (child == null)
            {
                return NotFound();
            }
            return View(child);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _repository.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult AddDailyActivity(int childId)
        {
            var child = _repository.GetById(childId);
            if (child == null)
            {
                return NotFound();
            }
            ViewBag.ChildId = childId;
            return View(new DailyActivity { Date = DateTime.Today });
        }

        [HttpPost]
        public IActionResult AddDailyActivity(int childId, DailyActivity activity)
        {
            if (ModelState.IsValid)
            {
                _repository.AddDailyActivity(childId, activity);
                return RedirectToAction(nameof(Details), new { id = childId });
            }
            ViewBag.ChildId = childId;
            return View(activity);
        }
    }
}
