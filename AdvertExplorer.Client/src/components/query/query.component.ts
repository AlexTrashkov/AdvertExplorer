import {Component, EventEmitter} from '@angular/core';
import {Query} from '../../model/query';
import {Experience, ExperienceToString, GetAllExperiences} from '../../model/experience';
import {Region, RegionToString, GetAllRegions} from '../../model/region';
import {Rubric, RubricToString, GetAllRubrics} from '../../model/rubric';

@Component({
	selector: 'query',
	template: require('./query.component.html'),
	styles: [require('./query.component.scss')],
	inputs: ['query'],
	outputs: ['submit']
})
export class QueryComponent {
	public query: Query;
	public submit: EventEmitter<void>;

	constructor() {
		this.submit = new EventEmitter<void>();
	}

	//Defines for enums
	public experience = Experience;
	public experienceToString = ExperienceToString;
	public getAllExperiences = GetAllExperiences;

	public region = Region;
	public regionToString = RegionToString;
	public getAllRegions = GetAllRegions;

	public rubric = Rubric;
	public rubricToString = RubricToString;
	public getAllRubrics = GetAllRubrics;
}