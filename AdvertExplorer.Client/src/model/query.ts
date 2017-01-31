import {Region} from './region';
import {Experience} from './experience';
import {Rubric} from './rubric';

export interface Query {
	region: Region;
	rubric?: Rubric;
	experience?: Experience;
	salary?: number;
	ageMax?: number;
	ageMin?: number;
	searchString?: string;
}