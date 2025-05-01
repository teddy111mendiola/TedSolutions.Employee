using Microsoft.AspNetCore.Mvc;
using TedSolutions.Employee.Data;

namespace TedSolutions.Employee.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly AppDbContext _dbContext;
        public EmployeesController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult List()
        {
            var employees = _dbContext.Employees.ToList();
            return View(employees);
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult AboutMe()
        {
            return View();
        }

        
        public IActionResult Edit(int Id)
        {
            var employee = _dbContext.Employees.FirstOrDefault(e => e.Id == Id);
            return View(employee);
        }
        public IActionResult Update(Models.Entities.Employee employee)
        {
            //get the existing staff
            var oldEmployee = _dbContext.Employees.FirstOrDefault(e => e.Id == employee.Id);
            //update with new employee information
            _dbContext.Entry(oldEmployee).CurrentValues.SetValues(employee);
            _dbContext.SaveChanges();
            return RedirectToAction("List");
        }
        public IActionResult Delete(int Id)
        {
            //get the employee with the Id
            var employee = _dbContext.Employees.FirstOrDefault(e => e.Id == Id);
            //remove the employee from the database
            _dbContext.Employees.Remove(employee);
            _dbContext.SaveChanges();
            return RedirectToAction("List");
        }
        public IActionResult Post(Models.Entities.Employee employee)
        {
            //add employee to the context
            _dbContext.Employees.Add(employee);
            _dbContext.SaveChanges();
            return RedirectToAction("List");
        }
    }
}
