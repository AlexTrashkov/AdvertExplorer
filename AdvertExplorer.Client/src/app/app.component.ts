import {Component, OnInit, Inject, ViewEncapsulation} from '@angular/core';
import {IApiClient, ApiClientToken} from '../providers/api-client';
import {Query} from '../model/query';
import {Resume} from '../model/resume';
import {Region} from '../model/region';

@Component({
	selector: 'app',
	template: require('./app.component.html'),
	styles: [require('./app.component.scss')],
	encapsulation: ViewEncapsulation.None,
})
export class AppComponent implements OnInit {
	public currentQuery: Query;
	public currentResumes: Resume[];
	public isLoading: boolean;

	constructor(@Inject(ApiClientToken) private apiClient: IApiClient) {
		this.currentQuery = {
			region: Region.Ekaterinburg,
			searchString: ''
		};
	}

	public refreshResumes() {
		this.currentResumes = [];
		this.isLoading = true;
		this.apiClient.getResumes(this.currentQuery)
			.then(result => {
				this.currentResumes = result;
				this.isLoading = false;
			});
	}

	ngOnInit(): void {
		this.refreshResumes();
	}
}