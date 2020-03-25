<template>
    <div class="app">
        <div class="container">
            <h1>翔天龙狂魔的blog</h1>
            <router-view></router-view>
        </div>
    </div>
</template>
<script>
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
        width:80%;
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
    @media screen and (max-width: 520px) {
    .container{
        width:95%;
    }
}
        @media screen and (min-width: 1000px) {
    .container{
       max-width:865px;
    }
}

</style>