using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Logging;
using server.Data;
using server.DTO;
using server.Models;

namespace server.Controllers {
    [Route("api/[controller]/{id?}")]
    [ApiController]
    public class MotionPicturesController : ControllerBase {

        private readonly ILogger<MotionPicturesController> _log;
        private readonly MotionPictureDbContext _context;

        public class MotionPictureDTO {
            public string Name { get; set; }
            public string? Description { get; set; }
            public int ReleaseYear { get; set; }
        }

        public MotionPicturesController(ILogger<MotionPicturesController> log, MotionPictureDbContext context) {
            this._log = log;
            this._context = context;

        }

        [HttpGet]
        public async Task<IActionResult> Get(int? id) {
            Response response = new Response {
                Status = "failure",
            };
            try {
                Payload payload = new Payload();
                IOrderedQueryable<MotionPicture> allMotionPictures =
                _context.MotionPictures.OrderBy(motionPicture => motionPicture.ID);

                if (id is null) {
                    response.Status = "success";
                    payload.MotionPictures = await allMotionPictures.ToListAsync();
                    response.Payload = payload;
                    return Ok(response);
                }
                
                MotionPicture result = await allMotionPictures.FirstOrDefaultAsync(motionPicture => motionPicture.ID == id);

                if (result is null) {
                    response.Message = $"Motion Picture with ID {id} not found.";
                    return NotFound(response);
                }

                response.Status = "success";
                payload.MotionPicture = result;
                response.Payload = payload;
                return Ok(response);

            } catch (Exception exception) {
                _log.LogError($"{exception}");
                return BadRequest(response);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, MotionPicture motionPicture) {
            Response response = new Response {
                Status = "failure",
            };
            Payload payload = new Payload();
            if (id != motionPicture.ID) {
                response.Message = "The ID given on the payload does not match the resource ID.";
                return BadRequest(response);
            }

            _context.Entry(motionPicture).State = EntityState.Modified;

            try {
                await _context.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException) {
                MotionPicture result = await _context.MotionPictures.FirstOrDefaultAsync(x => x.ID == id);
                if (result == null) {
                    response.Message = $"Motion Picture with ID {id} not found";
                    return NotFound(response);
                }
                else {
                    throw;
                }
            }
            return AcceptedAtAction(nameof(Get), new { id = motionPicture.ID }, motionPicture);
        }

        [HttpPost]
        public async Task<IActionResult> Post(MotionPictureDTO motionPictureDTO) {

            MotionPicture motionPicture = new MotionPicture {
                Name = motionPictureDTO.Name,
                Description = motionPictureDTO.Description,
                ReleaseYear = motionPictureDTO.ReleaseYear
            };

            await _context.MotionPictures.AddAsync(motionPicture);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = motionPicture.ID }, motionPicture);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id) {
            Response response = new Response {
                Status = "failure",
            };
            try {
                MotionPicture motionPicture =
                    await _context.MotionPictures.FirstOrDefaultAsync(motionPicture => motionPicture.ID == id);

                if (motionPicture is null) {
                    response.Message = $"Motion Picture with ID {id} not found";
                    return NotFound(response);
                }
                
                _context.Remove(motionPicture);
                await _context.SaveChangesAsync();

                return NoContent();

            } catch (Exception exception) {
                _log.LogError($"{exception}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting data from the database.");
            }
        }

    }
}
