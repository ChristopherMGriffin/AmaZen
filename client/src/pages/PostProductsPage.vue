<template>
  <div class="PostProductsPage justify-content-center">
    <div class="row text-center mb-3">
      <div class="col-12">
        <h1>Create New Product</h1>
      </div>
    </div>
    <div class="row mr-0 pr-5">
      <div class="col-3 m-2">
        <div class="row">
          <form @submit="create(state.newProduct)">
            <div class="row mb-2">
              <div class="col-12 mb-2">
                <input type="text" class="form-control" placeholder="Product Name" v-model="state.newProduct.title">
              </div>
              <div class="col-12">
                <input type="text" class="form-control" placeholder="Product Image URL" v-model="state.newProduct.image">
              </div>
              <div class="col-12 mt-2">
                <input type="decimal" class="form-control" placeholder="Price" v-model="state.newProduct.price">
              </div>
            </div>
            <div class="row">
              <div class="col-12">
                <textarea maxlength="255"
                          placeholder="Product Description"
                          v-model="state.newProduct.description"
                          class="form-control"
                          id="exampleFormControlTextarea1"
                          rows="3"
                ></textarea>
              </div>
            </div>
            <div class="row mt-2">
              <div class="col-12 mb-2">
                <button @click="state.newProduct.isAvailable = false" v-if="state.newProduct.isAvailable" class="btn btn-block btn-warning border rounded">
                  Mark as Unavailable
                </button>
                <button @click="state.newProduct.isAvailable = true" v-else class="btn btn-block btn-success border rounded">
                  Mark as Available
                </button>
              </div>
              <div class="col-12">
                <button class="btn btn-block btn-success border rounded">
                  Submit
                </button>
              </div>
            </div>
          </form>
        </div>
      </div>
      <div class="col-3">
        <div class="row ">
          <div class="col-12">
            <img v-if="state.newProduct.image" class="img-fluid shadow-lg" :src="state.newProduct.image" alt="">
            <img v-else class="img-fluid shadow-lg" src="https://www.fillmurray.com/640/500" alt="">
          </div>
        </div>
      </div>
      <div class="col-5">
        <div class="row">
          <div class="card">
            <div class="card-header">
              <h1 v-if="state.newProduct.title">
                {{ state.newProduct.title }}
              </h1>
              <h1 v-else>
                New Product Title Goes Here
              </h1>
            </div>
            <div class="card-body">
              <p v-if="state.newProduct.description" class="card-text">
                {{ state.newProduct.description }}
              </p>
              <p v-else class="card-text">
                Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Augue neque gravida in fermentum et. Sed odio morbi quis commodo odio aenean sed adipiscing diam. Facilisi morbi tempus iaculis urna id volutpat lacus laoreet non. Cursus turpis massa tincidunt dui. Convallis convallis tellus id interdum velit laoreet. Euismod nisi porta lorem mollis aliquam ut porttitor leo a. Diam quam nulla porttitor massa. Eleifend donec pretium vulputate sapien nec. Ac turpis egestas maecenas pharetra convallis posuere morbi leo. At lectus urna duis convallis. Nulla aliquet enim tortor at auctor. Massa id neque aliquam vestibulum morbi.
              </p>
              <div class="row">
                <div class="col-5 offset-1">
                  <h5 v-if="state.newProduct.isAvailable">
                    In Stock!
                  </h5>
                  <h5 v-else>
                    Sorry, not available
                  </h5>
                </div>
                <div class="col-5 d-flex justify-content-end">
                  <h5 v-if="state.newProduct.price">
                    ${{ state.newProduct.price }}
                  </h5>
                  <h5 v-else>
                    $Price
                  </h5>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
    <div class="row">
    </div>
  </div>
</template>
  <!-- NOTE   Formage -->

  <!--<div class="row">
      <div class="col-6">
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
      </div>
    </div> -->

  <!-- NOTE  Formage -->

<script>
import { productService } from '../services/ProductService'
import { AppState } from '../AppState'
import { reactive, computed } from 'vue'
export default {
  name: 'PostProductsPage',
  setup() {
    const state = reactive({
      newProduct: {
        isAvailable: false
      }
    })
    return {
      state,
      profile: computed(() => AppState.profile),
      products: computed(() => AppState.products),
      create() {
        productService.create(state.newProduct)
      }
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>

</style>
