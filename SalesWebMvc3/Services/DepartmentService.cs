using Microsoft.EntityFrameworkCore;
using SalesWebMvc3.Data;
using SalesWebMvc3.Models;

namespace SalesWebMvc3.Services
{
    public class DepartmentService
    {
        private readonly SalesWebMvc3Context _context;

        public DepartmentService(SalesWebMvc3Context context)
        {
            _context = context;
        }

        public async Task<List<Department>> FindAllAsync()
        {
            return await _context.Department.OrderBy(x => x.Name).ToListAsync();
        }
    }
}
