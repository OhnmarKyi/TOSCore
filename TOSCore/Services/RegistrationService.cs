using Microsoft.EntityFrameworkCore;
using TOSCore.Context;

namespace TOSCore.Services
{
    public class RegistrationService
    {
        TOSContext _context = new TOSContext();
        public async Task<List<MBrand>> GetBrand()
        {
            List<MBrand> brandList = await _context.MBrands.ToListAsync();
            return brandList;
        }
    }
}
