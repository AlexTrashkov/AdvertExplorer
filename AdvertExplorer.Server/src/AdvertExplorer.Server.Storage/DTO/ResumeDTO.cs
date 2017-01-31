using System.Collections.Generic;
using AdvertExplorer.Server.Domain.ValueObjects;
using JetBrains.Annotations;

namespace AdvertExplorer.Server.Storage.DTO
{
	internal sealed class ResumeDTO
	{
		public int Id { get; set; }

		public Region City { get; set; }

		[CanBeNull]
		public string Name { get; set; }

		[CanBeNull]
		public uint? Age { get; set; }

		[NotNull]
		public string Rubrics { get; set; }

		[CanBeNull]
		public string Institution { get; set; }

		[NotNull]
		public string JobTitle { get; set; }

		[CanBeNull]
		public string PhotoUri { get; set; }

		[CanBeNull]
		public string Specialty { get; set; }

		[CanBeNull]
		public string Description { get; set; }

		[CanBeNull]
		public Experience? Experience { get; set; }

		[CanBeNull]
		public string EducationType { get; set; }

		[CanBeNull]
		public string WorkingType { get; set; }

		[CanBeNull]
		public uint? Salary { get; set; }
	}
}