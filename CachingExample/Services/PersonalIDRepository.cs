using CachingExample.Data;
using Microsoft.Extensions.Caching.Memory;

namespace CachingExample.Services
{
    public class PersonalIDRepository : IPersonalIDRepository
    {
        public IMemoryCache _memoryCache;
        public PersonalIDRepository(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public List<PersonalID> getPersonalId()
        {
            Thread.Sleep(3000);
            List<PersonalID> newPersonalList = new List<PersonalID>
            {
                new PersonalID(){FirstName = "Kerem Görkem", LastName = "Görgülü"},
                new PersonalID(){FirstName = "Sami Mert", LastName = "Gündoğdu"},
                new PersonalID(){FirstName = "Cihat", LastName = "Altıparmak"}
            };
            return newPersonalList;
        }

        public async Task<List<PersonalID>> getPersonalIdAsync()
        {
            List<PersonalID> newPersonalList = new List<PersonalID>
            {
                new PersonalID(){FirstName = "Kerem Görkem", LastName = "Görgülü"},
                new PersonalID(){FirstName = "Sami Mert", LastName = "Gündoğdu"},
                new PersonalID(){FirstName = "Cihat", LastName = "Altıparmak"}
            };

            await Task.Delay(3000);
            return newPersonalList;
        }

        public async Task<List<PersonalID>> getPersonalIdCached()
        {
            List<PersonalID> personalList;

            personalList = _memoryCache.Get<List<PersonalID>>(key: "personalList");

            if (personalList == null)
            {
               personalList = new List<PersonalID>
                {
                    new PersonalID(){FirstName = "Kerem Görkem", LastName = "Görgülü"},
                    new PersonalID(){FirstName = "Sami Mert", LastName = "Gündoğdu"},
                    new PersonalID(){FirstName = "Cihat", LastName = "Altıparmak"}
                };
                await Task.Delay(3000);
                _memoryCache.Set<List<PersonalID>>(key: "personalList", value: personalList, TimeSpan.FromMinutes(1));
            }
            return personalList;
        }
    }
}
