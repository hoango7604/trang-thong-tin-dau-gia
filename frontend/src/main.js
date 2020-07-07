import Vue from "vue";
import App from "./App.vue";
import router from "./router";
import store from "./store";
import "@storefront-ui/vue/styles.scss";
import "bootstrap/dist/css/bootstrap.min.css";
import ElementUI from "element-ui";
import "element-ui/lib/theme-chalk/index.css";
import "./assets/css/main.css";
import axios from "axios";

Vue.config.productionTip = false;

axios.defaults.baseURL = "https://348ebe6d1dd3.ngrok.io/api/";

Vue.prototype.$axios = axios;
Vue.use(ElementUI);

Vue.filter("formatCurrency", (value) => {
  return new Intl.NumberFormat("it-IT", {
    style: "currency",
    currency: "VND",
  }).format(value);
});

new Vue({
  router,
  store,
  render: function(h) {
    return h(App);
  },
}).$mount("#app");
