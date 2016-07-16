import {inject} from 'aurelia-framework';
import {HttpClient} from 'aurelia-fetch-client';
import 'fetch';

@inject(HttpClient)
export class TestApi {
  heading = 'Loading from API';

  constructor(http) {
    http.configure(config => {
      config
        .useStandardConfiguration()
        .withBaseUrl('http://localhost:5000/api/');
    });

    this.http = http;
  }

  activate() {
    return this.http.fetch('values/5')
      .then(response => response.text())
      .then(heading => this.heading = heading);
  }
}
