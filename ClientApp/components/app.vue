<template>
  <div class="app">
    <b-navbar toggleable="md" type="dark" variant="dark">
      <b-navbar-toggle target="nav_collapse"></b-navbar-toggle>
      <b-navbar-brand to="/">PhoneShop</b-navbar-brand>
      <b-collapse is-nav id="nav_collapse">
        <b-navbar-nav>
          <b-nav-item to="/products">Products</b-nav-item>
        </b-navbar-nav>
      </b-collapse>
    </b-navbar>
    <transition name="fade" mode="out-in">
      <router-view />
    </transition>
  </div> 
</template>

<script>
import NavMenu from "./NavMenu.vue";
export default {
  name: "app",
  components: {
    NavMenu
  }
};
</script>

<style lang="scss">
html,
body,
.main {
  height: 100vh;
  margin: 0 auto;
  background-color: #fffbf0;
}

.fade-enter-active,
.fade-leave-active {
  transition: opacity 0.3s ease-in-out;
}

.fade-enter,
.fade-leave-to {
  opacity: 0;
}
</style>

