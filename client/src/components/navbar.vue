<template>
  <div>
    <nav class="navbar sticky navbar-light text-light btn-bg p-0">
      <div class="col-6">
        <h4>AmaZen</h4>
      </div>
      <div class="col-2 p d-flex justify-content-end">
        <button @click="login" v-if="!user.isAuthenticated" class="p-0 btn-bg border-light rounded text-light btn-block btn-sm">
          Log In
        </button>
        <button @click="logout" v-if="user.isAuthenticated" class="p-0 btn-bg border-light rounded text-light btn-block btn-sm">
          Log Out
        </button>
      </div>
    </nav>
    <nav class="mb-0">
      <div class="row bg">
        <div class="col-3 pl-5">
          <ul class="bg d-inline-flex mb-0">
            <li>
              <router-link :to="{ name: 'Home' }" class="nav-link p-">
                <h4>
                  Store
                </h4>
              </router-link>
            </li>
            <li v-if="user.isAuthenticated">
              <router-link :to="{ name: 'Profile' }" class="nav-link">
                <h4>
                  Profile
                </h4>
              </router-link>
            </li>
          </ul>
        </div>
        <div class="col-6">
          <div class="input-group mt-2">
            <!-- <div class="input-group-prepend">
              <span class="input-group-text" id="inputGroup-sizing-default">Default</span>
            </div> -->
            <input type="text" class="form-control" aria-label="Default" aria-describedby="inputGroup-sizing-default">
          </div>
        </div>
        <div class="pl-4 col-2 mt-2 d-flex mb-2">
          <button @click="logout" v-if="user.isAuthenticated" class="btn-bg border-light rounded text-light btn-block pb-1">
          post product
        </button>
        </div>
      </div>
    </nav>
  </div>
  <!--
    <button
      class="navbar-toggler"
      type="button"
      data-toggle="collapse"
      data-target="#navbarText"
      aria-controls="navbarText"
      aria-expanded="false"
      aria-label="Toggle navigation"
    >
      <span class="navbar-toggler-icon" />
    </button>
    <div class="collapse navbar-collapse" id="navbarText">
      <ul class="navbar-nav mr-auto">
        <li class="nav-item">
          <router-link :to="{ name: 'Home' }" class="nav-link">
            Home
          </router-link>
        </li>
        <li v-if="user.isAuthenticated" class="nav-item">
          <router-link :to="{ name: 'Wishlists' }" class="nav-link">
            Wishlists
          </router-link>
        </li>
        <li v-if="user.isAuthenticated" class="nav-item">
          <router-link :to="{ name: 'PostProducts' }" class="nav-link">
            Post Items
          </router-link>
        </li>
        <li v-if="user.isAuthenticated" class="nav-item">
          <router-link :to="{ name: 'Profile' }" class="nav-link">
            Profile
          </router-link>
        </li>
      </ul>
      <span class="navbar-text">
        <button
          class="btn btn-link text-uppercase"
          @click="login"
          v-if="!user.isAuthenticated"
        >
          Login
        </button>

        <div class="dropdown" v-else>
          <div
            class="dropdown-toggle"
            @click="state.dropOpen = !state.dropOpen"
          >
            <img
              :src="user.picture"
              alt="user photo"
              height="40"
              class="rounded"
            />
            <span class="mx-3">{{ user.name }}</span>
          </div>
          <div
            class="dropdown-menu p-0 list-group w-100"
            :class="{ show: state.dropOpen }"
            @click="state.dropOpen = false"
          >
           <router-link :to="{ name: 'Profile' }"
              <div class="list-group-item list-group-item-action hoverable">
                Profile
              </div>
            </router-link>
           <div
              class="list-group-item list-group-item-action hoverable"
              @click="logout"
            >
              logout
            </div>
          </div>
        </div>
      </span>
    </div> -->
</template>

<script>
import { AuthService } from '../services/AuthService'
import { AppState } from '../AppState'
import { computed, reactive } from 'vue'
export default {
  name: 'Navbar',
  setup() {
    const state = reactive({
      dropOpen: false
    })
    return {
      state,
      user: computed(() => AppState.user),
      async login() {
        AuthService.loginWithPopup()
      },
      async logout() {
        await AuthService.logout({ returnTo: window.location.origin })
      }
    }
  }
}
</script>

<style scoped>
.dropdown-menu {
  user-select: none;
  display: block;
  transform: scale(0);
  transition: all 0.15s linear;
}
.dropdown-menu.show {
  transform: scale(1);
}
.hoverable {
  cursor: pointer;
}
a:hover {
  text-decoration: none;
}
.nav-link{
  text-transform: uppercase;
  color: #f2f2f2;

}
.nav-item .nav-link.router-link-exact-active{
  color: var(--dark);
}
.navbar {
  background: #ffc165;
}
.btn-bg {
  background: #ffc165;
}
.bg {
  background: #e09d5f;
}
ul {
    list-style-type: none;
}

</style>
