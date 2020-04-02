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