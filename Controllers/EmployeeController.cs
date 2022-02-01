using EmployeeDirectory.DbContext;
using EmployeeDirectory.Models;
using EmployeeDirectory.Repositories.Interfaces;
using EmployeeDirectory.Services.Interfaces;
using EmployeeDirectory.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EmployeeDirectory.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeController(IEmployeeService employeeService,
                                  IEmployeeRepository employeeRepository)
        {
            _employeeService = employeeService;
            _employeeRepository = employeeRepository;
            
        }
        [Authorize(Policy = "readonlypolicy")]
        public async Task<IActionResult> Index()
        {
            return View(await _employeeService.GetAllAsync());
        }

        [Authorize(Policy = "writeonlypolicy")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //ViewBag.DepartmentName = new SelectList(GetDepartmentDetail(), "DepartmentID", "DepartmentName");
            //ViewBag.Department = new SelectList(_context.Departments.ToList(), "DepartmentID", "DepartmentName");
            var emp = await _employeeService.GetByIdAsync(id.GetValueOrDefault());
            if (emp == null)
            {
                return NotFound();
            }

            return View(emp);
        }

        [Authorize(Policy = "writeonlypolicy")]
        public IActionResult Create()
        {
            ViewBag.DepartmentName = new SelectList(GetDepartmentDetail(), "DepartmentID", "DepartmentName");
            //ViewBag.Department = new SelectList(_context.Departments.ToList(), "DepartmentID", "DepartmentName");
            return View();
        }

        [Authorize(Policy = "writeonlypolicy")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployeeViewModel emp)
        {
            if (ModelState.IsValid)
            {
                await _employeeService.AddAsync(emp);
                ViewBag.DepartmentName = new SelectList(GetDepartmentDetail(), "DepartmentID", "DepartmentName");
                //ViewBag.Department = new SelectList(_context.Departments.ToList(), "DepartmentID", "DepartmentName");
                return RedirectToAction(nameof(Index));
            }
            return View(emp);
        }

        [Authorize(Policy = "writeonlypolicy")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.DepartmentName = new SelectList(GetDepartmentDetail(), "DepartmentID", "DepartmentName");
            //ViewBag.Department = new SelectList(_context.Departments.ToList(), "DepartmentID", "DepartmentName");
            var emp = await _employeeService.GetByIdAsync(id.GetValueOrDefault());
            if (emp == null)
            {
                return NotFound();
            }
            return View(emp);
        }

        [Authorize(Policy = "writeonlypolicy")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EmployeeViewModel emp)
        {
            if (id != emp.EmployeeID)
            {
                return NotFound();
            }
            ViewBag.DepartmentName = new SelectList(GetDepartmentDetail(), "DepartmentID", "DepartmentName");
            //ViewBag.Department = new SelectList(_context.Departments.ToList(), "DepartmentID", "DepartmentName");
            if (ModelState.IsValid)
            {
                try
                {
                    await _employeeService.UpdateAsync(emp);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await _employeeService.GetByIdAsync(emp.EmployeeID) == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(emp);
        }

        [Authorize(Policy = "writeonlypolicy")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //ViewBag.Department = new SelectList(_context.Departments.ToList(), "DepartmentID", "DepartmentName");
            var emp = await _employeeService.GetByIdAsync(id.GetValueOrDefault());
            if (emp == null)
            {
                return NotFound();
            }

            return View(emp);
        }

        [Authorize(Policy = "writeonlypolicy")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //ViewBag.Department = new SelectList(_context.Departments.ToList(), "DepartmentID", "DepartmentName");
            await _employeeService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }
        public List<Department> GetDepartmentDetail()
        {
            List<Department> departmentNames = _employeeRepository.GetAllDepartments().ToList();
            return departmentNames;
        }
    }
}
