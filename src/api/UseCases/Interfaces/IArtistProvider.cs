using System.Collections.Generic;
using System.Threading.Tasks;
using UseCases.BusinessObjects;
using UseCases.Dto;
using UseCases.Enums;

namespace UseCases.Interfaces
{
    public interface IArtistProvider
    {
        Task<ProviderResult<IEnumerable<Artist>>> GetTopArtists(string userId, TimeRange timeRange);
    }
}
