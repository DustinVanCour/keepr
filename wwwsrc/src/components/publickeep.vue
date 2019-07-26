<template>
  <div class="publickeep">
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

              <p v-if="isHidden" mx-3 @click="isHidden = !isHidden">EDIT</p>
              <p v-else mx-3 @click="isHidden = !isHidden">CANCEL</p>
              <form v-if="!isHidden" @submit.prevent="editKeep(keep.id)">
                <input class="form-control" type="text" placeholder="Name/Title" v-model="name" />
                <input
                  class="form-control"
                  type="text"
                  placeholder="Description"
                  v-model="description"
                />
                <input class="form-control" type="text" placeholder="Image URL" v-model="img" />
                <br />
                <input
                  type="checkbox"
                  class="form-check-input"
                  id="isPrivate"
                  v-model="isPrivate"
                  :value="true"
                />
                <input
                  type="checkbox"
                  class="form-check-input"
                  id="isPrivate"
                  v-model="isPrivate"
                  :value="true"
                />
                <label class="form-check-label" for="isPrivate">Make Private?</label>
                <br />
                <button class="btn btn-success mt-2" type="submit">Edit Keep</button>
              </form>

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
  name: "publickeep",
  props: [],
  data() {
    return {
      name: "",
      description: "",
      img: "",
      // views: 0,
      // shares: 0,
      // keeps: 0,
      isPrivate: false,
      isHidden: true
    };
  },
  mounted() {
    this.$store.dispatch("getAllPublicKeeps");
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
    }
  },
  methods: {
    deleteKeep(id) {
      return this.$store.dispatch("deleteKeep", id);
    },
    addToVault(keep, vault) {
      // keep.keeps++;
      let data = {
        keepId: keep,
        vaultId: vault,
        userName: "",
        isPrivate: false
      };
      return this.$store.dispatch("addToVault", data);
    },
    editKeep(keep) {
      let data = {
        keepId: keep,
        name: this.name,
        description: this.description,
        img: this.img,
        isPrivate: this.isPriave
      };
      return this.$store.dispatch("updateKeep", data);
    },
    keepCount(keep) {
      keep.keeps++;
      return this.$store.dispatch("updateKeep", keep);
    },
    viewCount() {
      this.views++;
    },
    shareCount() {
      this.shares++;
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