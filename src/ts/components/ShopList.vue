<template>
    <div>
        /src/ts/ShopList.vue

        <table>
            <tr>
                <td>
                    <a href="/shops/1234">
                    1234
                    </a>
                </td>
                <td>
                    xxxx
                </td>
            </tr>
            <tr>
                <td>
                    <a href="/shops/4567">
                    4567
                    </a>
                </td>
                <td>
                    oooo
                </td>
            </tr>
        </table>
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
    export default class ShopList extends Vue { 

    }
</script>