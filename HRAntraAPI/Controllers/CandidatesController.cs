using ApplicationCore.Contract.Services;
using ApplicationCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRAntraAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatesController : ControllerBase
    {
        private readonly ICandidatesService candidatesService;
        public CandidatesController(ICandidatesService candidatesService)
        {
            this.candidatesService = candidatesService; 
        }

        [HttpGet]
        [Route("GetAllCandidates")]
        public async Task<IActionResult> Get()
        {
            return Ok(await candidatesService.GetAllCandidates());
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var candidates = await candidatesService.GetCandidateByIdAsync(id);
            if (candidates == null)
            {
                return NotFound($"Candidate object with Id = {id} is not available");
            }
            return Ok(candidates);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CandidatesRequestModel model)
        {
            var result = await candidatesService.AddCandidateAsync(model);
            if (result != 0)
            {
                return Ok(model);
            }
            return BadRequest();
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await candidatesService.DeleteCandidateAsync(id);
            if (result != 0)
            {
                return Ok("Baby Deleted Successfully");
            }
            return BadRequest();
        }

    }
}
