const path = require('path');
const VueLoaderPlugin = require("vue-loader/lib/plugin");


module.exports = {
    mode: 'production',
    entry: { 
        main: './vue-app/main.js',
    },
    output: {      
        publicPath: 'what', 
        path: path.resolve(__dirname, 'wwwroot/dist'),
        filename: 'bundle.js'
    },
    module: {
        rules: [
            {
                test: /\.vue$/,
                use: {
                    loader: 'vue-loader'
                }
            }, {
                test: /\.css$/,
                use: ['vue-style-loader','css-loader'
                ]
            },
        ]
    },
    plugins: [
        new VueLoaderPlugin()
    ]
};