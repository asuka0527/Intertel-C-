<template>
    <div>
        /src/ts/Home.vue

        <ul>
            <li>
                <a href="/shops">
                    店舗管理
                </a>
            </li>
        </ul>
    </div>
</template>

<style lang="css" scoped>
</style>

<script lang="ts">

    import { Component, Vue, Prop, Emit } from 'vue-property-decorator';
    import axios from 'axios';
    import QueryString from 'query-string';
    import moment from 'moment';
    import * as qs from 'qs';
    import Datepicker from 'vuejs-datepicker';
    import VueTimepicker from 'vue2-timepicker';
    import { ja } from 'vuejs-datepicker/dist/locale';
    //import { env } from '../config/env_loader';

    @Component({
        components: {
            Datepicker,
            VueTimepicker,
        }
    })
    export default class Home extends Vue { 

    }
</script>