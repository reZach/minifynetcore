var gulp = require('gulp');
var rename = require('gulp-rename');
var minifyCshtml = require('gulp-cshtml-minify');

gulp.task('minify', function (done) {
    gulp.src("Views/**")        
        .pipe(rename({ suffix: ".min" }))
        .pipe(minifyCshtml())
        .pipe(gulp.dest("Views"));

    // Needed for gulp 4.x;
    // https://stackoverflow.com/questions/36897877/gulp-error-the-following-tasks-did-not-complete-did-you-forget-to-signal-async
    done();
});