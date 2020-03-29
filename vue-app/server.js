import { createApp } from "./main.js";
export default function (context) {
    const { router, store, app } = createApp();

    return new Promise((resolve, reject) => {
        const { url, origin } = context;
        router.push(url);

        router.onReady(() => {
            const components = router.getMatchedComponents();
            Promise.all(components.map(
                async  component => {
                    if (component.loadAsync) {
                        const params = router.app.$route.params;
                        await component.loadAsync({ store, origin, params });
                    }
                    if (component.meta) {
                        const { title, description, keywords } = component.meta(store.state);
                        context.title = title;
                        context.meta = `<meta name="description" content="${description}">
                                        <meta name="keywords" content="${keywords}">`;
                    };

                }
            )).then(() => {
                context.state = store.state;
                resolve(app);
            });
        });
    });
}