import axios from "axios";

const state = () => ({
  isLogged: false,
  isErrorLogin: false,
  togglePopUpLogin: false,
  user: null,
});

const getters = {};

const mutations = {
  setLogged(state, action) {
    state.isLogged = action;
    if (action) {
      localStorage.setItem("isLogged", action);
    } else {
      localStorage.removeItem("isLogged");
      localStorage.removeItem("user");
    }
  },

  setUser(state, action) {
    state.user = action;
    localStorage.setItem("user", JSON.stringify(action));
  },

  setErrorLogin(state, action) {
    state.isErrorLogin = action;
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
    if (result) {
      commit("setLogged", true);
      commit("setTogglePopupLogin", false);
      commit("setUser", result);
    } else {
      commit("setErrorLogin", true);
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
