using Mark_Question5_Solution.Dtos.Country;
using Mark_Question5_Solution.Dtos.Others;
using Mark_Question5_Solution.Helpers;
using Mark_Question5_Solution.Interfaces;
using Mark_Question5_Solution.Models;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;
using System.Collections;

namespace Mark_Question5_Solution.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        //QUESTION 5
        /*
            Write a C# Web API that:

            - returns a list of countries with from the IList class using the get method

            - adds a country to the list using the POST method

            - returns a particular country using its index from the list i.e get/{id}
        */

        private readonly IWebHostEnvironment _webHostEnvironment;

        public CountryRepository(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<ReturnResponse> CreateCountry(CountryRequest countryRequest)
        {
            if (countryRequest == null)
            {
                return new ReturnResponse()
                {
                    StatusCode = Utils.StatusCode_ObjectNull,
                    StatusMessage = Utils.StatusMessage_ObjectNull
                };
            }

            if (string.IsNullOrWhiteSpace(countryRequest.CountryName))
            {
                return new ReturnResponse()
                {
                    StatusCode = Utils.StatusCode_NameEmpty,
                    StatusMessage = Utils.StatusMessage_NameEmpty
                };
            }

            //var countries = await XDocument.LoadAsync(XmlReader.Create(_webHostEnvironment.ContentRootPath + @"\Database\CountryDatabase.xml", new XmlReaderSettings() { Async = true }), LoadOptions.None, System.Threading.CancellationToken.None);
            var countries = XDocument.Load(_webHostEnvironment.ContentRootPath + @"\Database\CountryDatabase.xml");
            var allountrys = countries.Element("Countries").Elements("Country").ToList();
            if(allountrys.Any(a => a.Attribute("CountryName").Value.Trim().Equals(countryRequest.CountryName.Trim(),StringComparison.OrdinalIgnoreCase)))
            {
                return new ReturnResponse()
                {
                    StatusCode = Utils.StatusCode_ObjectExists,
                    StatusMessage = Utils.StatusMessage_ObjectExists
                };
            }

            var countryCount = allountrys.Count();
            countryCount = countryCount + 1;
            var country = new Country()
            {
                CountryId = countryCount,
                CountryName = countryRequest.CountryName
            };

            countries.Element("Countries").Add(new XElement("Country", new XAttribute("CountryId", country.CountryId), new XAttribute("CountryName", country.CountryName)));
            //await countries.SaveAsync(XmlWriter.Create(_webHostEnvironment.ContentRootPath + @"\Database\CountryDatabase.xml", new XmlWriterSettings() { Async = true }), System.Threading.CancellationToken.None);
            countries.Save(_webHostEnvironment.ContentRootPath + @"\Database\CountryDatabase.xml");

            return new ReturnResponse()
            {
                StatusCode = Utils.StatusCode_Success,
                StatusMessage = Utils.StatusMessage_Success,
                ObjectValue = country
            };
        }

        public async Task<ReturnResponse> GetCountry()
        {
            var countries = XDocument.Load(_webHostEnvironment.ContentRootPath + @"\Database\CountryDatabase.xml");
            IList allCountries = countries.Element("Countries").Elements("Country").Select(a => new Country()
            {
                CountryId = Convert.ToInt32(a.Attribute("CountryId").Value),
                CountryName = a.Attribute("CountryName").Value
            }).ToList();

            return new ReturnResponse()
            {
                StatusCode = Utils.StatusCode_Success,
                StatusMessage = Utils.StatusMessage_Success,
                ObjectValue = allCountries
            };
        }

        public async Task<ReturnResponse> GetCountry(int countryId)
        {
            var countries = XDocument.Load(_webHostEnvironment.ContentRootPath + @"\Database\CountryDatabase.xml");
             var country = countries.Element("Countries").Elements("Country").Where(a => Convert.ToInt32(a.Attribute("CountryId").Value) == countryId).Select(b => new Country()
             {
                 CountryId = Convert.ToInt32(b.Attribute("CountryId").Value),
                 CountryName = b.Attribute("CountryName").Value
             }).FirstOrDefault();

             if (country == null)
             {
                 return new ReturnResponse()
                 {
                     StatusCode = Utils.StatusCode_NotFound,
                     StatusMessage = Utils.StatusMessage_NotFound
                 };
             }

             return new ReturnResponse()
             {
                 StatusCode = Utils.StatusCode_Success,
                 StatusMessage = Utils.StatusMessage_Success,
                 ObjectValue = country
             };
        }
    }
}
