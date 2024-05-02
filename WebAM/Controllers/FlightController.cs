using AM.ApplicationCore.domain;
using AM.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebAM.Controllers
{
    public class FlightController : Controller
    {
        IFlightMethods FlightMethods;
        IServicePlane ServicePlane;

        public FlightController(IFlightMethods flightMethods, IServicePlane servicePlane)
        {
            FlightMethods = flightMethods;
            ServicePlane = servicePlane;
        }


        // GET: FlightController
        public ActionResult Index(DateTime? dateDepart)
        {
            if (dateDepart == null)
            {
                return View(FlightMethods.GetAll().ToList());
            }
            else
                return View(FlightMethods.GetMany(f=> f.FlightDate.Date.Equals(dateDepart)).ToList());
        }

        // GET: FlightController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FlightController/Create
        public ActionResult Create()
        {
            ViewBag.PlaneList = new SelectList(ServicePlane.GetAll(), "PlaneId", "Capacity");
            return View();
        }

        // POST: FlightController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Flight flight, IFormFile PilotImage)
        {
            try
            {
                if(PilotImage!=null)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads",
PilotImage.FileName);
                    Stream stream = new FileStream(path, FileMode.Create);
                    PilotImage.CopyTo(stream);
                    flight.Pilot = PilotImage.FileName;
                }
                FlightMethods.Add(flight);
                FlightMethods.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FlightController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(FlightMethods.GetById(id));
        }

        // POST: FlightController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Flight flight, int id)
        {
            try
            {
                //Flight flight = FlightMethods.GetById(id);
                FlightMethods.Update(flight);
                FlightMethods.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FlightController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(FlightMethods.GetById(id));
        }

        // POST: FlightController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            Flight flight = FlightMethods.GetById(id);
            try
            {
                FlightMethods.Delete(flight);

                FlightMethods.Commit();


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Sort()
        {
            return View("Index", FlightMethods.SortFlights());
        }

    }
}
