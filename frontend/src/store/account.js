const BASE_API = "http://localhost:5000";

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
    }
  },
  setTogglePopupLogin(state, action) {
    state.togglePopUpLogin = action;
  },
};

const actions = {
  login({ commit }, payload) {
    const user = {
      phone: "123",
      password: "123",
    };
    if (payload.phone == user.phone && payload.password == user.password) {
      commit("setLogged", true);
      commit("setTogglePopupLogin", false);
    }
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
