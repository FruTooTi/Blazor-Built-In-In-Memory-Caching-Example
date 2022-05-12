using CachingExample.Data;

namespace CachingExample.Services
{
    public interface IPersonalIDRepository
    {
        List<PersonalID> getPersonalId();
        Task<List<PersonalID>> getPersonalIdAsync();

        Task<List<PersonalID>> getPersonalIdCached();
    }
}