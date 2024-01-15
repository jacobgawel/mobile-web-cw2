using Microsoft.EntityFrameworkCore;

namespace gevs_api.Domain
{
    public class CandidateResult
    {
        public string Name { get; set; }
        public string Party { get; set; }
        public int Vote { get; set; }
    }
}
