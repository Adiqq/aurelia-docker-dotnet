export class App {
    configureRouter(config, router) {
        config.title = 'Aurelia';
        config.map([
            { route: ['', 'welcome'], name: 'welcome', moduleId: 'welcome', nav: true, title: 'Welcome' },
            { route: 'users', name: 'users', moduleId: 'users', nav: true, title: 'Github Users' },
            { route: 'child-router', name: 'child-router', moduleId: 'child-router', nav: true, title: 'Child Router' },
            { route: 'test-api', name: 'test-api', moduleId: 'test-api', nav: true, title: 'Test API connection' },
            { route: 'comments', name: 'comments', moduleId: 'comments', nav: true, title: 'Comments' }
        ]);

        this.router = router;
    }
}
