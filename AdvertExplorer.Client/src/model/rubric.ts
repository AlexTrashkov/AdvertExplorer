export enum Rubric
{
	IT,
	Finance,
	Design,
	Security,
	Education
}

export function GetAllRubrics(): Rubric[] {
	return [
		Rubric.IT,
		Rubric.Finance,
		Rubric.Design,
		Rubric.Security,
		Rubric.Education
	]
}

export function RubricToString(rubric: Rubric): string {
	switch (rubric) {
		case Rubric.IT:
			return 'ИТ и интернет';
		case Rubric.Finance:
			return 'Бухгалтерия и финансы';
		case Rubric.Design:
			return 'Дизайн и искусство';
		case Rubric.Security:
			return 'Охрана и безопасность';
		case Rubric.Education:
			return 'Образование и наука';
		case undefined:
		case null:
			return 'Не указана';
		default:
			throw new Error("Cannot convert current rubric to string");
	}
}