<template>
  <li class="WishlistMenuComponent col-12">
    <button type="button" class="btn btn-sm btn-lg btn-link" @click="addToWishlist(w.id)" data-toggle="dropdown">
      <p>{{ w.title }}</p>
    </button>
  </li>
</template>

<script>
import { computed } from 'vue'
import { wishlistService } from '../services/WishlistService'
import { logger } from '../utils/Logger'
import { AppState } from '../AppState'
export default {
  name: 'WishlistMenuComponent',
  props: ['w'],
  setup(props) {
    return {
      activeProduct: computed(() => AppState.activeProduct),
      addToWishlist(wId) {
        logger.log('wid', wId, 'activeProductId', this.activeProduct.id)
        wishlistService.addToWishlist(wId, this.activeProduct.id)
      }
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>

</style>
