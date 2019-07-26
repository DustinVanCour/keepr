import Vue from 'vue'
import Vuex from 'vuex'
import Axios from 'axios'
import router from './router'
import AuthService from './AuthService'

Vue.use(Vuex)

let baseUrl = location.host.includes('localhost') ? '//localhost:5000/' : '/'

let api = Axios.create({
  baseURL: baseUrl + "api/",
  timeout: 3000,
  withCredentials: true
})

export default new Vuex.Store({
  state: {
    user: {},
    keeps: [],
    vaults: [],
    activevault: {},
    vaultkeeps: [],
    userkeeps: []
  },
  mutations: {
    setUser(state, user) {
      state.user = user
    },
    resetState(state) {
      //clear the entire state object of user data
      state.user = {}
    },
    setKeeps(state, keeps) {
      state.keeps = keeps
    },
    setVaults(state, vaults) {
      state.vaults = vaults
    },
    setVaultKeeps(state, vaultkeeps) {
      state.vaultkeeps = vaultkeeps
    },
    setActiveVault(state, activevault) {
      state.activevault = activevault
    },
    setUserKeeps(state, userkeeps) {
      state.userkeeps = userkeeps
    }

  },
  actions: {
    async register({ commit, dispatch }, creds) {
      try {
        let user = await AuthService.Register(creds)
        commit('setUser', user)
        router.push({ name: "home" })
      } catch (e) {
        console.warn(e.message)
      }
    },
    async login({ commit, dispatch }, creds) {
      try {
        let user = await AuthService.Login(creds)
        commit('setUser', user)
        router.push({ name: "home" })
      } catch (e) {
        console.warn(e.message)
      }
    },
    async logout({ commit, dispatch }) {
      try {
        let success = await AuthService.Logout()
        if (!success) { }
        commit('resetState')
        router.push({ name: "login" })
      } catch (e) {
        console.warn(e.message)
      }
    },

    // --KEEPS METHODS--

    async getAllPublicKeeps({ commit, dispatch }) {
      await api.get('keeps')
        .then(res => {
          commit('setKeeps', res.data)
        })
    },
    async getKeepsByUserId({ commit, dispatch }) {
      ;
      await api.get('keeps/user')
        .then(res => {
          commit('setUserKeeps', res.data)
        })
    },
    async createKeep({ commit, dispatch }, payload) {
      await api.post('keeps', payload)
        .then(res => {
          dispatch('getAllPublicKeeps')
        })
    },
    async updateKeep({ commit, dispatch }, data) {
      ;
      let res = await api.put('keeps/' + data.id, data)
        .then(res => {
          dispatch('getAllPublicKeeps', data.id)
        })
    },
    deleteKeep({ commit, dispatch }, payload) {
      api.delete('keeps/' + payload)
        .then(res => {
          dispatch('getAllPublicKeeps')
        })
    },
    getKeepsByVaultId({ commit, dispatch }, vaultId) {
      api.get('vaultkeeps/' + vaultId)
        .then(res => {
          commit('setVaultKeeps', res.data)
        })
    },

    // --VAULT METHODS--
    async getVaults({ commit, dispatch }) {
      await api.get('vaults')
        .then(res => {
          commit('setVaults', res.data)
        })
    },

    async createVault({ commit, dispatch }, payload) {
      await api.post('vaults', payload)
        .then(res => {
          dispatch('getVaults')
        })
    },
    deleteVault({ commit, dispatch }, payload) {
      api.delete('vaults/' + payload)
        .then(res => {
          dispatch('getVaults')
        })
    },
    async getVaultById({ commit, dispatch }, id) {
      await api.get('vaults/' + id)
        .then(res => {
          commit('setActiveVault', res.data)
        })
    },
    async updateVault({ commit, dispatch }, data) {
      let res = await api.put('vaults/' + data.vaultId, data)
        .then(res => {
          dispatch('getVaults', data.vaultid)
        })
    },

    // VAULTKEEP METHODS
    async getVaultKeeps({ commit, dispatch }, vaultId) {
      await api.get('vaultkeeps/' + vaultId)
        .then(res => {

          commit('setVaultKeeps', res.data)
        })
    },
    async addToVault({ commit, dispatch }, payload) {
      await api.post('vaultkeeps/', payload)
        .then(res => {
          dispatch('getVaultKeeps', payload.vaultId)
        })
    },
    async removeKeep({ commit, dispatch }, vaultKeep) {
      ;
      await api.put('vaultkeeps/', vaultKeep)
        .then(res => {
          dispatch('getKeepsByVaultId', vaultKeep.vaultId)
        })
    }
  }
})
