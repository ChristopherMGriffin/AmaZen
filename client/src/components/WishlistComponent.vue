<template>
  <div class="WishlistComponent">
    <li>
      <button class="btn">
        {{ wProp.title }}
      </button>
    </li>
  </div>
</template>

<script>
export default {
  name: 'WishlistComponent',
  props: ['wProp'],
  setup(props) {
    return {}
  },
  components: {}
}
</script>

<style lang="scss" scoped>

</style>
