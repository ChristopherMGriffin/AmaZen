import { createRouter, createWebHashHistory } from 'vue-router'
import { authGuard } from '@bcwdev/auth0provider-client'

function loadPage(page) {
  return () => import(`./pages/${page}.vue`)
}

const routes = [
  {
    path: '/',
    name: 'Home',
    component: loadPage('HomePage')
  },
  {
    path: '/wishlists',
    name: 'Wishlists',
    component: loadPage('WishlistPage'),
    beforeEnter: authGuard

  },
  {
    path: '/newproducts',
    name: 'PostProducts',
    component: loadPage('PostProductsPage'),
    beforeEnter: authGuard

  },
  {
    path: '/products/:productId',
    name: 'ActiveProductPage',
    component: loadPage('ActiveProductPage')
  },
  {
    path: '/profile',
    name: 'Profile',
    component: loadPage('ProfilePage'),
    beforeEnter: authGuard
  }
]

const router = createRouter({
  linkActiveClass: 'router-link-active',
  linkExactActiveClass: 'router-link-exact-active',
  history: createWebHashHistory(),
  routes
})

export default router
