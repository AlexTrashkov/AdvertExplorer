using System.Linq;
using AdvertExplorer.Server.Domain.Entities;
using AdvertExplorer.Server.Domain.Services;
using AdvertExplorer.Server.Domain.ValueObjects;
using AdvertExplorer.Server.Integration.ZarplataRu;
using AutoMapper;
using Xunit;

namespace AdvertExplorer.Server.Integration.Tests
{
	public sealed class ZarplataRuApiClientTests
	{
		private readonly IExternalResumeApiClient _externalResumeApiClient;

		public ZarplataRuApiClientTests()
		{
			Mapper.Initialize(x => x.AddProfile<IntegrationAutoMapperProfile>());
			_externalResumeApiClient = new ZarplataRuApiClient(Mapper.Instance);
		}

		[Fact]
		public void LoadResumes_FromEkaterinburg_Correct()
		{
			//Arrange
			var query = new Query(Region.Ekaterinburg);

			//Act
			var result = _externalResumeApiClient.LoadResumes(query);

			//Assert
			Assert.NotNull(result);
			Assert.True(result.Any());
			Assert.True(result.All(x => x.City == Region.Ekaterinburg));
		}

		[Fact]
		public void LoadResumes_WithITRubric_Correct()
		{
			//Arrange
			var query = new Query(Region.Ekaterinburg, Rubric.IT);

			//Act
			var result = _externalResumeApiClient.LoadResumes(query);

			//Assert
			Assert.NotNull(result);
			Assert.True(result.Any());
			Assert.True(result.All(x => x.Rubrics.Contains(Rubric.IT)));
		}

		[Fact]
		public void LoadResumes_WithMoreThanFiveYearsExperience_Correct()
		{
			//Arrange
			var query = new Query(Region.Ekaterinburg, experience: Experience.MoreThanFiveYears);

			//Act
			var result = _externalResumeApiClient.LoadResumes(query);

			//Assert
			Assert.NotNull(result);
			Assert.True(result.Any());
			Assert.True(result.All(x => x.Experience == Experience.MoreThanFiveYears));
		}

		[Fact]
		public void LoadResumes_WithSalaryNotMoreThen25000RUB_Correct()
		{
			//Arrange
			var query = new Query(Region.Ekaterinburg, salary: 25000);

			//Act
			var result = _externalResumeApiClient.LoadResumes(query);

			//Assert
			Assert.NotNull(result);
			Assert.True(result.Any());
			Assert.True(result.All(x => x.Salary == null || x.Salary <= 25000));
		}

		[Fact]
		public void LoadResumes_WithMaxAge45YearsOld_Correct()
		{
			//Arrange
			var query = new Query(Region.Ekaterinburg, ageMax: 45);

			//Act
			var result = _externalResumeApiClient.LoadResumes(query);

			//Assert
			Assert.NotNull(result);
			Assert.True(result.Any());
			Assert.True(result.All(x => x.Age == null || x.Age <= 45));
		}

		[Fact]
		public void LoadResumes_WithMinAge20YearsOld_Correct()
		{
			//Arrange
			var query = new Query(Region.Ekaterinburg, ageMin: 20);

			//Act
			var result = _externalResumeApiClient.LoadResumes(query);

			//Assert
			Assert.NotNull(result);
			Assert.True(result.Any());
			Assert.True(result.All(x => x.Age == null || x.Age >= 20));
		}
	}
}