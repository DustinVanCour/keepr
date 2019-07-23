<template>
  <div class="publickeep">
    <div class="row">
      <div class="col=3" v-for="keep in keeps" :key="keep">
        <div class="card" style="width: 18rem;">
          <img v-bind:src="keep.img" class="card-img-top" alt="Note Image Here" />
          <div class="card-body">
            <h5 class="card-title">{{keep.name}}</h5>
            <p class="card-text">{{keep.description}}</p>
            <a href="#" class="btn btn-primary">Go somewhere</a>
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
      return this.$store.dispatch("getAllPublicKeeps");
    }
  },
  methods: {},
  components: {}
};
</script>

<style>
</style>