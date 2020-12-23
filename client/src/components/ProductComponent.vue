<template>
  <div class="product card">
    <a href="#">
      <img class="card-img-top" :src="pprop.image" alt="Card image cap">
      <div class="card-body">
        <h5 class="card-title">
          {{ pprop.title }}
        </h5>
      </div>
    </a>
    <p class="card-text">
      {{ pprop.description }}
    </p>
    <div class="row">
      <div class="col-6 justify-content-end">
        <button @click="edit(pprops.id)" class="btn btn-link">
          Edit
        </button>
      </div>
      <div class="col-6 justify-content-end">
        <button @click="delete(pprops.id)" class="btn btn-link text-danger">
          Delete
        </button>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'Product',
  props: ['pprop'],
  setup() {
    return {}
  },
  components: {}
}
</script>

<style lang="scss" scoped>

</style>
