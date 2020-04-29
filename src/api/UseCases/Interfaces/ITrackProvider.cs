using System.Collections.Generic;
using System.Threading.Tasks;
using UseCases.BusinessObjects;
using UseCases.Dto;
using UseCases.Enums;

namespace UseCases.Interfaces
{
    public interface ITrackProvider
    {
        Task<ProviderResult<IEnumerable<Track>>> GetTopTracks(string userId, TimeRange timeRange);
    }
}
