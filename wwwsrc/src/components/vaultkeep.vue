<template>
  <div class="vaultkeep">
    <div class="row">
      <div class="col=3" v-for="keep in vaultKeeps" :key="keep.id">
        <div class="card m-2" style="width: 25rem;">
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

              <button
                type="button"
                class="btn dropdown-toggle mx-3"
                id="dropdownMenuOffset"
                data-toggle="dropdown"
                aria-haspopup="true"
                aria-expanded="false"
                data-offset="10,20"
              >
                <i class="fas fa-folder-plus"></i>
              </button>
              <div class="dropdown-menu" aria-labelledby="dropdownMenuOffset">
                <i
                  class="dropdown-item"
                  v-for="vault in vaults"
                  :key="vault.id"
                  @click="addToVault(keep.id, vault.id)"
                >{{vault.name}}</i>
              </div>

              <i
                v-if="user.id == keep.userId"
                class="click fas fa-trash-alt mx-3"
                @click="removeKeep(keep.id, vault.id)"
              ></i>
              <i v-else></i>
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
  name: "vaultkeep",
  props: ["vault"],
  data() {
    return {};
  },
  mounted() {
    this.$store.dispatch("getAllPublicKeeps");
    this.$store.dispatch("getKeepsByVaultId", this.vault);
  },
  computed: {
    keeps() {
      return this.$store.state.keeps;
    },
    user() {
      return this.$store.state.user;
    },
    vaults() {
      return this.$store.state.vaults;
    },
    vaultKeeps() {
      return this.$store.state.vaultkeeps;
    },
    activeVault() {
      return this.$store.state.activeVault;
    }
  },
  methods: {
    removeKeep(id) {
      return this.$store.dispatch("removeKeep", id);
    },
    addToVault(keep, vault) {
      let data = {
        keepId: keep,
        vaultId: vault,
        userName: ""
      };
      return this.$store.dispatch("addToVault", data);
    }
  },
  components: {}
};
</script>

<style>
.click {
  font-size: 2rem;
}
</style>