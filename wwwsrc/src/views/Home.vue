<template>
  <div class="home">
    <h1>Welcome Home {{user.username}}</h1>
    <button v-if="user.id" @click="logout">logout</button>
    <router-link v-else :to="{name: 'login'}">Login</router-link>
    <button class="btn-primary" @click="createKeep">Create Keep</button>
    <div>
      <publickeep />
    </div>
  </div>
</template>

<script>
import PublicKeep from "../components/publickeep.vue";

export default {
  name: "home",
  computed: {
    user() {
      return this.$store.state.user;
    }
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    },
    createKeep() {
      this.$store.dispatch.createKeep();
    }
  },

  components: {
    PublicKeep
  }
};
</script>