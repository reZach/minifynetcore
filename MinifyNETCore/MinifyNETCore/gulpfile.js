var gulp = require('gulp');
var rename = require('gulp-rename');
var minifyCshtml = require('gulp-cshtml-minify');
var del = require('del');

gulp.task('del', function (done) {

    // delete pre-existing .min.cshtml files
    del(["Views/**/*.min.cshtml"]);

    done();
});

gulp.task('minify', function (done) {    

    // create new .min.cshtml files
    gulp.src("Views/**/*.cshtml")        
        .pipe(rename({ suffix: ".min" }))
        .pipe(minifyCshtml())
        .pipe(gulp.dest("Views"));

    done();
});

// run this task to minify your .cshtml files
gulp.task('cshtml', gulp.series('del', 'minify'), function (done) {
    done();
});