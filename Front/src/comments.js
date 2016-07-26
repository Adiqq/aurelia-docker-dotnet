import {inject} from 'aurelia-framework';
import {HttpClient, json} from 'aurelia-fetch-client';
import 'fetch';
import _config from 'config-service';

@inject(HttpClient, _config)
export class Comments {
    constructor(http, config) {
        http.configure(c => {
            c.useStandardConfiguration().withBaseUrl(config.baseUrl);
        });

        this.http = http;

        this.author = '';
        this.comment = '';
    }
    submit() {
        let comment = {
            Author: this.author,
            Content: this.comment,
            PageId: this.page.id
        };
        this.http.fetch('comments', {
            method: 'post',
            body: json(comment)
        }).then(response => this.getComments())
        .catch(error => {
            alert('Error saving comment!');
        });
    }

    getComments() {
        return this.http.fetch('pages/comments')
            .then(response => response.json())
            .then(page => this.page = page);
    }

    activate() {
        return this.getComments();
    }
}
