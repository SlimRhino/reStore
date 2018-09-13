<template>
    <div class="details">
        <h1>{{ product.name }}</h1>
        <img :src="product.thumbnail" :alt="product.name" />
        <p>{{ product.description }}</p>
        <p>Объем: {{ product.volume }} мл</p>
        <p>Цена: {{ product.price }}  &#8381;</p>
    </div>
</template>

<script>
export default {
  name: "product-details",
  props: {
    product: {
      type: Object,
      required: false
    }
  }
};
</script>

<style>
</style>