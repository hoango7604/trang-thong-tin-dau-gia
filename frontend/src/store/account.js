import axios from "axios";

const state = () => ({
  isLogged: false,
  togglePopUpLogin: false,
});

const getters = {};

const mutations = {
  setLogged(state, action) {
    state.isLogged = action;
    if (action) {
      localStorage.setItem("isLogged", action);
    } else {
      localStorage.removeItem("isLogged");
    }
  },
  setTogglePopupLogin(state, action) {
    state.togglePopUpLogin = action;
  },
};

const actions = {
  async login({ commit }, payload) {
    const res = await axios.post("Client/Login", {
      phone: payload.phone,
      password: payload.password,
    });

    const { result } = res.data;
    console.log("login -> result", result);
    if (result) {
      commit("setLogged", true);
      commit("setTogglePopupLogin", false);
    }
  },

  logout({ commit }, payload) {
    commit("setLogged", false);
  },

  async register({ commit, dispatch }, payload) {
    const res = await axios.post("Client/CreateOrEditClient", {
      phone: payload.phone,
      password: payload.password,
      fullName: payload.fullName,
      address: null,
      role: "client",
      id: 0,
    });
    if (res.data.success) {
      dispatch("login", payload);
    }
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
