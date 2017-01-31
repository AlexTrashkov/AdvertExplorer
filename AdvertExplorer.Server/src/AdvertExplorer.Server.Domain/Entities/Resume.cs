using System.Collections.Generic;
using AdvertExplorer.Server.Domain.ValueObjects;
using JetBrains.Annotations;

namespace AdvertExplorer.Server.Domain.Entities
{
	public sealed class Resume
	{
		public int Id { get; }

		public Region City { get; }

		[NotNull]
		public IReadOnlyCollection<Rubric> Rubrics { get; }

		[NotNull]
		public string JobTitle { get; }

		[CanBeNull]
		public string Name { get; }

		[CanBeNull]
		public uint? Age { get; }

		[CanBeNull]
		public string Institution { get; }

		[CanBeNull]
		public string PhotoUri { get; }

		[CanBeNull]
		public string Specialty { get; }

		[CanBeNull]
		public string Description { get; }

		[CanBeNull]
		public Experience? Experience { get; }

		[CanBeNull]
		public string EducationType { get; }

		[CanBeNull]
		public string WorkingType { get; }

		[CanBeNull]
		public uint? Salary { get; }

		public Resume(
			int id,
			Region city,
			[NotNull] IReadOnlyCollection<Rubric> rubrics,
			[NotNull] string jobTitle,
			[CanBeNull] string name = null,
			[CanBeNull] uint? age = null,
			[CanBeNull] string institution = null,
			[CanBeNull] string photoUri = null,
			[CanBeNull] string specialty = null,
			[CanBeNull] string description = null,
			[CanBeNull] Experience? experience = null,
			[CanBeNull] string educationType = null,
			[CanBeNull] string workingType = null,
			[CanBeNull] uint? salary = null)
		{
			Id = id;
			City = city;
			Rubrics = rubrics;
			JobTitle = jobTitle;
			Name = name;
			Age = age;
			Institution = institution;
			PhotoUri = photoUri;
			Specialty = specialty;
			Description = description;
			Experience = experience;
			EducationType = educationType;
			WorkingType = workingType;
			Salary = salary;
		}
	}
}