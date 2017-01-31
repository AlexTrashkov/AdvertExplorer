export enum Region
{
	Moscow,
	Ekaterinburg,
	Sevastopol
}

export function GetAllRegions(): Region[] {
	return [
		Region.Moscow,
		Region.Ekaterinburg,
		Region.Sevastopol
	]
}

export function RegionToString(region: Region): string {
	switch (region) {
		case Region.Moscow:
			return 'Москва';
		case Region.Ekaterinburg:
			return 'Екатеринбург';
		case Region.Sevastopol:
			return 'Севастополь';
		case undefined:
		case null:
			return 'Не указан';
		default:
			throw new Error("Cannot convert current region to string");
	}
}