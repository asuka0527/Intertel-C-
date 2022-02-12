import { Vue } from "vue-property-decorator";
import axios, { AxiosResponse } from "axios";
import Toasted from 'vue-toasted';
Vue.use(Toasted)


// MEMO: ApiへのGet, Postのエラーor成功メッセージ出力付のラッパーです
export class ApiClient {
    

    public toastOpt: any = {
        position: 'top-center',
        duration: 5000, action: {
            text: 'X',
            onClick: function (e: any, toastObject: any) {
                toastObject.goAway(0);
            }
        }
    };

    private vueComponent: any;
    constructor(vueComponent: any) {
        this.vueComponent = vueComponent;
    }

    public async Get(url: string, params: any): Promise<AxiosResponse> {
        try {
            var res = await axios.get(url, { params: params });
            return res;

        } catch (err) {
            this.vueComponent.$toasted.error('データの取得に失敗しました', this.toastOpt);
            console.log({ apiClientGetError: err });
            throw err;
        }
    }

    public async Post(url: string, params: any, msg: string = "保存しました"): Promise<AxiosResponse> {
        try {

            let res = await axios.post(url, params, {
                validateStatus: function (status) {
                return status < 401;
                }
            });

            if(res.status) {
                if(res.status == 400) {
                    this.vueComponent.$toasted.error('データの保存に失敗しました', this.toastOpt);
                    console.log(res.data.errors);
                } else {
                    this.vueComponent.$toasted.success(msg, this.toastOpt);
                }
            }

            return res;

        } catch (err) {
            this.vueComponent.$toasted.error('データの保存に失敗しました', this.toastOpt);
            console.log({ apiClientGetError: err });
            throw err;
        }
    }

    public async Update(url: string, params: any, msg: string = "更新しました"): Promise<AxiosResponse> {
        try {

            let res = await axios.post(url, params, {
                validateStatus: function (status) {
                return status < 401;
                }
            });

            if(res.status) {
                if(res.status == 400) {
                    this.vueComponent.$toasted.error('データの更新に失敗しました', this.toastOpt);
                    console.log(res.data.errors);
                } else {
                    this.vueComponent.$toasted.success(msg, this.toastOpt);
                }
            }

            return res;

        } catch (err) {
            this.vueComponent.$toasted.error('データの更新に失敗しました', this.toastOpt);
            console.log({ apiClientGetError: err });
            throw err;
        }
    }

    public async ShowError(text: string): Promise<void> {
        this.vueComponent.$toasted.error(text, this.toastOpt);
    }

    public async Delete(url: string, params: any, msg: string = " 削除しました"): Promise<AxiosResponse> {
        try {

            var res = await axios.delete(url, { params: params });
            return res;

        } catch (err) {
            this.vueComponent.$toasted.error('データの削除に失敗しました', this.toastOpt);
            console.log({ apiClientGetError: err });
            throw err;
        }
    }

}