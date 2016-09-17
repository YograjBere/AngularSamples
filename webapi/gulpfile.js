/// <binding Clean='clean-dev, serve' />
var gulp = require('gulp'),
    bower = require('bower');


var concat = require('gulp-concat'),
    ngAnnotate = require('gulp-ng-annotate'),
    karma = require('karma').server,
    del = require('del'),
    inject = require('gulp-inject'),
    bowerFiles = require('main-bower-files'),
    Q = require('q'),
    plumber = require('gulp-plumber'),
    browserSync = require('browser-sync'),
    runSequence = require('run-sequence'),
    order = require("gulp-order");

var paths = {
    scripts: ['src/app/**/*.module.js', 'src/app/**/*.js', '!src/app/**/*.spec.js'],
    styles: './src/assets/**/**/_*.css',
    index: './src/index.cshtml',
    partials: ['src/app/**/*.tpl.html', '!src/index.cshtml'],
    distDev: './dist.dev',
    distContentDev: './dist.dev/content',
    distVendorDev: './dist.dev/vendor',
    distScriptsDev: './dist.dev/app',
    distIndex: './Views/Home'
};

// Tasks
gulp.task('test', function (done) {
    karma.start({
        configFile: __dirname + '/karma.config.js',
        singleRun: true
    }, function () {
        done();
    });
});

/**
 * Creates index.html file in development distribution path
 */
gulp.task('index-dev', function () {
    return gulp.src(paths.index)
        .pipe(plumber({
            errorHandler: function (err) {
                console.log(err);
                this.emit('end');
            }
        }))
        .pipe(gulp.dest(paths.distDev));
});

gulp.task('vendor-dev', function () {
    return gulp.src(bowerFiles())
        .pipe(gulp.dest(paths.distVendorDev));
});

/**
 * Compiles project application scripts into the development distribustion location
 */
gulp.task('scripts-dev', function () {
    return gulp.src(paths.scripts)
        .pipe(plumber({
            errorHandler: function (err) {
                console.log(err);
                this.emit('end');
            }
        }))
        .pipe(ngAnnotate())
        .pipe(gulp.dest(paths.distScriptsDev))
});

/**
 * Processes application css to dev dist path
 */
gulp.task('css-dev', function () {
    return gulp.src(paths.styles)
        .pipe(plumber({
            errorHandler: function (err) {
                console.log(err);
                this.emit('end');
            }
        }))
        .pipe(gulp.dest(paths.distContentDev));
});

/**
 * Copies html partials files to dev dist path
 */
gulp.task('html-dev', function () {
    return gulp.src(paths.partials)
        .pipe(plumber({
            errorHandler: function (err) {
                console.log(err);
                this.emit('end');
            }
        }))
        .pipe(gulp.dest(paths.distScriptsDev));
});

/**
 * Updates the index.html file
 * with all the injections
 */
gulp.task('inject-dev', ['create-dev'], function () {

    return gulp.src(paths.index)
        .pipe(plumber({
            errorHandler: function (err) {
                console.log(err);
                this.emit('end');
            }
        }))
        .pipe(gulp.dest(paths.distDev))
        .pipe(inject(gulp.src([paths.distScriptsDev + '/**/*.module.js', paths.distScriptsDev + '/**/*.js'], { read: false }), { relative: false, name: '' }))
        .pipe(inject(gulp.src('./dist.dev/vendor/*.js', { read: false }).pipe(order([
                    'jquery.js',
                    'boostrap.js',
                    'angular.js',
                    'angular-ui-router.js',
                    '*'
        ])), { name: 'bower', relative: false }))
        .pipe(inject(gulp.src('./dist.dev/vendor/*.css', { read: false }), { name: 'bower', relative: false }))
        .pipe(inject(gulp.src(paths.distContentDev + '/**/*.css', { read: false }), { relative: false }))
        .pipe(gulp.dest(paths.distDev))
        .pipe(gulp.dest(paths.distIndex));


});

/**
* Move index file into Views
*/
gulp.task('copy-index', function () {
    return gulp.src(paths.index).pipe(gulp.dest(paths.distIndex));
});

/**
 * Creates development environment for testing
 */
gulp.task('create-dev', ['index-dev', 'vendor-dev', 'css-dev', 'html-dev', 'scripts-dev']);


/**
 * Builds a development distribution
 */
gulp.task('build-dev', ['inject-dev']);

/**
 * Removes all of dev dist files
 */
gulp.task('clean-dev', function () {
    var deferred = Q.defer();
    del(paths.distDev, function () {
        deferred.resolve();
    });
    return deferred.promise;
});

/**
* Install bower components
*/
gulp.task('install-bower', function (cb) {
    bower.commands.install([], { save: true }, {})
    .on('end', function (installed) {
        cb(); // notify gulp that this task is finished
    });
});

/**
* Default Task for VS
*/
gulp.task('default', function (cb) {
    runSequence('clean-dev', 'install-bower', 'build-dev', cb);
});

/**
 * Watches for file changes and rebuilds a development distribustion on change
 */

gulp.task('reload:browsersync', function (cb) {
    runSequence(['build-dev'], function () {
        browserSync.reload();
        cb();
    });
});

gulp.task('watch-dev', function () {
    gulp.watch([paths.scripts, paths.partials, paths.styles, paths.index], ['reload:browsersync']);
});

/**
 * Runs a static webserver for development files
 */
gulp.task('serve', ['watch-dev'], function (cb) {

    function startBrowserSync() {
    browserSync({
        proxy: 'localhost:54858',
        port: 3000,
        ghostMode: false,
        reloadDelay: 500
    });

    }

    startBrowserSync();

    cb();
});