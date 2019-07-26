<template>
  <div class="navbar row">
    <nav class="col-12 navbar navbar-expand-lg navbar-light bg-success">
      <a class="navbar-brand" href="#">TrapprKeepr</a>
      <button
        class="navbar-toggler"
        type="button"
        data-toggle="collapse"
        data-target="#navbarNav"
        aria-controls="navbarNav"
        aria-expanded="false"
        aria-label="Toggle navigation"
      >
        <span class="navbar-toggler-icon"></span>
      </button>
      <div class="collapse navbar-collapse" id="navbarNav">
        <ul class="navbar-nav">
          <li class="nav-item active">
            <a class="nav-link" href="#">
              <router-link :to="{name:'home'}">Home</router-link>
              <span class="sr-only">(current)</span>
            </a>
          </li>
          <li class="nav-item">
            <a class="nav-link" href="#">
              <router-link :to="{name:'vaults'}">Dashboard</router-link>
            </a>
          </li>
          <li class="nav-item">
            <a href="#" class="nav-link" v-if="user.id" @click="logout">logout</a>
          </li>
        </ul>
      </div>
    </nav>
  </div>
</template>

<script>
export default {
  name: "navbar",
  props: [],
  data() {
    return {};
  },
  computed: {
    user() {
      return this.$store.state.user;
    }
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    }
  },
  components: {}
};
</script>