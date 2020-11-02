using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Mark_Question5_Solution.Dtos.Country;
using Mark_Question5_Solution.Dtos.Others;
using Mark_Question5_Solution.Helpers;
using Mark_Question5_Solution.Interfaces;
using Mark_Question5_Solution.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mark_Question5_Solution.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountrysController : ControllerBase
    {
        private readonly ICountryRepository _countryRepository;

        public CountrysController(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        [HttpGet]
        public async Task<ActionResult<ReturnResponse>> GetCountries()
        {
            var result = await _countryRepository.GetCountry();

            if (result.StatusCode == Utils.StatusCode_Success)
            {
                return StatusCode(StatusCodes.Status200OK, result);
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest, result);
            }
        }

        [HttpGet("{countryId}")]
        public async Task<ActionResult<ReturnResponse>> GetCountry([FromRoute] int countryId)
        {
            var result = await _countryRepository.GetCountry(countryId);

            if (result.StatusCode == Utils.StatusCode_Success)
            {
                return StatusCode(StatusCodes.Status200OK, result);
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest, result);
            }
        }

        [HttpPost]
        public async Task<ActionResult<ReturnResponse>> PostCountry([FromBody] CountryRequest countryRequest)
        {
            var result = await _countryRepository.CreateCountry(countryRequest);
            
            if(result.StatusCode == Utils.StatusCode_Success)
            {
                return StatusCode(StatusCodes.Status200OK, result);
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest, result);
            }
        }
    }
}
