using gevs_api.Domain;
using gevs_api.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;

namespace gevs_api.Controller
{
    [ApiController]
    [Route("/[controller]")]
    public class GevsController : ControllerBase
    {
        private readonly ICandidateRepository _candidateRepository;
        private readonly IPartyRepository _partyRepository;
        private readonly IConstituencyRepository _constituencyRepository;
        private readonly ILogger<GevsController> _logger;
        private readonly IElectionResultRepository _electionResultsRepository;
        private readonly IElectionRepository _electionRepository;
        private readonly IVoteHistoryRepository _voteHistoryRepository;

        // GET endpoints for candidate
        public GevsController(ICandidateRepository candidateRepository,
            ILogger<GevsController> logger,
            IPartyRepository partyRepository,
            IConstituencyRepository constituencyRepository,
            IElectionResultRepository electionResultsRepository,
            IElectionRepository electionRepository,
            IVoteHistoryRepository voteHistoryRepository)
        {
            _candidateRepository = candidateRepository;
            _logger = logger;
            _partyRepository = partyRepository;
            _constituencyRepository = constituencyRepository;
            _electionResultsRepository = electionResultsRepository;
            _electionRepository = electionRepository;
            _voteHistoryRepository = voteHistoryRepository;
        }

        [Authorize]
        [HttpGet("candidate", Name = "GetCandidate")]
        [ProducesResponseType(typeof(Candidate), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Candidate>> GetCandidates()
        {
            _logger.LogInformation("Fetching all candidates");
            return Ok(await _candidateRepository.GetCandidates());
        }

        [Authorize]
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
        [Authorize]
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
        [Authorize]
        [HttpPut("vote/candidate/{id}")]
        [ProducesResponseType(typeof(Candidate), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Candidate>> AddVoteToCandidate(string id)
        {
            if (User.Identity is not ClaimsIdentity identity)
            {
                return Forbid();
            }

            var nameId = identity.FindFirst(ClaimTypes.NameIdentifier);

            if (nameId == null)
            {
                return BadRequest("Invalid User Id");
            }

            var role = identity.FindFirst(ClaimTypes.Role);

            if (role == null)
            {
                return BadRequest("The user has no role");
            }

            if (role.Value != "voter")
            {
                return BadRequest("Only voters can vote in an election");
            }

            var voteCheck = await _voteHistoryRepository.CheckVoteHistory(new Guid(nameId.Value));

            if (voteCheck)
            {
                return BadRequest("You have already voted in this election");
            }

            var candidate = await _candidateRepository.GetCandidateById(new Guid(id));

            if (candidate == null)
            {
                return NotFound("The candidate with that ID does not exist");
            }

            var result = await _candidateRepository.AddVoteToCandidate(candidate.Id);

            if (result)
            {
                await _voteHistoryRepository.AddVoteHistory(new Guid(nameId.Value));
                return Ok();
            }

            return NotFound();
        }

        // results endpoint
        [HttpGet("results")]
        [ProducesResponseType(typeof(ElectionResult), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<ElectionResult>> GetElectionResult()
        {
            return Ok(await _electionResultsRepository.GetElectionResults());
        }

        // election management
        [HttpGet("election/status")]
        [ProducesResponseType(typeof(Election), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Election>> GetElectionStatus()
        {
            return Ok(await _electionRepository.GetElection());
        }

        [Authorize]
        [HttpPut("admin/election/{status:bool}")]
        [ProducesResponseType(typeof(Election), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Election>> UpdateElectionStatus(bool status)
        {
            if (User.Identity is not ClaimsIdentity identity)
            {
                return Forbid();
            }

            var role = identity.FindFirst(ClaimTypes.Role);

            if (role == null)
            {
                return BadRequest("The user has no role");
            }

            if (role.Value != "admin")
            {
                return Forbid();
            }

            return Ok(await _electionRepository.UpdateElectionStatus(status));
        }

        [Authorize]
        [HttpDelete("admin/delete")]
        public async Task<ActionResult<bool>> DeleteElectionVoteHistory()
        {
            if (User.Identity is not ClaimsIdentity identity)
            {
                return Forbid();
            }

            var role = identity.FindFirst(ClaimTypes.Role);

            if (role == null)
            {
                return BadRequest("The user has no role");
            }

            if (role.Value != "admin")
            {
                return Forbid();
            }

            return Ok(await _voteHistoryRepository.DeleteVoteHistory());
        }
    }
}
