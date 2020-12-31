<template>
  <div class="product col-sm-6 col-md-4 col-lg-3 mt-2">
    <router-link :to="{ name: 'ActiveProductPage', params: {productId: pprop.id} }">
      <img class="img-thumbnail" style="width: 300px; height: 300px" :src="pprop.image" alt="Card image cap">
    </router-link>
  </div>
  <!-- <div> -->
  <!-- <div class="card-body">
          <h5 class="card-title">
            {{ pprop.title }}
          </h5>
        </div>
      </router-link>
    </div>
    <p class="card-text">
      {{ pprop.description }}
    </p>
    <p class="card-text">
      ${{ pprop.price }}
    </p>
    <div class="row">
      <div class="col-6 justify-content-end">
        <button v-show="profile.id == pprop.creatorId" @click="editProduct(pprop.id)" class="btn btn-link">
          Edit
        </button>
      </div>
      <div class="col-6 justify-content-end">
        <button v-show="profile.id == pprop.creatorId" @click="deleteProduct(pprop.id)" class="btn btn-link text-danger">
          Delete
        </button>
      </div>
    </div> -->
</template>

<script>
import { computed, reactive } from 'vue'
import { productService } from '../services/ProductService'
import { AppState } from '../AppState'
export default {
  name: 'Product',
  props: ['pprop'],
  setup(props) {
    const state = reactive({
      editedProduct: {}
    })
    return {
      state,
      profile: computed(() => AppState.profile),
      deleteProduct(id) {
        productService.deleteProduct(id)
      },
      editProduct(editedProduct) {
        productService.editProduct(editedProduct)
      }
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>
img * {
    height: 200px;
    width: 200px;
  }

</style>
