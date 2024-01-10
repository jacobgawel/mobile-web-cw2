using System.Net;
using gevs_api.Domain;
using gevs_api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace gevs_api.Controller;

[ApiController]
[Route("/[controller]")]
public class GevsController : ControllerBase
{
    private readonly ICandidateRepository _candidateRepository;
    private readonly ILogger<GevsController> _logger;

    public GevsController(ICandidateRepository candidateRepository, ILogger<GevsController> logger)
    {
        _candidateRepository = candidateRepository;
        _logger = logger;
    }

    [HttpGet]
    [ProducesResponseType(typeof(Candidate), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<Candidate>> GetCandidates()
    {
        _logger.LogInformation("Fetching all candidates");
        return Ok(await _candidateRepository.GetCandidates());
    }
    
    
}