using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.DbContexts;
using WebAPI.Entities;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadedFilesController : ControllerBase
    {
        private readonly WebbsakerhetDbContext _context;

        public UploadedFilesController(WebbsakerhetDbContext context)
        {
            _context = context;
        }

        // GET: api/UploadedFiles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UploadedFile>>> GetUploadedFiles()
        {
            return await _context.UploadedFiles.ToListAsync();
        }

        // GET: api/UploadedFiles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UploadedFile>> GetUploadedFile(int id)
        {
            var uploadedFile = await _context.UploadedFiles.FindAsync(id);

            if (uploadedFile == null)
            {
                return NotFound();
            }

            return uploadedFile;
        }

        // PUT: api/UploadedFiles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUploadedFile(int id, UploadedFile uploadedFile)
        {
            if (id != uploadedFile.Id)
            {
                return BadRequest();
            }

            _context.Entry(uploadedFile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UploadedFileExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/UploadedFiles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UploadedFile>> PostUploadedFile(UploadedFile uploadedFile)
        {
            _context.UploadedFiles.Add(uploadedFile);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUploadedFile", new { id = uploadedFile.Id }, uploadedFile);
        }

        // DELETE: api/UploadedFiles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUploadedFile(int id)
        {
            var uploadedFile = await _context.UploadedFiles.FindAsync(id);
            if (uploadedFile == null)
            {
                return NotFound();
            }

            _context.UploadedFiles.Remove(uploadedFile);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UploadedFileExists(int id)
        {
            return _context.UploadedFiles.Any(e => e.Id == id);
        }
    }
}
