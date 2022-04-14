using DesignProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace DesignProject.Controllers
{
    public class PersonsController : Controller
    {
        DatabaseContext _context;
        public PersonsController(DatabaseContext context)
        {
            _context = context;
        }
        public IActionResult ListStudent()
        {
            return View(_context.Students.ToList());
        }
        public IActionResult ListEmployee()
        {
            return View(_context.Employees.ToList());
        }


        [HttpGet]
        public IActionResult CreateStudent(int ID)
        {
            var selectedRow = _context.Students.Where(id => id.ID == ID).SingleOrDefault();
            return View(selectedRow);
        }
        [HttpPost]
        public async Task<IActionResult> CreateStudent(Student obj)
        {
            if (obj.ID == 0)
            {
                await _context.Students.AddAsync(obj);
                _context.SaveChanges();
                return RedirectToAction("ListStudent");
            }
            else
            {
                var selectedRow = (from p in _context.Students where p.ID == obj.ID select p);
                foreach (var UpdateSelectedRow in selectedRow)
                {
                    UpdateSelectedRow.RegistrationDate = obj.RegistrationDate;
                    UpdateSelectedRow.dateofBirth = obj.dateofBirth;
                    UpdateSelectedRow.FullName = obj.FullName;
                    UpdateSelectedRow.Email = obj.Email;
                    UpdateSelectedRow.Gender = obj.Gender;
                    UpdateSelectedRow.CourseName = obj.CourseName;
                    UpdateSelectedRow.Phone = obj.Phone;
                    UpdateSelectedRow.Mobile = obj.Mobile;
                    UpdateSelectedRow.Notes = obj.Notes;
                }
                _context.SaveChanges();
                return RedirectToAction("ListStudent");
            }
        }
        [HttpGet]
        public IActionResult CreateEmployee(int ID)
        {
            var selectedRow = _context.Employees.Where(id => id.ID == ID).SingleOrDefault();
            return View(selectedRow);
        }
        [HttpPost]
        public async Task<IActionResult> CreateEmployee(Employee obj)
        {
            if (obj.ID == 0)
            {
                await _context.Employees.AddAsync(obj);
                _context.SaveChanges();
                return RedirectToAction("ListEmployee");
            }
            else
            {
                var selectedRow = (from p in _context.Employees where p.ID == obj.ID select p);
                foreach (var UpdateSelectedRow in selectedRow)
                {
                    UpdateSelectedRow.JobTitle = obj.JobTitle;
                    UpdateSelectedRow.dateofBirth = obj.dateofBirth;
                    UpdateSelectedRow.FullName = obj.FullName;
                    UpdateSelectedRow.Email = obj.Email;
                    UpdateSelectedRow.Gender = obj.Gender;
                    UpdateSelectedRow.startingDate = obj.startingDate;
                    UpdateSelectedRow.Phone = obj.Phone;
                    UpdateSelectedRow.Mobile = obj.Mobile;
                    UpdateSelectedRow.Notes = obj.Notes;
                }
                _context.SaveChanges();
                return RedirectToAction("ListEmployee");
            }
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int ID)
        {
            var selectedRow = _context.Students.Where(id => id.ID == ID).SingleOrDefault();
            _context.Remove(selectedRow);
            _context.SaveChanges();
            return RedirectToAction("ListStudent");
        } 
        [HttpGet]
        public async Task<IActionResult> DeleteEmployee(int ID)
        {
            var selectedRow = _context.Employees.Where(id => id.ID == ID).SingleOrDefault();
            _context.Remove(selectedRow);
            _context.SaveChanges();
            return RedirectToAction("ListEmployee");
        }
    }
}
