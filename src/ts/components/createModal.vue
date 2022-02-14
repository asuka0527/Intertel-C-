<template>
  <div class="modal-v card" v-if="createModal">
    <button class="close" @click="createModal = false">
      <div id="Icon_box-close" class="Icon_box_close">
        <svg class="Icon_ionic-ios-close-circle" viewBox="3.375 3.375 14 14">
          <path
            id="Icon_ionic-ios-close-circle"
            d="M 10.375 3.375 C 6.508172988891602 3.375 3.375 6.508172988891602 3.375 10.375 C 3.375 14.24182891845703 6.508172988891602 17.375 10.375 17.375 C 14.24182891845703 17.375 17.375 14.24182891845703 17.375 10.375 C 17.375 6.508172988891602 14.24182891845703 3.375 10.375 3.375 Z M 12.14855670928955 12.90913677215576 L 10.375 11.13557624816895 L 8.601441383361816 12.90913677215576 C 8.392787933349609 13.11779022216797 8.049519538879395 13.11779022216797 7.840865135192871 12.90913677215576 C 7.736538410186768 12.80480861663818 7.682692050933838 12.66682815551758 7.682692050933838 12.52884578704834 C 7.682692050933838 12.39086532592773 7.736538410186768 12.25288486480713 7.840865135192871 12.14855670928955 L 9.614421844482422 10.375 L 7.840865135192871 8.601441383361816 C 7.736538410186768 8.497115135192871 7.682692050933838 8.359134674072266 7.682692050933838 8.22115421295166 C 7.682692050933838 8.083173751831055 7.736538410186768 7.945191383361816 7.840865135192871 7.840866565704346 C 8.049519538879395 7.632211685180664 8.392787933349609 7.632211685180664 8.601441383361816 7.840866565704346 L 10.375 9.614423751831055 L 12.14855670928955 7.840866565704346 C 12.35721206665039 7.632211685180664 12.70048046112061 7.632211685180664 12.90913391113281 7.840866565704346 C 13.1177864074707 8.049519538879395 13.1177864074707 8.392787933349609 12.90913391113281 8.601443290710449 L 11.13557624816895 10.375 L 12.90913677215576 12.14855670928955 C 13.11779022216797 12.35721206665039 13.11779022216797 12.70048236846924 12.90913677215576 12.90913677215576 C 12.70048046112061 13.12115478515625 12.35721206665039 13.12115478515625 12.14855670928955 12.90913677215576 Z"
          ></path>
        </svg>
      </div>
    </button>
    <h5 class="d-flex justify-content-center">New Status</h5>
    　
    <!-- <div class="card-detail-office">
      <div class="col-4">
        <label for="name">Name</label>
      </div>
      <div class="col">
        <span>
          <ValidationProvider
            v-slot="{ errors, valid }"
            name="Name"
            rules="required"
          >
            <input
              type="text"
              class="form-control f-input"
              :class="{ has_error_input: !valid }"
              id="name"
              placeholder="例）佐藤太郎"
              v-model="user.name"
            />
            <label v-if="!valid" class="has_error_label">{{ errors[0] }}</label>
          </ValidationProvider>
          </span>
      </div>
    </div> -->

    <div class="mt-4 d-flex justify-content-center">
      <button @click="onCreateClick()" class="btn btn-blue">Register</button>
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

  @Prop()
  model: any;

  @Prop({ type: String })
  createUrl: string;
  
  private apiClient = new ApiClient(this);

  private async onCreateClick(model: any): Promise<void> {
    const self = this;
    try {
      self.loading = true;
      let res = await self.apiClient.Post(
        self.createUrl,
        model,
        "登録しました"
      );

      self.loading = false;
    } catch (err: any) {
      console.log(err);
      self.loading = false;
    }
  }
}
</script>