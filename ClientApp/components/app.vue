<template>
    <b-container fluid class="pl-0 pr-0">
        <nav-menu />
      <b-row class="main">
        <b-col>
          <transition name="fade" mode="out-in">
          <router-view />
          </transition>
        </b-col>  
      </b-row>  
    </b-container>
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

