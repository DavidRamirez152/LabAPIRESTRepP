using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationCompanies.Models;
using Newtonsoft.Json;

namespace WebApplicationemployees.Controllers
{
    public class EmployeesController : Controller
    {

        static HttpClient client = new HttpClient();


        // GET: employeesController
        public ActionResult Index()
        {

            IEnumerable<EmployeeViewModel> employees = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7284/api/employees");
                //HTTP GET
                var responseTask = client.GetAsync("employees");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var contentTask = result.Content.ReadAsStringAsync();
                    contentTask.Wait();
                    var json = contentTask.Result;
                    employees = JsonConvert.DeserializeObject<List<EmployeeViewModel>>(json); ;
                }
                else //web api sent error response 
                {
                    //log response status here..

                    employees = Enumerable.Empty<EmployeeViewModel>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return View(employees);            
        }

        // GET: employeesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: employeesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: employeesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: employeesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: employeesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: employeesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: employeesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
