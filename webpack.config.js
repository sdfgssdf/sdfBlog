const path = require('path');
const VueLoaderPlugin = require("vue-loader/lib/plugin");
const merge = require('webpack-merge')

module.exports = (env) => {
    const sharedConfig = () => { return{
        mode: 'development',
        output: {
            publicPath: 'what',
            path: path.resolve(__dirname, 'wwwroot/dist')
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
                    use: ['vue-style-loader', 'css-loader'
                    ]
                },
            ]
        },
        plugins: [
            new VueLoaderPlugin()
        ]
    };
    } 
    const serverConfig = merge(sharedConfig(), {
        target: 'node',
        entry: {
            bundle: './vue-app/server.js',
        }, output: {
            libraryTarget: "commonjs2",
            filename: '[name]-server.js'
        },
    });
    const clientConfig = merge(sharedConfig(), {
        entry: {
            bundle: './vue-app/client.js',
        }, output: {
            filename: '[name]-client.js'
        },
    });

    return [serverConfig, clientConfig];
}
 