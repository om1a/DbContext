using DataBaseTask.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DataBaseTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly DataContext _context;

        public CompanyController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Company>>> Get()
        {
            return Ok(await _context.Companys.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Company>> Get(int id)
        {
            var comp = await _context.Companys.FindAsync(id);
            if (comp == null)
                return BadRequest("Company not found.");
            return Ok(comp);
        }

        [HttpPost]
        public async Task<ActionResult<List<Company>>> Addcomp(Company comp)
        {
            _context.Companys.Add(comp);
            _context.SaveChanges();

            return Ok(await _context.Companys.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Company>>> Updatecomp(Company request)
        {
            var dbCompany = _context.Companys.Find(request.Id);
            if (dbCompany == null)
                return BadRequest("Company not found.");

            dbCompany.Name = request.Name;
            dbCompany.Id = request.Id;
            dbCompany.Location = request.Location;

            _context.SaveChanges();

            return Ok(_context.Companys.ToList());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Company>>> Delete(int id)
        {
            var dbcomp = _context.Companys.Find(id);
            if (dbcomp == null)
                return BadRequest("Company not found.");

            _context.Companys.Remove(dbcomp);
            _context.SaveChanges();

            return Ok(_context.Companys.ToList());
        }

    }
}
