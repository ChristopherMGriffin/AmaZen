<template>
  <div class="home flex-grow-1 d-flex align-items-center container">
    <div class="row">
      <!-- NOTE   Formage -->

      <!-- <div class="row">
        <form class="" @submit.prevent="create()">
          <div class="form-group">
            <label for="exampleFormControlInput1">Product Title</label>
            <input type="text" class="form-control" id="exampleFormControlInput1" v-model="state.newProduct.title">
          </div>
          <div class="form-group">
            <label for="exampleFormControlInput1">Image URL</label>
            <input type="text" class="form-control" id="exampleFormControlInput1" v-model="state.newProduct.image">
          </div>
          <div class="form-group">
            <label for="exampleFormControlSelect1">Price</label>
            <input v-model="state.newProduct.price" class="form-control" id="exampleFormControlSelect1" type="decimal">
          </div>
          <div class="form-group">
            <label for="exampleFormControlTextarea1">Description</label>
            <textarea v-model="state.newProduct.description" class="form-control" id="exampleFormControlTextarea1" rows="3"></textarea>
            <div class="form-check">
              <label class="mt-3 form-check-label">
                <input type="checkbox" class="form-check-input" v-model="state.newProduct.isAvailable" value="checkedValue">
                Publish?
              </label>
            </div>
            <button class="btn btn-success btn-sm mt-3">
              Submit
            </button>
          </div>
        </form>
      </div> -->

      <!-- NOTE  Formage -->
      <div class="m-5">
        <div class="card-columns">
          <Product v-for="p in products" :key="p.id" :pprop="p" />
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { productService } from '../services/ProductService'
import { computed, onMounted, reactive } from 'vue'
import { AppState } from '../AppState'
export default {
  name: 'Home',
  props: ['pprop'],
  setup(props) {
    onMounted(() => {
      productService.getAll()
    })
    const state = reactive({
      newProduct: {}
    })
    return {
      state,
      profile: computed(() => AppState.profile),
      products: computed(() => AppState.products),
      create() {
        productService.create(state.newProduct)
      }
    }
  }
}
</script>

<style scoped lang="scss">
.home{
  text-align: center;
  user-select: none;
  > img{
    height: 200px;
    width: 200px;
  }
}
</style>
