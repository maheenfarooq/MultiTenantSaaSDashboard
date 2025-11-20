using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MultiTenant.API.Data;

namespace MultiTenant.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly AppDbContext _db;
        public EmployeeController(AppDbContext db) => _db = db;

        [HttpGet]
        public async Task<IActionResult> GetEmployees() => Ok(await _db.Employees.ToListAsync());
    }
}
