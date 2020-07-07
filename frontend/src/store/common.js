import axios from "axios";

const state = () => ({
  cart: null,
  category: null,
  currentAuction: null,
});

const getters = {};

const mutations = {
  setCart(state, action) {
    state.cart = action;
  },
  setCategory(state, action) {
    state.category = action;
  },
  setCurrentAuction(state, action) {
    state.currentAuction = action;
    console.log("setCurrency -> state.currentAuction", state.currentAuction);
  },
};

const actions = {
  async getCurrentAuction({ commit }, payload) {
    const res = await axios.get("Auction/GetCurrentAuction");
    const { result, success } = res.data;
    if (success) {
      commit("setCurrentAuction", result);
      return result;
    }
    return null;
  },

  async getCartByUserId({ commit }, payload) {
    const res = await axios.get("Product/GetProductsByFilter", {
      params: {
        winnerClientId: payload.userId,
        MaxResultCount: 100,
      },
    });
    const { result, success } = res.data;
    if (success) {
      if (result.items.length > 0) {
        commit("setCart", result.items);
        return result.items;
      }
    }
    return [];
  },

  async getAllCategoryProduct({ commit }, payload) {
    const res = await axios.get("Category/GetCategorysByFilter");
    const { result, success } = res.data;
    if (success) {
      if (result.items.length > 0) {
        commit("setCategory", result.items);
        return result.items;
      }
    }
    return null;
  },

  async finishPayment({ commit }, payload) {
    // const res = await axios.get("Category/GetCategorysByFilter");
    // const { result, success } = res.data;
    // if (success) {
    //   if (result.items.length > 0) {
    //     commit("setCategory", result.items);
    //     return result.items;
    //   }
    //   return null;
    // }
    // return null;
  },

  async getInfoUserById({ commit }, payload) {
    const res = await axios.get("Client/GetClientForView", {
      params: {
        id: payload.id,
      },
    });
    return res.data.result;
  },
};

export default {
  namespaced: true,
  state,
  getters,
  mutations,
  actions,
};
