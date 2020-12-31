<template>
  <div class="activeProductPage container-fluid">
    <transition-group name="fade">
      <div class="row mt-4 m-2">
        <div class="col-4">
          <div class="row">
            <div class="col-12">
              <img class="img-thumbnail" :src="activeProduct.image" style="width: 100%" alt="">
            </div>
            <div class="col-12 mt-2">
              <button class="btn btn-block btn-success shadow">
                Purchase
              </button>
            </div>
            <div class="col-12 mt-2">
              <div class="btn-group btn-block dropup">
                <button type="button" class="btn btn-warning dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                  Add To Wishlist
                </button>
                <div class="dropdown-menu">
                  <!-- Dropdown menu links -->
                  <ul class="row">
                    <li class="col-12">
                      <button type="button" class="ml-3 btn btn btn-link" data-toggle="modal" data-target="#modelId">
                        Create New Wishlist
                      </button>
                    </li>
                    <wishlist-menu-component v-for="w in wishlists" :key="w.id" :w="w" />
                  </ul>
                </div>
              </div>
            </div>
          </div>
        </div>
        <!-- Modal -->
        <div class="modal fade"
             id="modelId"
             tabindex="-1"
             role="dialog"
             aria-labelledby="modelTitleId"
             aria-hidden="true"
        >
          <div class="modal-dialog" role="document">
            <div class="modal-content">
              <form action="" @submit.prevent="createWishlist(state.newWishlist)">
                <div class="modal-header">
                  <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                  </button>
                </div>

                <div class="modal-body">
                  <div class="container-fluid">
                    <input v-model="state.newWishlist.title" type="text" class="form-control" placeholder="Enter Wishlist Title">
                  </div>
                </div>
                <div class="modal-footer">
                  <button type="button" class="btn btn-secondary" data-dismiss="modal">
                    Close
                  </button>
                  <button class="btn btn-primary">
                    Save
                  </button>
                </div>
              </form>
            </div>
          </div>
        </div>
        <div class="col-7">
          <div class="row">
            <div class="card img-thumbnail" id="productCard">
              <div class="card-header">
                <h1>
                  {{ activeProduct.title }}
                </h1>
              </div>

              <div class="card-body align-items-space-between">
                <p id="description" class="card-text">
                  {{ activeProduct.description }}
                </p>

                <div class="row align-items-end">
                  <div class="col-5 offset-1">
                    <h5 v-if="activeProduct.isAvailable">
                      In Stock!
                    </h5>
                    <h5 v-else>
                      Sorry, not available
                    </h5>
                  </div>
                  <div class="col-5 d-flex justify-content-end">
                    <h5>
                      ${{ activeProduct.price }}
                    </h5>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </transition-group>
  </div>
</template>

<script>
import WishlistMenuComponent from '../components/WishlistMenuComponent'
import { logger } from '../utils/Logger'
import { onMounted, computed, reactive } from 'vue'
import { AppState } from '../AppState'
import { useRoute } from 'vue-router'
import { productService } from '../services/ProductService'
import { wishlistService } from '../services/WishlistService'
export default {
  name: 'ActiveProductPage',
  props: ['w-props'],
  setup() {
    const state = reactive({
      newWishlist: {
        isPublished: true
      }
    })
    const route = useRoute()
    onMounted(() => {
      productService.getOne(route.params.productId)
    })
    return {
      state,
      userId: computed(() => AppState.profile.id),
      activeProduct: computed(() => AppState.activeProduct),
      wishlists: computed(() => AppState.wishlists),
      createWishlist(newWishlist) {
        logger.log('app', newWishlist)
        this.clearForm()
        wishlistService.createWishlist(newWishlist)
      },
      clearForm() {
        state.newWishlist = {}
      }
    }
  },
  components: { WishlistMenuComponent }
}
</script>

 <style lang="scss" scoped>
ul * {
  list-style-type: none;

}
#productCard {
  height: 27em;
  width: 100%;
}
#description {
  height: 90%;
}

 </style>
