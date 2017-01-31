import {Rubric} from './rubric';
import {Region} from './region';
import {Experience} from './experience';

export interface Resume {
	id: number;
	city: Region;
	name: string;
	age: number;
	rubrics: Rubric[];
	institution?: string;
	jobTitle: string;
	photoUri?: string;
	speciality?: string;
	description?: string;
	experience?: Experience;
	educationType?: string;
	workingType?: string;
	salary?: number;
}