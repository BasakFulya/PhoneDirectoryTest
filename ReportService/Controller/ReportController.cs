using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReportService.Entities;

namespace ReportService.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly ReportDbContext _context;

        public ReportController(ReportDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Report>>> GetReports()
        {
            return await _context.Reports.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Report>> GetReport(Guid id)
        {
            var report = await _context.Reports.FindAsync(id);

            if (report == null)
            {
                return NotFound();
            }

            return report;
        }

        [HttpPost]
        public async Task<ActionResult<Report>> RequestReport([FromBody] string location)
        {
            var report = new Report
            {
                Id = Guid.NewGuid(),
                RequestedDate = DateTime.UtcNow,
                Status = ReportStatus.InProgress,
                Location = location
            };

            _context.Reports.Add(report);
            await _context.SaveChangesAsync();

            // TODO: Send message to Kafka to start report generation

            return CreatedAtAction(nameof(GetReport), new { id = report.Id }, report);
        }
    }
}
