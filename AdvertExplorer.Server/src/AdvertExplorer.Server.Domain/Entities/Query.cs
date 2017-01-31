using System;
using AdvertExplorer.Server.Domain.ValueObjects;
using JetBrains.Annotations;

namespace AdvertExplorer.Server.Domain.Entities
{
	public sealed class Query
	{
		private static readonly TimeSpan CacheTimeLife = TimeSpan.FromHours(1); //TODO move this field to another place?

		public bool IsActual => LastUpdateDate + CacheTimeLife > DateTime.UtcNow;

		public Guid Id { get; }

		public DateTime LastUpdateDate { get; internal set; }

		public Region Region { get; }

		[CanBeNull]
		public Rubric? Rubric { get; }

		[CanBeNull]
		public Experience? Experience { get; }

		[CanBeNull]
		public uint? Salary { get; }

		[CanBeNull]
		public uint? AgeMax { get; }

		[CanBeNull]
		public uint? AgeMin { get; }

		[CanBeNull]
		public string SearchString { get; }

		public Query(
			Guid id,
			DateTime lastUpdateDate,
			Region region,
			[CanBeNull] Rubric? rubric = null,
			[CanBeNull] Experience? experience = null,
			[CanBeNull] uint? salary = null,
			[CanBeNull] uint? ageMax = null,
			[CanBeNull] uint? ageMin = null,
			[CanBeNull] string searchString = null)
		{
			Id = id;
			LastUpdateDate = lastUpdateDate;
			Region = region;
			Rubric = rubric;
			Experience = experience;
			Salary = salary;
			AgeMax = ageMax;
			AgeMin = ageMin;
			SearchString = searchString;
		}

		public Query(
			Region region,
			[CanBeNull] Rubric? rubric = null,
			[CanBeNull] Experience? experience = null,
			[CanBeNull] uint? salary = null,
			[CanBeNull] uint? ageMax = null,
			[CanBeNull] uint? ageMin = null,
			[CanBeNull] string searchString = null)
		{
			Id = Guid.NewGuid();
			LastUpdateDate = DateTime.UtcNow;
			Region = region;
			Rubric = rubric;
			Experience = experience;
			Salary = salary;
			AgeMax = ageMax;
			AgeMin = ageMin;
			SearchString = searchString;
		}
	}
}