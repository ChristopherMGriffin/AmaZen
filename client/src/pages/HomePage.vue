<template>
  <div class="home flex-grow-1 d-flex align-items-center container-fluid">
    <div class="row mt-2">
      <Product v-for="p in products" :key="p.id" :pprop="p" />
    </div>
  </div>
</template>

<script>
import { productService } from '../services/ProductService'
import { computed, onMounted } from 'vue'
import { AppState } from '../AppState'
export default {
  name: 'Home',
  props: ['pprop'],
  setup(props) {
    onMounted(() => {
      productService.getAll()
    })
    return {
      profile: computed(() => AppState.profile),
      products: computed(() => AppState.products)

    }
  }
}

</script>

<style scoped lang="scss">
.home{
  text-align: center;
  user-select: none;
}

</style>
