<template>
<div><div v-if ="item"></div>
<div v-else>
  Loading
</div>
  <LoaderComponent v-if="loading" />
</div>
</template>

<script lang="ts">
import { Vue, Component, Prop, Watch } from "vue-property-decorator";
import LoaderComponent from "./loader.vue";
import { Item } from "../models/item";

@Component({
  components: {
    LoaderComponent,
  },
})
export default class ItemCreateComponent extends Vue {
  private query_item_id: string | null = "";
  private item: Item | null = null;
  private loader: boolean = true;

  mounted() {
    const self = this;
    
console.log(self.item)
  }
}
</script>
