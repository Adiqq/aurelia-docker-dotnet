# aurelia-docker-dotnet

## Overview

This project uses [Docker](https://docs.docker.com/) for contenerization.

There are two containers, one for API and one for front-end.

### Front-end

Front-end project uses [Aurelia](http://aurelia.io/) with initial structure generated
by [Yeoman](http://yeoman.io/), [generator-aurelia](https://github.com/zewa666/generator-aurelia).

It uses [gulp-watch](https://www.npmjs.com/package/gulp-watch) and 
[browsersync](https://www.browsersync.io/),
 so our changes in code will be automatically applied.

### API

Back-end API uses [.NET Core](https://docs.microsoft.com/pl-pl/dotnet/articles/core/index)
with [ASP.NET Core](https://docs.asp.net/en/latest/).

It uses [dotnet-watch](https://github.com/aspnet/dotnet-watch), so after we run our components,
changes to code will be automatically applied to server.

### Docker

We will use [docker-compose](https://docs.docker.com/compose/overview/) to simplify
containers management.

We are going to use [Docker for Windows](https://docs.docker.com/docker-for-windows/).

After installation, open Docker Settings and on Shared Drives tab, set your drive as shared.
It's necessary to mount project's code to containers, so if e.g. your project is on C drive,
you need to share C. 

Now, we need to clone our git project, `git clone https://github.com/Adiqq/aurelia-docker-dotnet.git`

Next, we execute `install.bat`, it will execute powershell script as administrator.
This script will install [Chocolatey](https://chocolatey.org/), then Chocolatey will install
[Node.js](https://nodejs.org/en/), [Gulp](http://gulpjs.com/) and [jspm](http://jspm.io/).
It will also install all [npm](https://www.npmjs.com/) and jspm dependencies.

We can also install dependencies manually:
`npm install && jspm install`

Now, we can run `run-docker.bat`, this will execute powershell script that simply calls `docker-compose up`.
It will build our containers and run them.

Alternatively, we can simply open cmd/powershell and call it ourselves from project's directory.

We are mainly going to use few, useful docker-compose commands:

`docker-compose up` - start our containers (also build if necessary)

`docker-compose build`- build containers

`docker-compose build --no-cache`- rebuild from scratch

In case we didn't closed our containers correctly, we can use:

`docker-compose stop` or `docker-compose kill`

Alternatively, we can use:

`docker ps` to list all running components and then kill them by id:

`docker kill 'container id'`

