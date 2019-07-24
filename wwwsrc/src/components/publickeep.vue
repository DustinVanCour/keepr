<template>
  <div class="publickeep">
    <div class="row">
      <div class="col=3" v-for="keep in keeps" :key="keep.id">
        <div class="card m-2" style="width: 18rem;">
          <img v-bind:src="keep.img" class="card-img-top" alt="Note Image Here" />
          <div class="card-body">
            <!-- KEEPS TRACK OF SHARES/KEEPS/VIEWS -->
            <h6>
              <i class="tracker fab fa-kickstarter-k mx-1"></i>
              <i class="tracker far fa-eye mx-3"></i>
              <i class="tracker fas fa-share mx-3"></i>
            </h6>
            <h5 class="card-title">{{keep.name}}</h5>
            <p class="card-text">{{keep.description}}</p>
            <h1 v-if="$store.state.user.id">
              <i class="click fab fa-kickstarter mx-3"></i>
              <i class="click fas fa-share-square mx-3"></i>
              <i class="click fas fa-folder-plus mx-3"></i>
            </h1>
            <h5 v-else>Login to Interact</h5>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "publickeep",
  props: [],
  data() {
    return {};
  },
  mounted() {
    this.$store.dispatch("getAllPublicKeeps");
  },
  computed: {
    keeps() {
      return this.$store.state.keeps;
    }
  },
  user() {
    return this.$store.state.user;
  },
  methods: {},
  components: {}
};
</script>

<style>
</style>