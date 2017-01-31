using System;
using AdvertExplorer.Server.Domain.Entities;
using Xunit;
using Moq;
using AdvertExplorer.Server.Domain.Repositories;
using AdvertExplorer.Server.Domain.Services;
using AdvertExplorer.Server.Domain.Services.Implementations;
using AdvertExplorer.Server.Domain.ValueObjects;

namespace AdvertExplorer.Server.Domain.Tests
{
	public sealed class ResumeServiceTests
	{
		[Fact]
		public void GetBy_QueryRepositoryHasNotAnyQuery_UseApiClientForResolve()
		{
			//Arrange
			var queryRepositoryMock = new Mock<IQueryRepository>();
			queryRepositoryMock
				.Setup(x => x.FindBy(It.IsAny<Region>(), null, null, null, null, null, null))
				.Returns((Query) null);

			var resumeRepositoryMock = new Mock<IResumeRepository>();
			var externalResumeApiClientMock = new Mock<IExternalResumeApiClient>();

			IResumeService resumeService = new ResumeService(
				resumeRepositoryMock.Object,
				queryRepositoryMock.Object,
				externalResumeApiClientMock.Object);

			//Act
			resumeService.GetBy(Region.Moscow);

			//Assert
			queryRepositoryMock.Verify(x => x.FindBy(It.IsAny<Region>(), null, null, null, null, null, null), Times.Once);
			resumeRepositoryMock.Verify(x => x.GetBy(It.IsAny<Query>()), Times.Never);
			externalResumeApiClientMock.Verify(x => x.LoadResumes(It.IsAny<Query>()), Times.Once);
		}

		[Fact]
		public void GetBy_QueryRepositoryHasNotActualQuery_UseApiClientForResolve()
		{
			//Arrange
			var queryRepositoryMock = new Mock<IQueryRepository>();
			queryRepositoryMock
				.Setup(x => x.FindBy(It.IsAny<Region>(), null, null, null, null, null, null))
				.Returns(new Query(Guid.NewGuid(), DateTime.UtcNow - TimeSpan.FromDays(1), Region.Moscow));

			var resumeRepositoryMock = new Mock<IResumeRepository>();
			var externalResumeApiClientMock = new Mock<IExternalResumeApiClient>();

			IResumeService resumeService = new ResumeService(
				resumeRepositoryMock.Object,
				queryRepositoryMock.Object,
				externalResumeApiClientMock.Object);

			//Act
			resumeService.GetBy(Region.Moscow);

			//Assert
			queryRepositoryMock.Verify(x => x.FindBy(It.IsAny<Region>(), null, null, null, null, null, null), Times.Once);
			resumeRepositoryMock.Verify(x => x.GetBy(It.IsAny<Query>()), Times.Never);
			externalResumeApiClientMock.Verify(x => x.LoadResumes(It.IsAny<Query>()), Times.Once);
		}

		[Fact]
		public void GetBy_QueryRepositoryHasActualQuery_UseResumeRepositoryForResolve()
		{
			//Arrange
			var queryRepositoryMock = new Mock<IQueryRepository>();
			queryRepositoryMock
				.Setup(x => x.FindBy(It.IsAny<Region>(), null, null, null, null, null, null))
				.Returns(new Query(Guid.NewGuid(), DateTime.UtcNow, Region.Moscow));

			var resumeRepositoryMock = new Mock<IResumeRepository>();
			var externalResumeApiClientMock = new Mock<IExternalResumeApiClient>();

			IResumeService resumeService = new ResumeService(
				resumeRepositoryMock.Object,
				queryRepositoryMock.Object,
				externalResumeApiClientMock.Object);

			//Act
			resumeService.GetBy(Region.Moscow);

			//Assert
			queryRepositoryMock.Verify(x => x.FindBy(It.IsAny<Region>(), null, null, null, null, null, null), Times.Once);
			resumeRepositoryMock.Verify(x => x.GetBy(It.IsAny<Query>()), Times.Once);
			externalResumeApiClientMock.Verify(x => x.LoadResumes(It.IsAny<Query>()), Times.Never);
		}
	}
}