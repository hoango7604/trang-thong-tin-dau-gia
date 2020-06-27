const BASE_API = "http://localhost:5000";

const state = () => ({});

const getters = {};

const mutations = {};

const actions = {
  login({ commit }, payload) {
    console.log("login -> payload", payload);
  },
  logout({ commit }, payload) {
    console.log("logout -> payload", payload);
  },
  register({ commit }, payload) {
    console.log("register -> payload", payload);
  },
  resetPassword({ commit }, payload) {
    console.log("resetPassword -> payload", payload);
  },
  updateAccount({ commit }, payload) {
    console.log("updateAccount -> payload", payload);
  },
};

export default {
  namespaced: true,
  state,
  getters,
  mutations,
  actions,
};
