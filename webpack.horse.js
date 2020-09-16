const path = require('path');
const BrowserSyncPlugin = require('browser-sync-webpack-plugin');

module.exports = {
    mode: 'development',
    entry: { styles: './assets/sass/styles.scss' },
    output: {
        path: path.resolve(__dirname, "wwwroot"),
        filename: "horse.js",
        publicPath: "/"
    },
    devtool: "source-map",
    module: {
        rules: [{
            test: /\.scss$/,
            use: [{
                loader: 'style-loader'
            }, {
                loader: "css-loader", options: {
                    sourceMap: true,
                    minimize: true
                }
            }, {
                loader: "sass-loader", options: {
                    sourceMap: true,
                    minimize: true
                }
            }]
        }],
    },
    plugins: [
        new BrowserSyncPlugin({
            proxy: 'http://localhost:5000',
            files: [
                //   'wwwroot/css/styles.css',
                //   'wwwroot/js/site.js',
                'Pages/**/*.cshtml',
                'Views/**/*.cshtml',
            ]
        },
            {
                // prevent BrowserSync from reloading the page
                // and let Webpack Dev Server take care of this
                reload: false
            })
    ]
};