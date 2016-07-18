var gulp = require('gulp');
var paths = require('../paths');
var browserSync = require('browser-sync');
var watch = require('gulp-watch');

// outputs changes to files to the console
function reportChange(path) {
  console.log('File ' + path + ' was changed , running tasks...');
}

// this task wil watch for changes
// to js, html, and css files and call the
// reportChange method. Also, by depending on the
// serve task, it will instantiate a browserSync session
gulp.task('watch', ['serve'], function () {

  //TODO adrian: veeeery hacky, it should take gulp task ['build-system', browserSync.reload], but there's exception if we pass (string,options,callback)

  watch(paths.source, { interval: 1000, usePolling: true }, function (file, event) {
    reportChange(file.path);
    gulp.start('build-system', function () {
      browserSync.reload();
    });
  });
  watch(paths.html, { interval: 1000, usePolling: true }, function (file, event) {
    reportChange(file.path);
    gulp.start('build-html', function () {
      browserSync.reload();
    });
  });
  watch(paths.css, { interval: 1000, usePolling: true }, function (file, event) {
    reportChange(file.path);
    gulp.start('build-css');
  });
  watch(paths.style, { interval: 1000, usePolling: true }, function (file, event) {
    reportChange(file.path);
    return gulp.src(paths.style)
      .pipe(browserSync.stream());
  });
});
