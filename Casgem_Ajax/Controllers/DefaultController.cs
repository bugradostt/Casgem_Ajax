using Casgem_Ajax.DAL;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Casgem_Ajax.Controllers
{
	public class DefaultController : Controller
	{
		Context c = new Context();
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult ListCustomer()
		{
			var jsonCustomer = JsonConvert.SerializeObject(c.Customers.ToList());
			return Json(jsonCustomer);
		}

		[HttpPost]
		public IActionResult AddCustomer(Customer p)
		{
			c.Customers.Add(p);
			c.SaveChanges();
			var values = JsonConvert.SerializeObject(p);
			return Json(values);
		}

		public IActionResult DeleteCustomer(int id)
		{
			var foundId = c.Customers.Find(id);

			c.Customers.Remove(foundId);
			c.SaveChanges();
			return NoContent();
		}

        public IActionResult GetByIdCustomer(int CustomerId)
        {
            var foundId = c.Customers.Find(CustomerId);
            var values = JsonConvert.SerializeObject(foundId);
            return Json(values);
        }


		[HttpPost]
        public IActionResult EditCustomer(Customer p)
        {
			c.Customers.Update(p);
			c.SaveChanges();
            return NoContent();
        }
    }
}
