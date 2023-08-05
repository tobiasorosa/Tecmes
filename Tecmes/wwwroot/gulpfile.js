/* eslint-disable eol-last */
/* eslint-disable import/no-extraneous-dependencies */

const gulp = require('gulp');
const sass = require('gulp-sass')(require('sass'));
const rename = require('gulp-rename');
const babel = require('gulp-babel');
const concat = require('gulp-concat');
const terser = require('gulp-terser');
const webpack = require('webpack-stream');

gulp.task('js', () => gulp.src('assets/js/*.js')
  .pipe(babel({ presets: ['@babel/preset-env'] }))
  .pipe(concat('bundle.js'))
  .pipe(terser())
  .pipe(gulp.dest('dist/js')));

gulp.task('sass', () => gulp.src('assets/css/*.scss')
  .pipe(sass({ outputStyle: 'compressed' }).on('error', sass.logError))
  .pipe(rename({ extname: '.min.css' }))
  .pipe(gulp.dest('dist/styles')));

gulp.task('watch', () => {
  gulp.watch('assets/css/*.scss', gulp.series('sass'));
  gulp.watch('assets/js/*.js', gulp.series('js-webpack'));
});

gulp.task('js-webpack', () => gulp.src('assets/js/*.js') // Adjust 'assets/js/entry.js' to your entry file.
    .pipe(webpack({
        mode: 'development', // or 'development' for development mode
        output: {
            filename: 'bundle.js', // Output filename
        },
        module: {
            rules: [
                {
                    test: /\.js$/,
                    exclude: /node_modules/,
                    use: {
                        loader: 'babel-loader',
                        options: {
                            presets: ['@babel/preset-env'],
                        },
                    },
                },
            ],
        },
        resolve: {
            extensions: ['.js', '.json'], // Add any other extensions you use in your project.
        },
    }))
    .pipe(gulp.dest('dist/js')));

gulp.task('default', gulp.series('sass', 'js'));
gulp.task('default-webpack', gulp.series('sass', 'js-webpack'));