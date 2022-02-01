using EmployeeDirectory.Services.Interfaces;
using EmployeeDirectory.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeDirectory.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        [Authorize(Policy = "readonlypolicy")]
        public async Task<IActionResult> Index()
        {
            return View(await _departmentService.GetAllAsync());
        }

        [Authorize(Policy = "writeonlypolicy")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var dept = await _departmentService.GetByIdAsync(id.GetValueOrDefault());
            if (dept == null)
            {
                return NotFound();
            }

            return View(dept);
        }

        [Authorize(Policy = "writeonlypolicy")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Policy = "writeonlypolicy")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DepartmentViewModel dept)
        {
            if (ModelState.IsValid)
            {
                await _departmentService.AddAsync(dept);
                return RedirectToAction(nameof(Index));
            }
            return View(dept);
        }

        [Authorize(Policy = "writeonlypolicy")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dept = await _departmentService.GetByIdAsync(id.GetValueOrDefault());
            if (dept == null)
            {
                return NotFound();
            }
            return View(dept);
        }

        [Authorize(Policy = "writeonlypolicy")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DepartmentViewModel dept)
        {
            if (id != dept.DepartmentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _departmentService.UpdateAsync(dept);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await _departmentService.GetByIdAsync(dept.DepartmentID) == null)
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
            return View(dept);
        }

        [Authorize(Policy = "writeonlypolicy")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dept = await _departmentService.GetByIdAsync(id.GetValueOrDefault());
            if (dept == null)
            {
                return NotFound();
            }

            return View(dept);
        }

        [Authorize(Policy = "writeonlypolicy")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _departmentService.RemoveAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
