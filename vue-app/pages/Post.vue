<template>
    <div>
        <div class="post" v-if="selectedBlog">
            <header><h2>{{selectedBlog.title}}</h2> <span class="tag">{{selectedBlog.tags}}</span></header>
            <time datetime="selectedBlog.createdTime">发布{{formatedCreatedTime}}</time>
            <time datetime="selectedBlog.updatedTime">最后更新{{formatedUpdatedTime}}</time>
            <markdown-it-vue class="md-body" :content="selectedBlog.body" />
        </div>
        <div v-else>正在加载</div>
        <router-link :to="'/'" class="button">返回首页</router-link>

    </div>
</template>
<script>
    import MarkdownItVue from 'markdown-it-vue'
    import 'markdown-it-vue/dist/markdown-it-vue.css'
    import VueX, { mapState, mapActions } from "vuex";
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
        created() {
                        console.log(this.$route.params);
            this.loadBlog(this.$route.params.title);
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
    time{
        font-size:0.8em;
        color:darkgray;
    }
    h2{
        margin:0 0  0.2em 0;
    }
    .tag{
        font-size:0.8em;
         border-radius:1em; 
         padding:0.1em 1em;
         background-color:#90e8e8;
         color:#013c0f;
    }
    .button{
        border-radius:1em; 
        margin-top:0.5em;
        text-decoration:none;
        display:inline-block;
        padding:0.5em;
        background-color:#e9e4f1;
    }
</style>