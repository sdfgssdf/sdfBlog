<template>
    <div class="app">
        <div class="container">
            <h1>翔天龙狂魔的blog</h1>
            <router-view></router-view>
        </div>
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
        justify-content:center;
    }
    .container{
        min-width: 780px;
        max-width:880px;
    }
    h1{
        margin-left:2rem;
        color:#c142a0;
    }
    .card, .post {
        display: block;
        margin-top: 0.5rem;
        padding: 0.5rem;
        background-color: azure;
        box-shadow: 0 1px 2px #444;
        text-decoration: none;
        color: black;
    }
</style>