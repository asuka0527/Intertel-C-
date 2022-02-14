<template>
  <div class="modal-delete card" v-if="deleteModal">
    <button class="close" @click="deleteModal = false">
      <div id="Icon_box-close" class="Icon_box_close"></div>
    </button>
    　
    <div class="text-align-center">
      <p>本当に削除しますか？</p>
    </div>
    <div class="mt-4 d-flex justify-content-between">
      <button @click="deleteModal = false" class="btn btn-blue">
        削除しない
      </button>
      <button @click="onDeleteClick" class="btn btn-white-2">削除する</button>
    </div>
  </div>
</template>

<style lang="scss">
.loading {
  width: 100%;
  height: 100%;
  background: #000;
  opacity: 0.6;
  z-index: 20001;
  position: fixed;
  top: 1px;
  left: 1px;
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
    background-color: rgba(#000, 0.7);
  }
}
</style>

<script lang="ts">
// import Vue from "vue";
// import Component from "vue-class-component";
import { Vue, Component, Prop, Watch, Emit } from "vue-property-decorator";
import { ApiClient } from "../models/apiClient";

@Component
export default class DeleteComponent extends Vue {
  @Prop({ type: Boolean })
  deleteModal: boolean = false;

  @Prop({ type: Boolean })
  showModal: boolean = false;

  @Prop({ type: Boolean })
  loading: boolean = false;

  @Prop({ type: String })
  deleteUrl: string;

  @Prop()
  id: string;

  private apiClient = new ApiClient(this);

  private async onDeleteClick(): Promise<void> {
    const self = this;
    try {
      self.loading = true;
      let res = await self.apiClient.Delete(self.deleteUrl, {
        id: self.id,
      });
      self.loading = false;
      self.deleteModal = false;
    } catch (err: any) {
      console.log(err);
      self.loading = false;
    }
  }
}
</script>