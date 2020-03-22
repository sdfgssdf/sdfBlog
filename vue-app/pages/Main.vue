<template>
        <div>
            <router-link class="card" v-for="blog in blogs"  :to="`/${blog.title}`">
                <h2> {{blog.title}}</h2>
                <span class="tag">{{blog.tags}}</span>
            </router-link>
        </div>
</template>
<script>
    import VueX, { mapState } from "vuex";
import VueRouter from "axios";
    export default {
        computed: mapState(["blogs"]),
        created() {
            this.$store.dispatch("loadBlogs");
        }
    };
</script>
<style>

</style>