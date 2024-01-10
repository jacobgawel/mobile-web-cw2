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
    private readonly IPartyRepository _partyRepository;
    private readonly IConstituencyRepository _constituencyRepository;
    private readonly ILogger<GevsController> _logger;
    private readonly IElectionResultsRepository _electionResultsRepository;
    
    // GET endpoints for candidate
    public GevsController(ICandidateRepository candidateRepository, 
        ILogger<GevsController> logger, 
        IPartyRepository partyRepository, 
        IConstituencyRepository constituencyRepository, 
        IElectionResultsRepository electionResultsRepository)
    {
        _candidateRepository = candidateRepository;
        _logger = logger;
        _partyRepository = partyRepository;
        _constituencyRepository = constituencyRepository;
        _electionResultsRepository = electionResultsRepository;
    }

    [HttpGet("candidate", Name = "GetCandidate")]
    [ProducesResponseType(typeof(Candidate), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<Candidate>> GetCandidates()
    {
        _logger.LogInformation("Fetching all candidates");
        return Ok(await _candidateRepository.GetCandidates());
    }
    
    [HttpGet("candidate/{id}")]
    [ProducesResponseType(typeof(Candidate), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<Candidate>> GetCandidateById(string id)
    {
        Guid candidateId = new Guid(id);

        return Ok(await _candidateRepository.GetCandidateById(candidateId));
    }
    
    // Example Request: http://localhost:8000/gevs/constituency/northern-kunlun-mountain
    [HttpGet("constituency/{constituency}")]
    [ProducesResponseType(typeof(ConstituencyResult), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<ConstituencyResult>> GetConstituencyResult(string constituency)
    {
        var candidates = await _candidateRepository.GetCandidatesByConstituency(constituency);

        if (candidates == null)
        {
            return NotFound();
        }
        
        var constituencyResults = await _candidateRepository.GetConstituencyResults(candidates, constituency);

        return Ok(constituencyResults);
    }
    
    // POST endpoint for candidate
    [HttpPost("candidate")]
    [ProducesResponseType(typeof(Candidate), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<Candidate>> CreateCandidate(Candidate candidate)
    {
        if (await _partyRepository.GetPartyById(candidate.PartyId) == null)
        {
            return NotFound("The PartyId provided is invalid");
        }

        if (await _constituencyRepository.GetConstituencyById(candidate.ConstituencyId) == null)
        {
            return NotFound("The ConstituencyId provided is invalid");
        }
        
        var candidateId = await _candidateRepository.CreateCandidate(candidate);
        candidate.Id = candidateId;

        return CreatedAtRoute("GetCandidate", new { id = candidateId }, candidate);
    }
    
    // Vote endpoint for candidate
    [HttpGet("vote/candidate/{id}")]
    [ProducesResponseType(typeof(Candidate), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<Candidate>> AddVoteToCandidate(string id)
    {
        var candidate = await _candidateRepository.GetCandidateById(new Guid(id));
        
        if (candidate == null)
        {
            return NotFound("The candidate with that ID does not exist");
        }

        var result = await _candidateRepository.AddVoteToCandidate(candidate.Id);
        
        if (result)
            return Ok();

        return NotFound();
    }
    
    // results endpoint
    [HttpGet("results")]
    [ProducesResponseType(typeof(ElectionResult), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<ElectionResult>> GetElectionResult()
    {
        return Ok(await _electionResultsRepository.GetElectionResults());
    }
}