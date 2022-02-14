<template>
  <div class="modal-vue">
    <div class="page-title-box mB-3">
      <h4 class="page-title">Status List</h4>
      <hr />
    </div>

    <div class="d-flex justify-content-between"></div>
    <ValidationObserver ref="observer" v-slot="ObserverProps">
      <div class="card bR-2 p-2">
        <div class="card-header-radius d-flex">
          <div class="col-3">名前</div>
          <div class="col">ユーザーID</div>
        </div>
        <div v-for="status in statuses" :key="status.id">
          <div class="card-detail-office">
            <div class="col-3" style="margin-left: 30px">
              <span v-show="!status.isEditable">{{ status.name }} </span>
              <input
                v-show="status.isEditable"
                type="text"
                class="form-control f-input"
                v-model="status.name"
              />
            </div>
            <div class="col-2">
              <button
                v-show="!status.isEditable"
                class="card-link"
                v-on:click="onEditClick(status)"
              >
                編集
                <!-- <span >編集</span> -->
                <!-- <span v-show="status.isEditable">確定</span> -->
              </button>
              <button
                v-show="status.isEditable"
                class="card-link"
                v-on:click="onConfirmClick(status)"
              >
                確定
              </button>
              <div id="mail_trash_ir" class="mail_trash header-icon-box-card">
                <div v-if="showModal">
                  <DeleteComponent
                    :deleteModal="deleteModal"
                    :showModal="showModal"
                    :deleteUrl="deleteUrl"
                    :loading="loading"
                    :id="status.id"
                  />
                </div>
              </div>
              <button class="btn" @click="onHandleDelete(status.id)"></button>
            </div>
          </div>
        </div>

        <div class="d-flex justify-content-end mT-2">
          <!-- <button class="btn btn-sm btn-info" @click.prevent="">add</button> -->
          <button class="card-link" @click="createModal = true">
            New Status
          </button>
        </div>
      </div>
    </ValidationObserver>

    <LoaderComponent v-if="loading" />
  </div>
</template>

<style lang="css" scoped>
</style>

<script lang="ts">
import { Component, Vue, Prop, Emit } from "vue-property-decorator";
import axios from "axios";
import QueryString from "query-string";
import moment from "moment";
import * as qs from "qs";
import Datepicker from "vuejs-datepicker";
import VueTimepicker from "vue2-timepicker";
import { ja } from "vuejs-datepicker/dist/locale";
//import { env } from '../config/env_loader';
import LoaderComponent from "./loader.vue";
import PagenationComponent from "./pagenation.vue";
import { Status } from "../models/status";
import { PagenateMeta } from "../models/pagenateMeta";
import DeleteComponent from "./deleteModal.vue";

import { ItemSearchParam } from "../models/itemSearchParam";
import * as $ from "jquery";
import {
  ValidationObserver,
  ValidationProvider,
  extend,
  localize,
} from "vee-validate";
import { required, email, max } from "vee-validate/dist/rules";

axios.defaults.headers.common["content-type"] = "application/json";

@Component({
  components: {
    Datepicker,
    VueTimepicker,
    LoaderComponent,
    PagenationComponent,
    ValidationObserver,
    ValidationProvider,
    DeleteComponent,
  },
})
export default class StatusList extends Vue {
  private statuses: Array<Status> = new Array<Status>();
  private status: Status = new Status();
  private loading: boolean = true;
  private query_page: number = 1;
  private pagenateMeta: PagenateMeta | null = null;
  private searchParam: ItemSearchParam = new ItemSearchParam();
  private showModal: boolean = false;
  private deleteModal: boolean = false;

  mounted() {
    const self = this;
    console.log(self.showModal);
    var query = qs.parse(location.search.substr(1));
    console.log(query);
    if (query.page) {
      self.query_page = Number(query.page);
    }
    self.search(self.query_page);
  }

  private search(page: number): void {
    const self = this;

    self.searchParam.page = page;

    if (window.history && window.history.pushState) {
      window.history.pushState(
        { name: "search" },
        "",
        "?" + $.param(self.searchParam)
      );
    }

    self.loading = true;
    axios
      .get("/StatusApi/Search", { params: self.searchParam })
      .then(function (res: any) {
        console.log({ searchRes: res });
        self.statuses = res.data.data;
        self.pagenateMeta = res.data.metaData;
        console.log({ statuses: self.statuses });
      })
      .catch(function (err: any) {})
      .then(function () {
        self.loading = false;
      });
  }

  private onSearchClick(): void {
    const self = this;
    self.search(1);
  }

  private prev(page: number): void {
    this.search(page);
  }

  public switchIndex(selectedIndex: number): void {
    this.search(selectedIndex);
  }

  private next(page: number): void {
    this.search(page);
  }
  private print(): void {
    console.log("clicked");
  }
  private async submitForm(): Promise<void> {
    const self = this;

    try {
      self.loading = true;

      let res = await axios.post("/StatusApi/Create", self.status, {
        validateStatus: function (status) {
          return status < 401;
        },
      });

      if (res.status) {
        if (res.status == 400) {
          alert(res.data.errors.Name[0]);
          console.log(res.data.errors);
        }
      }
      setTimeout("location.reload()", 1000);
      self.loading = false;
    } catch (err) {
      console.log(err);
      self.loading = false;
    }
  }
  private async editStatus(): Promise<void> {
    const self = this;
    try {
      self.loading = true;
      let res = await axios.put(`StatusApi/Edit/${self.status.id}`, {
        validateStatus: function (status) {
          return status < 401;
        },
      });
      if (res.status) {
        if (res.status == 400) {
          alert(res.data.errors.Name[0]);
          console.log(res.data.errors);
          self.loading = false;
        }
      }
    } catch (error) {
      console.log(error);
      self.loading = false;
    }
  }
  private async getStatus(id: string): Promise<void> {
    const self = this;
    self.loading = true;
    axios
      .get(`/Status/Detail/${id}`)
      .then(function (res: any) {
        console.log(res);
      })
      .catch(function (err: any) {})
      .then(function () {
        self.loading = false;
      });
  }
}
</script>