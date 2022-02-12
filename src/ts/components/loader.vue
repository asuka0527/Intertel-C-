<template>
    <div class="loading">
        <i class="fa fa-spinner fa-spin child"></i>
    </div>
</template>

<style lang="scss">
.loading{
    width: 100%;
    height: 100%;
    background: #000;
    opacity: .6;
    z-index: 20001;
    position: fixed;
    top: 1px;
    left:  1px;
    .child {
        position: absolute;
        top: 50%;
        left: 50%;
        width: 100px;
        height: 100px;
        margin: -50px 0 0 -50px;
        line-height: 100px;
        font-size: 56px;
        color: #fff;
        text-align: center;
        background-color: rgba(#000,.7);
    }
}
</style>

<script lang="ts">
import Vue from "vue";
import Component from "vue-class-component";

@Component
export default class LoaderComponent extends Vue {

}
</script>