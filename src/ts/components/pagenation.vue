<template>
  <div class="row">
    <div class="col-sm-12 col-md-5">
      <div
        class="dataTables_info"
        id="table1_info"
        role="status"
        aria-live="polite"
      >全 {{ total }} 件</div>
    </div>
    <div class="col-sm-12 col-md-7">
      <div class="dataTables_paginate paging_simple_numbers" id="table1_paginate" style="text-align: right; margin: 0; float: right;">
        <ul class="pagination">
          <li class="paginate_button page-item" v-bind:class="{disabled: current_page <= 1}">
            <a href="#" class="page-link" @click="_switchIndex(1)">&laquo;</a>
          </li>
          <li
            class="paginate_button page-item previous"
            v-bind:class="{ disabled: current_page <= 1 }"
            id="table1_previous"
          >
            <a
              v-on:click.stop.prevent="_prev()"
              href="#"
              aria-controls="table1"
              data-dt-idx="0"
              tabindex="0"
              class="page-link"
            >前</a>
          </li>

          <li
            class="paginate_button page-item"
            v-for="page in pages"
            :key="page"
            :class="{active: page === current_page}"
          >
            <a
              href="#"
              v-on:click.stop.prevent="_switchIndex(page, $event)"
              aria-controls="table1"
              data-dt-idx="1"
              tabindex="0"
              class="page-link"
            >{{ page }}</a>
          </li>

          <li
            class="paginate_button page-item next"
            v-bind:class="{ disabled: current_page >= last_page }"
            id="table1_next"
          >
            <a
              v-on:click.stop.prevent="_next()"
              aria-controls="table1"
              data-dt-idx="2"
              tabindex="0"
              class="page-link"
            >次</a>
          </li>
          <li
            class="paginate_button page-item"
            v-bind:class="{disabled: current_page >= last_page}"
          >
            <a class="page-link" href="#" @click="_switchIndex(last_page)">&raquo;</a>
          </li>
        </ul>
      </div>
    </div>
  </div>
</template>

<style type="text/css">
</style>

<script lang="ts">
import { Vue, Component, Prop, Watch, Emit } from "vue-property-decorator";

@Component({})
export default class PagenationComponent extends Vue {

  @Prop({ type: Number })
  total!: number;

  @Prop({ type: Number })
  from!: number;

  @Prop({ type: Number })
  to!: number;

  @Prop({ type: Number })
  current_page!: number;

  @Prop({ type: Number })
  last_page!: number;

  get pages(): number[] {
      return this.getPages(this.current_page, this.last_page); 
  }

  @Emit('switchIndex')
  public switchIndex(page: number){
  }
  private _switchIndex(page: number){
      this.switchIndex(page);
  }

  @Emit('prev')
  public prev(page: number){
  }
  private _prev(){
      this.prev(this.current_page - 1);
  }

  @Emit('next')
  public next(page: number){
  }
  private _next(){
      this.next(this.current_page + 1);
  }

  private range(start: number, end: number): number[]{
    var temp_array: number[] = [];
    var length = end -start + 1;

    for (var i = 0; i < length; i++) {
        temp_array.push(i + start);
    }
    return temp_array;
  }

  public getPages(current_page: number, last_page: number): number[]{
      let start = Math.max(current_page - 2, 1);
      let end = Math.min(start + 5, last_page);
      start = Math.max(end - 5, 1)
      return this.range(start, end)
  }
}
</script>