<template>
    <div class="post" v-if="selectedBlog">
        <header>
            <h2>{{selectedBlog.title}}</h2>
            <span class="tag">{{selectedBlog.tags}}</span>
            <br />
            <time datetime="selectedBlog.createdTime">发布{{formatedCreatedTime}}</time>
            <time datetime="selectedBlog.updatedTime">最后更新{{formatedUpdatedTime}}</time>
        </header>
    <markdown-it-vue class="md-body" :content="selectedBlog.body" />
            <router-link :to="'/'" class="button">返回首页</router-link>
</div>
    <div v-else>正在加载</div>
</template>
<script>
    import MarkdownItVue from 'markdown-it-vue-simplify'
    import 'markdown-it-vue-simplify/dist/markdown-it-vue-simplify.css'
    import { mapState, mapActions } from "vuex";
    export default {
        components: {
            MarkdownItVue
        },
        computed: {
            ...mapState(["selectedBlog"]),
            formatedCreatedTime() {
                return this.formateTime(this.selectedBlog.createdTime);
            },
            formatedUpdatedTime() {
                return this.formateTime(this.selectedBlog.updatedTime);
            },
        },
        mounted() {
            if (!this.selectedBlog) {
                this.$store.dispatch("loadBlog", { title: this.$route.params.title });
            };
        },
        methods: {
            ...mapActions(["loadBlog"]),
            formateTime(isoString) {
                const option = {
                    year: 'numeric', month: 'long', day: '2-digit',
                    hour: '2-digit', minute: '2-digit'
                };
                const date = new Date(isoString);
                return new Intl.DateTimeFormat("zh-cn", option).format(date);
            }
        },
        beforeRouteLeave(to, from, next) {
            this.$store.commit("clearBlog");
            next();
        }
    };
</script>
<style>
    header {
        margin-bottom: 2rem;
    }

    .post {
        padding-left: 2rem;
    }

    time {
        font-size: 0.8em;
        color: darkgray;
    }

    h2 {
        margin: 0 0 0.2em 0;
    }

    .tag {
        font-size: 0.8em;
        border-radius: 1em;
        padding: 0.1em 1em;
        background-color: #90e8e8;
        color: #013c0f;
    }

    .button {
        margin-top: 3rem;
        border-radius: 1em;
        text-decoration: none;
        display: inline-block;
        padding: 0.5em;
        background-color: #e9e4f1;
        max-width: 780px;
    }
</style>