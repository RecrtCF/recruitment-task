# recruitment-task

Jakub Piaszczak

- Utilized libraries:
  - RestSharp - for HTTP communication
  - NUnit - for test structure
  - FluentAssertions - to make assertions easier
- .NET Framework 4.7.2
- Each test covers one scenario from the requirements, however, in real case I think that tests `GetTrendingOffers_CatcVersionHeaderProvided_ReturnsListOfTrendingOffers`, `GetTrendingOffers_CatcVersionProvided_ReturnedNumberOfTrendingOffersIsLessOrEqualTo20` and `GetTrendingOffers_CatcVersionProvided_EachReturnedOfferContainsUniqueDomainName` should be merged into one, as they all require the same setup (they check the same endpoint, using the same HTTP method and the same request's properties).
- Tests can be run directly from Visual Studio (Test -> Test Explorer) or from the command line using e.g. nunit console runner
