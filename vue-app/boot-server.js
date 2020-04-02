const serverRender = require("aspnet-prerendering");
const vueRender = require("vue-server-renderer");
const path = require('path');
const fs = require('fs');
const filePath = path.join(__dirname, "../wwwroot/dist/bundle-server.js")
const vueRenderOption = {
    template: fs.readFileSync(path.join(__dirname, "./index.html"),'utf-8')
};
const bundleRender = vueRender.createBundleRenderer(filePath, vueRenderOption);

module.exports = serverRender.createServerRenderer((params) => {
    const context = {
        url: params.url,
        origin:params.origin
    }
    return new Promise((resolve, reject) => {
        bundleRender.renderToString(context, (err, html) => {
            if (err) {
                reject(err);
            }
            resolve({
                html,
                globals: {
                    __INITIAL_STATE__: context.state
                }
            });
        })
    })
})