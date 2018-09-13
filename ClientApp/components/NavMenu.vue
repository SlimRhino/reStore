<template>
    <b-navbar toggleable="md" type="dark" variant="dark">
    <b-container>
        <b-navbar-toggle target="nav_collapse"></b-navbar-toggle>
        <b-navbar-brand to="/">RestoreCafe</b-navbar-brand>
        <b-collapse is-nav id="nav_collapse">
            <b-navbar-nav>
            <b-nav-item to="/products">Кофе</b-nav-item>
            </b-navbar-nav>
        </b-collapse>
    </b-container>
</b-navbar>
</template>

<script>
export default {
  name: "nav-menu"
};
</script>

<style lang="scss">
</style>

