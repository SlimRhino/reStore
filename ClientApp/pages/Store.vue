<template>
    <div class="page">
        <product-list :products="products" />
    </div>
</template>

<script>
import ProductList from "../components/store/ProductList.vue";

export default {
  name: "store",
  data() {
    return {
      products: []
    };
  },
  components: {
    ProductList
  },
  methods: {
    setData(products) {
      this.products = products;
    }
  },
  beforeRouteEnter(to, from, next) {
    fetch("/api/products")
      .then(response => {
        return response.json();
      })
      .then(products => {
        next(vm => vm.setData(products));
      });
  }
};
</script>