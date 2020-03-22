<template>
    <div class="app">
        <h1>翔天龙狂魔的blog</h1>
        <router-view></router-view>
    </div>
</template>
<script>
    import Axios from "axios";
    export default {
    }
</script>
<style>
    html{
        background-color:bisque;
    }
    .app{
        display:flex;
        flex-direction:column;
        justify-content:center;
    }
    .card , .post{
        display:block;
        margin-top:0.5rem;
        padding:0.5rem;
        background-color:azure;
        box-shadow:0 1px 2px #444;
        text-decoration:none;
        color:black;
    }
</style>