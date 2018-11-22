var gulp = require('gulp');
var rename = require('gulp-rename');
var minifyCshtml = require('gulp-cshtml-minify');

gulp.task('minify', function () {
    gulp.src("Views/**")
        .pipe(minifyCshtml())
        .pipe(rename({ suffix: ".min" }))
        .pipe(gulp.dest("~/Views/pie"));
});