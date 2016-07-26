import {inject} from 'aurelia-framework';
import {HttpClient} from 'aurelia-fetch-client';
import 'fetch';
import _config from 'config-service';

@inject(HttpClient, _config)
export class TestApi {
    heading = 'Loading from API';

    constructor(http, config) {
        http.configure(c => {
            c.useStandardConfiguration().withBaseUrl(config.baseUrl);
        });

        this.http = http;
    }

    activate() {
        return this.http.fetch('values/5')
            .then(response => response.text())
            .then(heading => this.heading = heading);
    }
}
