using Mark_Question5_Solution.Dtos.Country;
using Mark_Question5_Solution.Dtos.Others;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mark_Question5_Solution.Interfaces
{
    public interface ICountryRepository
    {
        public Task<ReturnResponse> CreateCountry(CountryRequest countryRequest);
        public Task<ReturnResponse> GetCountry();
        public Task<ReturnResponse> GetCountry(int countryId);
    }
}
