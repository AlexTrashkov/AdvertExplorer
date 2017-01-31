import {Component, OnInit} from '@angular/core';
import {Resume} from '../../model/resume';
import {Experience, ExperienceToString, GetAllExperiences} from '../../model/experience';

@Component({
	selector: 'resume',
	template: require('./resume.component.html'),
	styles: [require('./resume.component.scss')],
	inputs: ['resume']
})
export class ResumeComponent implements OnInit {
	public resume: Resume;

	constructor() {
	}

	ngOnInit() {
	}

	public experience = Experience;
	public experienceToString = ExperienceToString;
	public getAllExperiences = GetAllExperiences;
}