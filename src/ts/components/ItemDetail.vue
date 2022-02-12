<template>
  <div>
    <div class="row" v-if="item">
      <div class="col">
        <h2>Item</h2>
        <form>
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
            <label class="col-3" for="purchasePrice">Purchase Price</label>
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
                type="datetime-local"
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
                type="datetime-local"
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
                type="datetime-local"
                class="form-control"
                id="shippedAt"
                v-model="item.shippedAt"
              />
            </div>
          </div>
          <button
            type="submit"
            @click.prevent="onSaveAsync"
            class="btn btn-primary"
          >
            Submit
          </button>
        </form>
      </div>
      <div class="col">
        <h2>Dispositions</h2>
        <div class="table-responsive">
          <table class="table table-striped table-bordered no-footer dataTable">
            <thead>
              <th>DispositionNo</th>
              <th>Shipped At</th>
              <th>Shipped From</th>
              <th>Note</th>
              <th></th>
            </thead>
            <tbody>
              <tr v-for="dis in item.dispositions" :key="dis.dispositionNo">
                <td>
                  <input
                    class="form-control"
                    type="text"
                    v-model="dis.dispositionNo"
                  />
                </td>
                <td>
                  <input
                    class="form-control"
                    type="datetime-local"
                    v-model="dis.shippedAt"
                  />
                </td>
                <td>
                  <input
                    class="form-control"
                    type="text"
                    v-model="dis.shippedFrom"
                  />
                </td>
                <td>
                  <textarea
                    class="form-control"
                    type="text"
                    v-model="dis.note"
                  />
                </td>
                <td>
                  <button
                    class="btn btn-sm btn-info"
                    @click.prevent="onRemoveDispostionClick(dis)"
                  >
                    remove
                  </button>
                </td>
              </tr>
            </tbody>
          </table>
          <div class="form-group">
            <button
              class="btn btn-sm btn-info"
              @click.prevent="onAddDispostionClick"
            >
              add
            </button>
          </div>
        </div>
      </div>
    </div>
    <div v-else>Loading</div>
    <LoaderComponent v-if="loading" />
  </div>
</template>

<script lang="ts">
import { Vue, Component, Prop, Watch } from "vue-property-decorator";
import LoaderComponent from "./loader.vue";
import { Item } from "../models/item";
import { Disposition } from "../models/disposition";
import axios from "axios";
import * as $ from "jquery";
import qs from "qs";

@Component({
  components: {
    LoaderComponent,
  },
})
export default class ItemDetailComponent extends Vue {
  private query_item_id: string | null = "";
  private item: Item | null = null;
  private disposition: Disposition | null = null;
  private dispositions: Array<Disposition> = new Array<Disposition>();
  private loader: boolean = true;
  private loading: boolean = true;

  mounted() {
    const self = this;
    var query = qs.parse(location.search.substr(1));
    if (query.id) {
      self.query_item_id = query.id.toString();
    }
    self.find();
  }

  private async find(): Promise<void> {
    const self = this;
    try {
      var params: any = {
        id: self.query_item_id,
      };
      var findRes = await axios.get("/ItemApi/Find", { params: params });
      self.item = findRes.data.item;

      // self.appUser = findRes.data.user;

      console.log({
        getitem: self.item,

        // getUser: self.appUser,
      });
    } catch (err) {
      console.log({ loadErr: err });
    } finally {
      self.loading = false;
    }
  }

  private async onSaveAsync(): Promise<void> {
    const self = this;

    try {
      self.loading = true;

      if (self.item!.dispositions == null) {
        self.item!.dispositions = new Array<Disposition>();
      }

      let res = await axios.post("/ItemApi/Save", self.item, {
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

      self.loading = false;
    } catch (err) {
      console.log(err);
      self.loading = false;
    }
  }
  private async onAddDispostionClick() {
    const self = this;

    if (self.item!.dispositions == null) {
      self.item!.dispositions = new Array<Disposition>();
    }
    let disposition = new Disposition();
    self.item!.dispositions.push(disposition);
    console.log("disposition", disposition);
  }

  private async onRemoveDispostionClick(disposition: Disposition) {
    const self = this;
    self.item!.dispositions = self.item!.dispositions!.filter(
      (d) => d !== disposition
    );
  }
}
</script>
