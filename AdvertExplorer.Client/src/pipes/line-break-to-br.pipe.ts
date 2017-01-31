import {Pipe, PipeTransform} from '@angular/core';

@Pipe({
	name: 'lineBreakToBr'
})
export class LineBreakToBrPipe implements PipeTransform {
	transform(value: string, args: any[]): any {
		return value.replace(/\n/g, '<br>')
	}
}