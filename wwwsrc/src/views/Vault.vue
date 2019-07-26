<template>
  <div class="vault">
    <navbar></navbar>
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

                <!-- <button
                  type="button"
                  class="btn dropdown-toggle mx-3"
                  id="dropdownMenuOffset"
                  data-toggle="dropdown"
                  aria-haspopup="true"
                  aria-expanded="false"
                  data-offset="10,20"
                >-->
                <!-- <i class="fas fa-folder-plus"></i>
                </button>
                <div class="dropdown-menu" aria-labelledby="dropdownMenuOffset">
                  <i
                    class="dropdown-item"
                    v-for="vault in vaults"
                    :key="vault.id"
                    @click="addToVault(keep.id, vault.id)"
                  >{{vault.name}}</i>
                </div>-->

                <i class="click fas fa-folder-minus mx-3" @click="removeKeep(keep.id)"></i>
              </h1>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import navbar from "../components/navbar.vue";
import publickeep from "../components/publickeep.vue";

export default {
  name: "vault",
  props: ["vaultId"],
  data() {
    return {};
  },
  mounted() {
    this.$store.dispatch("getKeepsByVaultId", this.vaultId);
  },

  computed: {
    user() {
      return this.$store.state.user;
    },
    activeVault() {
      return this.$store.state.activeVault;
    },
    vaultKeeps() {
      return this.$store.state.vaultkeeps;
    }
  },
  methods: {
    removeKeep(keepId) {
      let data = {
        vaultId: this.vaultId,
        keepId: keepId,
        userId: ""
      };
      return this.$store.dispatch("removeKeep", data);
    }
  },
  components: {
    navbar,
    publickeep
  }
};
</script>