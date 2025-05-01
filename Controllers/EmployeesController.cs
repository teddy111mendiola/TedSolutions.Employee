using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TedSolutions.Employee.Data;
using TedSolutions.Employee.Models.Entities;

namespace TedSolutions.Employee.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly AppDbContext _dbContext;
        public EmployeesController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        //get all employee in the database
        public IActionResult List()
        {
            var employees = _dbContext.Employees.ToList();
            return View(employees);
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}
        public IActionResult Create()
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
            var old_staff = _dbContext.Employees.FirstOrDefault(e => e.Id == employee.Id);
            //update with new staff information
            _dbContext.Entry(old_staff).CurrentValues.SetValues(employee);
            _dbContext.SaveChanges();
            return RedirectToAction("List");
        }
        public IActionResult Delete(int Id)
        {
            //get the emplouee with the Id
            var employee = _dbContext.Employees.FirstOrDefault(e => e.Id == Id);
            //remove the staff from the database
            _dbContext.Employees.Remove(employee);
            _dbContext.SaveChanges();
            return RedirectToAction("List");
        }
        public IActionResult Post(Models.Entities.Employee employee)
        {
            //add staff to the context
            _dbContext.Employees.Add(employee);
            _dbContext.SaveChanges();
            return RedirectToAction("List");
        }
    }
}
