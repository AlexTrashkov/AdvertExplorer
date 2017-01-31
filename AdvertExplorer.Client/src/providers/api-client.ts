import {Query} from '../model/query';
import {Resume} from '../model/resume';
import {Http} from '@angular/http';
import {OpaqueToken, Inject} from '@angular/core';
import 'rxjs/Rx';
import 'rxjs/add/operator/map'

export const ApiClientToken = new OpaqueToken('ApiClientToken');

export interface IApiClient {
	getResumes(query: Query): Promise<Resume[]>;
}

export class ApiClient implements IApiClient {
	private baseUri: string;

	public constructor(@Inject(Http) private http: Http) {
		this.baseUri = "/api";
	}

	public getResumes(query: Query): Promise<Resume[]> {
		let requestString = `${this.baseUri}/resumes?region=${query.region}`;

		if (Number.isInteger(query.rubric)) {
			requestString += `&rubric=${query.rubric}`;
		}

		if (Number.isInteger(query.experience)) {
			requestString += `&experience=${query.experience}`;
		}

		if (Number.isInteger(Number(query.salary))) {
			requestString += `&salary=${query.salary}`;
		}

		if (Number.isInteger(Number(query.ageMax))) {
			requestString += `&maxAge=${query.ageMax}`;
		}

		if (Number.isInteger(Number(query.ageMin))) {
			requestString += `&minAge=${query.ageMin}`;
		}

		if (query.searchString) {
			requestString += `&searchString=${query.searchString}`;
		}

		return this.http
			.get(requestString)
			.toPromise()
			.then(response => response.json());
	}
}