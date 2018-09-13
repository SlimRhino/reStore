<template>
     <b-card title='"На лавке"'
          img-src="https://picsum.photos/600/300/?image=835"
          img-alt="Image"
          img-top          
          class="mb-2 restore-company-card">
    <p>
      {{name}}
    </p>
    <b-button variant="outline-success" 
        v-b-tooltip.hover title="Настройки">
        <i class="fas fa-user-cog"></i>
    </b-button>
    <b-button variant="outline-success" 
        v-b-tooltip.hover title="Выход">
        <i class="fas fa-sign-out-alt"></i>
    </b-button>
  </b-card>
</template>

<script>
export default {
  name: "status-panel",
  data() {
    return {
      name: "Виктор Логинов"
    };
  }
};
</script>

<style lang="scss">
.restore-company-card {
  border: none;
  border-bottom: 2px solid darken(#fffaea, 50%);
  background-color: inherit;
  border-radius: 0;
}
.card-title {
  color: #28a745;
}
</style>
