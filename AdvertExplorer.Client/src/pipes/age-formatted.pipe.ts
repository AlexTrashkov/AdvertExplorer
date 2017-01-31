import {Pipe, PipeTransform} from '@angular/core';

@Pipe({
	name: 'ageFormatted'
})
export class AgeFormattedPipe implements PipeTransform {
	transform(value: number, args: any[]): any {
		const lastNumber = value % 10;

		switch (lastNumber) {
			case 1:
				return value + " год";
			
			case 2:
			case 3:
			case 4:
				return value + " года";
				
			case 5:
			case 6:
			case 7:
			case 8:
			case 9:
			case 0:
				return value + " лет";

			default:
				throw new Error("Incorrect data for formatted age");
		}
	}
}