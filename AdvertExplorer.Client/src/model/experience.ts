export enum Experience
{
	None,
	LessThanOneYear,
	OneToThreeYears,
	ThreeToFiveYears,
	MoreThanFiveYears
}

export function GetAllExperiences(): Experience[] {
	return [
		Experience.None,
		Experience.LessThanOneYear,
		Experience.OneToThreeYears,
		Experience.ThreeToFiveYears,
		Experience.MoreThanFiveYears];
}

export function ExperienceToString(experience: Experience): string {
	switch (experience) {
		case Experience.None:
			return 'Нет опыта';
		case Experience.LessThanOneYear:
			return 'Меньше одного года';
		case Experience.OneToThreeYears:
			return 'От года до трёх лет';
		case Experience.ThreeToFiveYears:
			return 'От трёх до пяти лет';
		case Experience.MoreThanFiveYears:
			return 'Больше пяти лет';
		case undefined:
		case null:
			return 'Не указан';
		default:
			throw new Error("Cannot convert current experience to string");
	}
}