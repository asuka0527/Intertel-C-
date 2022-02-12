<template>
  <div>
    <form
      asp-action="Search"
      asp-controller="Item"
      method="get"
      style="margin-bottom: 20px"
      class="form-label"
    >
      <div class="row my-4">
        <div class="col-md-6">
          <div class="form-group row">
            <label class="col-sm-4 col-form-label text-left">Serial No</label>
            <div class="col-sm-8">
              <input
                id="datePicker"
                type="date"
                name="ShipDate"
                value='@ViewData["ShipDate"]'
                placeholder="出荷日"
                class="form-control"
              />
            </div>
          </div>
        </div>
        <div class="col-md-6">
          <div class="form-group row">
            <label class="col-sm-4 col-form-label text-left">Model</label>
            <div class="col-sm-8">
              <input
                type="date"
                name="OrderDate"
                value='@ViewData["OrderDate"]'
                placeholder="発注日"
                class="form-control"
              />
            </div>
          </div>
        </div>
        <div class="col-md-6">
          <div class="form-group row">
            <label class="col-sm-4 col-form-label text-left">MacNo1 </label>
            <div class="col-sm-8">
              <input
                type="text"
                name="MacNo1"
                placeholder="MacNo1"
                class="form-control"
              />
            </div>
          </div>
        </div>
        <div class="col-md-6">
          <div class="form-group row">
            <label class="col-sm-4 col-form-label text-left">MacNo2 </label>
            <div class="col-sm-8">
              <input
                type="text"
                name="MacNo2"
                placeholder="MacNo2"
                class="form-control"
              />
            </div>
          </div>
        </div>
        <div class="col-md-6">
          <div class="form-group row">
            <label class="col-sm-4 col-form-label text-left">Status</label>
            <div class="col-sm-8">
              <span>
                <select name="Status" class="form-control" value="">
                  <option value='@ViewData["ProductOf"]'>
                    @ViewData["ProductOf"]
                  </option>
                  <option value="-">なし</option>
                  <option value="北海道">北海道</option>
                  <option value="青森県">青森県</option>
                  <option value="岩手県">岩手県</option>
                  <option value="宮城県">宮城県</option>
                </select>
              </span>
            </div>
          </div>
        </div>
        <div class="col-md-6">
          <div class="form-group row">
            <label class="col-sm-4 col-form-label text-left">InvoiceAt</label>
            <div class="col-sm-8">
              <input
                type="date"
                name="invoiceAt"
                value=""
                class="form-control"
              />
            </div>
          </div>
        </div>
        <div class="col-md-6">
          <div class="form-group row">
            <label class="col-sm-4 col-form-label text-left">SoldAt</label>
            <div class="col-sm-8">
              <input type="date" name="soldAt" value="" class="form-control" />
            </div>
          </div>
        </div>
        <div class="col-md-6">
          <div class="form-group row">
            <label class="col-sm-4 col-form-label text-left">ShippedAt</label>
            <div class="col-sm-8">
              <input
                type="date"
                name="ShippedAt"
                value=""
                class="form-control"
              />
            </div>
          </div>
        </div>
      </div>
      <div class="row justify-content-center">
        <div class="mb-2">
          <button
            style="margin-left: 20px min-width:220px;
    margin-top: 5px;"
            type="submit"
            class="btn btn-lg btn-outline-dark"
          >
            <i class="fas fa-search"></i>Search
          </button>
        </div>
      </div>
    </form>

    <div class="table-responsive">
      <table class="table table-striped table-bordered no-footer dataTable">
        <thead>
          <th></th>
          <th>Serial No</th>
          <th>MacNo</th>
          <th>Model</th>
          <th>Status</th>
          <th>Location</th>
          <th>BoxNo</th>
          <th>Quantity</th>
          <th>Purchase Price</th>
          <th>Retail Price</th>
          <th>Symptom</th>
          <th>Note</th>
          <th>Invoice At</th>
          <th>Sold At</th>
          <th>Shipped At</th>
          <th>Created At</th>
          <th>Updated At</th>
        </thead>
        <tbody>
          <tr v-for="item in items" :key="item.id">
            <td>
              <a
                class="btn btn-sm btn-success"
                :href="'/Item/Detail/?id=' + item.id"
              >
                <i class="fas fa-edit"></i>
                編集
              </a>
              <!-- <button class="btn btn-sm btn-success" @click="getItem">
                <i class="fas fa-edit"></i> 編集
              </button> -->
            </td>
            <td>{{ item.serialNo }}</td>
            <td>
              <div>MacNo1 :{{ item.macNo1 }}</div>
              <div>MacNo2 :{{ item.macNo2 }}</div>
            </td>
            <td>{{ item.model }}</td>
            <td>{{ item.status }}</td>
            <td>{{ item.location }}</td>
            <td>{{ item.boxNo }}</td>
            <td>{{ item.quantity }}</td>
            <td>{{ item.purchasePrice }}</td>
            <td>{{ item.retailPrice }}</td>
            <td>{{ item.symptom }}</td>
            <td>{{ item.note }}</td>
            <td>{{ item.invoiceAt }}</td>
            <td>{{ item.soldAt }}</td>
            <td>{{ item.shippedAt }}</td>
            <td>{{ item.createdAt }}</td>
            <td>{{ item.updatedAt }}</td>
          </tr>
        </tbody>
      </table>
      <PagenationComponent
        :total="pagenateMeta.totalItemCount"
        :current_page="pagenateMeta.pageNumber"
        :last_page="pagenateMeta.pageCount"
        @switchIndex="switchIndex"
        @prev="prev"
        @next="next"
        v-if="pagenateMeta"
      />
      <LoaderComponent v-if="loading" />
      <!-- <button
        type="button"
        class="btn btn-primary"
        data-toggle="modal"
        data-target="#newItemModal"
      >
        New Item
      </button> -->

      <!-- Modal -->
      <!-- <ModalComponent :item = "item"/> -->
      <div
        class="modal fade"
        id="newItemModal"
        tabindex="-1"
        role="dialog"
        aria-labelledby="newItemModalLabel"
        aria-hidden="true"
      >
        <div class="modal-dialog" role="document">
          <div class="modal-content">
            <div class="modal-header">
              <h5 class="modal-title" id="newItemModalLabel">Add Item</h5>
              <button
                type="button"
                class="close"
                data-dismiss="modal"
                aria-label="Close"
              >
                <span aria-hidden="true">&times;</span>
              </button>
            </div>
            <div class="modal-body">
              <form v-on:submit.prevent="submitForm">
                <div class="form-group row">
                  <label class="col-3" for="serialNo">Serial No</label>
                  <div class="col">
                    <input
                      type="text"
                      class="form-control"
                      placeholder="XXXXX-XXXXX"
                      v-model="item.serialNo"
                    />
                  </div>
                </div>
                <div class="form-group row">
                  <label class="col-3" for="macNo1">MacNo1</label>
                  <div class="col">
                    <input
                      id="macNo1"
                      type="text"
                      class="form-control"
                      placeholder="XXXXX-XXXXX"
                      v-model="item.macNo1"
                    />
                  </div>
                </div>
                <div class="form-group row">
                  <label class="col-3" for="macNo2">MacNo2</label>
                  <div class="col">
                    <input
                      id="macNo2"
                      type="text"
                      class="form-control"
                      placeholder="XXXXX-XXXXX"
                      v-model="item.macNo2"
                    />
                  </div>
                </div>
                <div class="form-group row">
                  <label class="col-3" for="model">Model</label>
                  <div class="col">
                    <input
                      type="text"
                      class="form-control"
                      id="model"
                      v-model="item.model"
                      placeholder="Model"
                    />
                  </div>
                </div>
                <!-- <div class="form-group row">
                  <label class="col-3" for="status">Status</label>
                  <div class="col">
                    <input
                      type="text"
                      class="form-control"
                      id="status"
                      v-model="item.status"
                      placeholder="Status"
                    />
                  </div>
                </div> -->
                <div class="form-group row">
                  <label class="col-3" for="location">Location</label>
                  <div class="col">
                    <input
                      type="text"
                      class="form-control"
                      id="location"
                      v-model="item.location"
                      placeholder="Location"
                    />
                  </div>
                </div>
                <div class="form-group row">
                  <label class="col-3" for="boxNo">Box No</label>
                  <div class="col">
                    <input
                      type="text"
                      class="form-control"
                      id="boxNo"
                      v-model="item.boxNo"
                      placeholder="Box No"
                    />
                  </div>
                </div>
                <div class="form-group row">
                  <label class="col-3" for="quantity">Quantity</label>
                  <div class="col">
                    <input
                      type="number"
                      class="form-control"
                      id="quantity"
                      v-model="item.quantity"
                      placeholder="0"
                    />
                  </div>
                </div>
                <div class="form-group row">
                  <label class="col-3" for="purchasePrice"
                    >Purchase Price</label
                  >
                  <div class="col">
                    <input
                      type="number"
                      step="any"
                      class="form-control"
                      id="purchasePrice"
                      v-model="item.purchasePrice"
                      placeholder="1000.00"
                    />
                  </div>
                </div>
                <div class="form-group row">
                  <label class="col-3" for="retailPrice">Retail Price</label>
                  <div class="col">
                    <input
                      type="number"
                      step="any"
                      class="form-control"
                      id="retailPrice"
                      v-model="item.retailPrice"
                      placeholder="1000.00"
                    />
                  </div>
                </div>
                <div class="form-group row">
                  <label class="col-3" for="symptom">Symptom</label>
                  <div class="col">
                    <textarea
                      class="form-control"
                      rows="3"
                      id="symptom"
                      v-model="item.symptom"
                      placeholder="Symptom"
                    />
                  </div>
                </div>
                <div class="form-group row">
                  <label class="col-3" for="note">Note</label>
                  <div class="col">
                    <textarea
                      class="form-control"
                      rows="3"
                      id="note"
                      v-model="item.note"
                      placeholder="Note"
                    />
                  </div>
                </div>
                <div class="form-group row">
                  <label class="col-3" for="invoiceAt">Invoice At</label>
                  <div class="col">
                    <input
                      type="date"
                      class="form-control"
                      id="invoiceAt"
                      v-model="item.invoiceAt"
                    />
                  </div>
                </div>
                <div class="form-group row">
                  <label class="col-3" for="soldAt">Sold At</label>
                  <div class="col">
                    <input
                      type="date"
                      class="form-control"
                      id="soldAt"
                      v-model="item.soldAt"
                    />
                  </div>
                </div>
                <div class="form-group row">
                  <label class="col-3" for="shippedAt">Shipped At</label>
                  <div class="col">
                    <input
                      type="date"
                      class="form-control"
                      id="shippedAt"
                      v-model="item.shippedAt"
                    />
                  </div>
                </div>
                <button type="submit" class="btn btn-primary">Submit</button>
              </form>
            </div>
            <div class="modal-footer">
              <button
                type="button"
                class="btn btn-secondary"
                data-dismiss="modal"
              >
                Close
              </button>
              <button type="button" class="btn btn-primary">
                Save changes
              </button>
            </div>
          </div>
        </div>
      </div>
    </div>
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
import { Item } from "../models/item";
import { PagenateMeta } from "../models/pagenateMeta";
import { ItemSearchParam } from "../models/itemSearchParam";
import * as $ from "jquery";

