using System;
using AdvertExplorer.Server.Domain.ValueObjects;
using JetBrains.Annotations;

namespace AdvertExplorer.Server.Storage.DTO
{
	internal sealed class QueryDTO
	{
		public Guid Id { get; set; }

		public DateTime LastUpdateDate { get; set; }

		public Region Region { get; set; }

		[CanBeNull]
		public Rubric? Rubric { get; set; }

		[CanBeNull]
		public Experience? Experience { get; set; }

		[CanBeNull]
		public uint? Salary { get; set; }

		[CanBeNull]
		public uint? AgeMax { get; set; }

		[CanBeNull]
		public uint? AgeMin { get; set; }

		[CanBeNull]
		public string SearchString { get; set; }
	}
}