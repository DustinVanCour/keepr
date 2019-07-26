<template>
  <div class="home">
    <navbar></navbar>
    <h1>Welcome Home {{user.username}}</h1>
    <button v-if="user.id" @click="logout">logout</button>
    <router-link v-else :to="{name: 'login'}">Login</router-link>

    <form @submit.prevent="createSubmit()">
      <input class="form-control" type="text" placeholder="Name/Title" v-model="name" />
      <input class="form-control" type="text" placeholder="Description" v-model="description" />
      <input class="form-control" type="text" placeholder="Img URL" v-model="img" />
      <input
        type="checkbox"
        class="form-check-input"
        id="isPrivate"
        v-model="isPrivate"
        :value="true"
      />
      <label class="form-check-label" for="isPrivate">Make Private?</label>
      <br />
      <button class="btn btn-info mt-2" type="submit">Create Note</button>
    </form>

    <div class="container-fluid">
      <publickeep></publickeep>
    </div>
  </div>
</template>

<script>
import publickeep from "../components/publickeep.vue";
import navbar from "../components/navbar.vue";

export default {
  name: "home",
  computed: {
    user() {
      return this.$store.state.user;
    }
  },
  data() {
    return {
      name: "",
      description: "",
      img: "",
      isPrivate: false
    };
  },
  mounted() {
    this.$store.dispatch("getAllPublicKeeps");
    this.$store.dispatch("getVaults");
  },

  methods: {
    logout() {
      this.$store.dispatch("logout");
    },
    createSubmit() {
      let data = {
        name: this.name,
        description: this.description,
        img: this.img,
        isPrivate: this.isPrivate
      };
      this.$store.dispatch("createKeep", data);
    }
  },
  components: {
    publickeep,
    navbar
  }
};
</script>