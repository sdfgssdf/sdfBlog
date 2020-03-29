<template>
    <div>
        <router-link class="card" v-for="blog in blogs" :to="`/${blog.title}`">
            <h2> {{blog.title}}</h2>
            <span class="tag">{{blog.tags}}</span>
        </router-link>
    </div>
</template>
<script>
    import { mapState } from "vuex";
    export default {
        loadAsync({ store, origin }) {
            return store.dispatch("loadBlogs", origin);
        },
        meta(state) {
            return {
                title: "翔天龙狂魔的blog",
                description: "个人博客",
                keywords: "博客 JavaScript blog"
            }
        },
        computed: mapState(["blogs"]),
        mounted() {
            if (this.blogs.length < 1) {
                this.$store.dispatch("loadBlogs");
            };
        }
    };
</script>
<style>
</style>