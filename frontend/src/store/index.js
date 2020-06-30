import Vue from "vue";
import Vuex from "vuex";
import axios from "axios";
import account from "./account.js";
import auction from "./auction.js";
import product from "./product.js";
import common from "./common.js";

Vue.use(Vuex);

axios.defaults.baseURL = "http://localhost:5000/api/";

const debug = process.env.NODE_ENV !== "production";

export default new Vuex.Store({
  modules: {
    account,
    auction,
    product,
    common,
  },
  strict: debug,
});
