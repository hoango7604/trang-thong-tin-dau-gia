import Vue from "vue";
import VueRouter from "vue-router";
import Home from "../views/Home.vue";
import Account from "../views/Account.vue";
import Checkout from "../views/Checkout.vue";
import Auction from "../views/Auction.vue";

Vue.use(VueRouter);

const routes = [
  {
    path: "/",
    name: "Home",
    component: Home,
  },
  {
    path: "/about",
    name: "About",
    component: function() {
      return import(/* webpackChunkName: "about" */ "../views/About.vue");
    },
  },
  {
    path: "/payment",
    name: "Payment",
    component: function() {
      return import(/* webpackChunkName: "about" */ "../views/Payment.vue");
    },
  },
  {
    path: "/contact",
    name: "Contact",

    component: function() {
      return import(/* webpackChunkName: "about" */ "../views/Contact.vue");
    },
  },
  {
    path: "/product/:id",
    name: "Product",
    component: function() {
      return import("../views/Product.vue");
    },
  },
  {
    path: "/auction/:id",
    name: "Auction",
    component: function() {
      return import("../views/Auction.vue");
    },
  },
  {
    path: "/account",
    name: "Account",
    component: Account,
  },
  {
    path: "/checkout",
    name: "Checkout",
    component: Checkout,
  },
];

const router = new VueRouter({
  mode: "history",
  base: process.env.BASE_URL,
  routes,
});

export default router;
