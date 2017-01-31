import {NgModule} from '@angular/core';
import {AppComponent} from './app.component';
import {BrowserModule} from '@angular/platform-browser';
import {HttpModule} from '@angular/http';
import {ApiClientToken, ApiClient} from '../providers/api-client';
import {ResumeComponent} from '../components/resume/resume.component';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';
import {FormsModule} from '@angular/forms';
import {AgeFormattedPipe} from '../pipes/age-formatted.pipe';
import {LineBreakToBrPipe} from '../pipes/line-break-to-br.pipe';
import {QueryComponent} from '../components/query/query.component';

@NgModule({
	bootstrap: [AppComponent],
	declarations: [
		AppComponent,
		ResumeComponent,
		QueryComponent,
		AgeFormattedPipe,
		LineBreakToBrPipe
	],
	imports: [
		BrowserModule,
		HttpModule,
		FormsModule,
		NgbModule.forRoot()
	],
	providers: [
		{provide: ApiClientToken, useClass: ApiClient},
	]
})
export class AppModule {
	constructor() {
	}
}