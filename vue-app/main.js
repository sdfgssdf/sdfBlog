import Vue from "vue";
import App from "./App.vue";
import Axios from "axios";
import VueX from "vuex";
import VueRouter from "vue-router";
import Main from "./pages/Main.vue";
import Post from "./pages/Post.vue";
Vue.use(VueX);
Vue.use(VueRouter);
var store =new VueX.Store({
    state: {
        blogs: [],
        selectedBlog: null
    },
    mutations: {
        saveBlogs(state, blogs) {
            state.blogs = blogs
    },
        saveBlog(state, blog) {
        state.selectedBlog = blog},
        clearBlog(state) {
            state.selectedBlog = null
        }
    },
    actions: {
        loadBlogs({ commit }) {
            Axios.get("/blog").then(res => {
               commit("saveBlogs",res.data);
            })
        },
        loadBlog({ commit }, title) {
            Axios.get(`/blog/${title}`).then(res => {
                commit("saveBlog", res.data);
            })
        }
    }
});
var router =new VueRouter({
    mode: 'history',
    routes: [{
        path: '/',
        component:Main
    }, {
            path: '/:title',
            component: Post
        }]

});
var app = new Vue(
    {
        store,
        router,
        render: h => h(App)
    }

);
app.$mount("#app");