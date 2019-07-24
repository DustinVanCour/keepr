<template>
  <div class="vaults">
    <form @submit.prevent="vaultSubmit()">
      <input class="form-control" type="text" placeholder="Name/Title" v-model="name" />
      <input class="form-control" type="text" placeholder="Description" v-model="description" />
      <br />
      <button class="btn btn-info mt-2" type="submit">Create Vaults</button>
    </form>
    <p v-for="vault in vaults" :key="vault.id">{{vault.name}} -- {{vault.description}}</p>
  </div>
</template>

<script>
export default {
  name: "vaults",
  props: [],
  data() {
    return {
      name: "",
      description: ""
    };
  },
  mounted() {
    this.$store.dispatch("getVaults");
  },
  computed: {
    vaults() {
      return this.$store.state.vaults;
    }
  },
  methods: {
    vaultSubmit() {
      let data = {
        name: this.name,
        description: this.description
      };
      this.$store.dispatch("createVault", data);
    }
  },
  components: {}
};
</script>