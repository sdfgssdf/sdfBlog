import { createApp } from "./main.js"; 
const { router, store, app } = createApp();

if (window.__INITIAL_STATE__) {
    store.replaceState(window.__INITIAL_STATE__);
}
router.onReady(() => {
    app.$mount('#app')
});


