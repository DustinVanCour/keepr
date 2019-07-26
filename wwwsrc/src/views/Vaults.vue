<template>
  <div class="vaults">
    <navbar></navbar>
    <form @submit.prevent="vaultSubmit()">
      <input class="form-control" type="text" placeholder="Name/Title" v-model="name" />
      <input class="form-control" type="text" placeholder="Description" v-model="description" />
      <br />
      <button class="btn btn-info mt-2" type="submit">Create Vaults</button>
    </form>
    <div class="row">
      <div class="col-4" v-for="vault in vaults" :key="vault.id">
        <div class="card border-success mb-3" style="max-width: 25rem;">
          <div class="card-header bg-transparent border-success">
            <h3>{{vault.name}}</h3>
          </div>
          <div class="card-body text-success">
            <p class="card-text">{{vault.description}}</p>
          </div>
          <div class="card-footer bg-transparent border-success">
            <router-link :to="{name:'vault', params: {vaultId: vault.id}}">
              <p @click="viewVault(vault.id)">VIEW</p>
            </router-link>

            <p mx-3 @click="deleteVault(vault.id)">DELETE</p>
            <p v-if="isHidden" mx-3 @click="isHidden = !isHidden">EDIT</p>
            <p v-else mx-3 @click="isHidden = !isHidden">CANCEL</p>
            <form v-if="!isHidden" @submit.prevent="editVault(vault.id)">
              <input class="form-control" type="text" placeholder="Name/Title" v-model="name" />
              <input
                class="form-control"
                type="text"
                placeholder="Description"
                v-model="description"
              />
              <br />
              <button class="btn btn-success mt-2" type="submit">Edit Vault</button>
            </form>
          </div>
        </div>
      </div>
    </div>
    <div class="row">
      <div class="col=3" v-for="keep in keeps" :key="keep.id">
        <div class="card m-2" style="width: 25rem;">
          <img v-bind:src="keep.img" class="card-img-top" alt="Note Image Here" />
          <div class="card-body">
            <!-- KEEPS TRACK OF SHARES/KEEPS/VIEWS -->
            <h6>
              <i class="tracker fab fa-kickstarter-k mx-1">{{keep.keeps}}</i>
              <i class="tracker far fa-eye mx-3">{{keep.views}}</i>
              <i class="tracker fas fa-share mx-3">{{keep.shares}}</i>
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
                  @click="addToVault(keep.id, vault.id), keepCount(keep)"
                >{{vault.name}}</i>
              </div>
              <i
                v-if="user.id == keep.userId"
                class="click fas fa-trash-alt mx-3"
                @click="deleteKeep(keep.id)"
              ></i>
            </h1>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import navbar from "../components/navbar.vue";
export default {
  name: "vaults",
  props: [],
  data() {
    return {
      name: "",
      description: "",
      isHidden: true
    };
  },
  mounted() {
    this.$store.dispatch("getVaults");
    this.$store.dispatch("getKeepsByUserId");
  },
  computed: {
    vaults() {
      return this.$store.state.vaults;
    },
    user() {
      return this.$store.state.user;
    },
    keeps() {
      return this.$store.state.userkeeps;
    }
  },
  methods: {
    vaultSubmit() {
      let data = {
        name: this.name,
        description: this.description
      };
      this.$store.dispatch("createVault", data);
    },
    viewVault(id) {
      this.$store.dispatch("getVaultById", id);
    },
    deleteVault(id) {
      return this.$store.dispatch("deleteVault", id);
    },
    editVault(vault) {
      let data = {
        vaultId: vault,
        name: this.name,
        description: this.description
      };
      return this.$store.dispatch("updateVault", data);
    }
  },
  components: {
    navbar
  }
};
</script>