axios.defaults.headers.common["content-type"] = "application/json";

@Component({
  components: {
    Datepicker,
    VueTimepicker,
    LoaderComponent,
    PagenationComponent,
  },
})
export default class ItemList extends Vue {
  private items: Array<Item> = new Array<Item>();
  private item: Item = new Item();
  private loading: boolean = true;
  private query_page: number = 1;
  private pagenateMeta: PagenateMeta | null = null;
  private searchParam: ItemSearchParam = new ItemSearchParam();
  private showModal: boolean = false;

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
      .get("/ItemApi/Search", { params: self.searchParam })
      .then(function (res: any) {
        console.log({ searchRes: res });
        self.items = res.data.data;
        self.pagenateMeta = res.data.metaData;
        console.log({ items: self.items });
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

      let res = await axios.post(
        "/ItemApi/Create",
        self.item,
        // { params: self.searchParam },
        {
          validateStatus: function (status) {
            return status < 401;
          },
        }
      );

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
  private async editItem(): Promise<void> {
    const self = this;
    try {
      self.loading = true;
      let res = await axios.put(`ItemApi/Edit/${self.item.id}`, {
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
  private async getItem(id: string): Promise<void> {
    const self = this;
    self.loading = true;
    axios
      .get(`/Item/Detail/${id}`)
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