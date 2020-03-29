import Vue from "vue";
import App from "./App.vue";
import Axios from "axios";
import VueX from "vuex";
import VueRouter from "vue-router";
import Main from "./pages/Main.vue";
import Post from "./pages/Post.vue";
Vue.use(VueX);
Vue.use(VueRouter);
export const createApp = () => {
    const store = new VueX.Store({
        state: {
            blogs: [],
            selectedBlog: null
        },
        mutations: {
            saveBlogs(state, blogs) {
                state.blogs = blogs
            },
            saveBlog(state, blog) {
                state.selectedBlog = blog
            },
            clearBlog(state) {
                state.selectedBlog = null
            }
        },
        actions: {
            loadBlogs({ commit }, origin) {
                if (origin === null || origin === undefined) {
                    origin = '';
                }
                return Axios.get(`${origin}/blog`).then(res => {
                    commit("saveBlogs", res.data);
                }).catch(err => {
                    console.log(err);
                })
            },
            loadBlog({ commit }, { title, origin }) {
                if (origin === null || origin === undefined) {
                    origin = '';
                }
                return Axios.get(`${origin}/blog/${title}`).then(res => {
                    commit("saveBlog", res.data);
                }).catch(err => {
                    console.log(err);
                }
                );
            }
        }
    });
    const router = new VueRouter({
        mode: 'history',
        routes: [{
            path: '/',
            component: Main
        }, {
            path: '/:title',
            component: Post
        }]

    });
    const app = new Vue(
        {
            store,
            router,
            render: h => h(App)
        }

    );
    return {
        app, router, store
    }
}