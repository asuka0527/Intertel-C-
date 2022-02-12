<template>
    <div>
        /src/ts/Shop.vue
        <div>
            {{ shop_code }}
        </div>
    </div>
</template>

<style lang="css" scoped>
</style>

<script lang="ts">

    import { Component, Vue, Prop, Emit } from 'vue-property-decorator';
    import axios from 'axios';
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
    export default class Shop extends Vue { 

        private shop_code: string = "";

        mounted(){
            const self = this;

            var hiddenShopCode: any = document.getElementById("shop_code");
            self.shop_code = hiddenShopCode.value;
        }
    }
</script>