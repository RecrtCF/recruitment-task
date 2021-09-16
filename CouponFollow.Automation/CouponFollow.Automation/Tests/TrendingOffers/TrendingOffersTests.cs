using CouponFollow.Automation.Dtos;
using FluentAssertions;
using NUnit.Framework;
using RestSharp;
using RestSharp.Serialization.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace CouponFollow.Automation.Tests.TrendingOffers
{
    public class TrendingOffersTests : BaseTest
    {
        [Test]
        public void GetTrendingOffers_CatcVersionHeaderProvided_ReturnsListOfTrendingOffers()
        {
            // Arrange
            var client = new RestClient(BaseUrl);
            var request = new RestRequest("extension/trendingOffers", Method.GET);
            request.AddHeader("catc-version", CatcVersion);

            // Act
            var response = client.Execute(request);
            var trendingOffers = new JsonSerializer().Deserialize<List<TrendingOffersDto>>(response);

            // Assert
            trendingOffers.Should().BeOfType(typeof(List<TrendingOffersDto>));
        }

        [Test]
        public void GetTrendingOffers_CatcVersionHeaderMissing_Status403Forbidden()
        {
            // Arrange
            var client = new RestClient(BaseUrl);
            var request = new RestRequest("extension/trendingOffers", Method.GET);

            // Act
            var response = client.Execute(request);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.Forbidden);
        }

        [Test]
        public void GetTrendingOffers_CatcVersionHeaderProvided_ReturnedNumberOfTrendingOffersIsLessOrEqualTo20()
        {
            // Arrange
            var client = new RestClient(BaseUrl);
            var request = new RestRequest("extension/trendingOffers", Method.GET);
            request.AddHeader("catc-version", CatcVersion);

            // Act
            var response = client.Execute(request);
            var trendingOffers = new JsonSerializer().Deserialize<List<TrendingOffersDto>>(response);

            // Assert
            trendingOffers.Count.Should().BeLessOrEqualTo(20);
        }

        [Test]
        public void GetTrendingOffers_CatcVersionHeaderProvided_EachReturnedOfferContainsUniqueDomainName()
        {
            // Arrange
            var client = new RestClient(BaseUrl);
            var request = new RestRequest("extension/trendingOffers", Method.GET);
            request.AddHeader("catc-version", CatcVersion);

            // Act
            var response = client.Execute(request);
            var trendingOffers = new JsonSerializer().Deserialize<List<TrendingOffersDto>>(response);

            // Assert
            var numberOfUniqueDomainNames = trendingOffers.Select(to => to.DomainName).Distinct().Count();
            trendingOffers.Count.Should().Be(numberOfUniqueDomainNames);
        }
    }
}
