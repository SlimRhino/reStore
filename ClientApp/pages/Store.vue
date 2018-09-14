<template>
   <b-container fluid class="page">
      <b-row>
        <b-col cols="3">
          <filters v-if="filters.brands.length" :filters="filters" />
        </b-col>
        <b-col cols="9">
          <product-list :products="products" />
        </b-col>
      </b-row>
    </b-container>
</template>

<script>
import ProductSort from "../components/store/ProductSort.vue";
import ProductList from "../components/store/ProductList.vue";
import Filters from "../components/store/Filters.vue";
import axios from "axios";

export default {
  name: "store",
  data() {
    return {
      products: [],
      filters: {
        brands: [],
        capacity: [],
        color: [],
        os: [],
        features: []
      }
    };
  },
  components: {
    ProductList,
    Filters,
    ProductSort
  },
  methods: {
    setData(products, filters) {
      this.products = products;
      this.filters = filters;
    }
  },
  beforeRouteEnter(to, from, next) {
    axios
      .all([
        axios.get("/api/products", { params: to.query }),
        axios.get("/api/filters")
      ])
      .then(
        axios.spread((products, filters) => {
          next(vm => vm.setData(products.data, filters.data));
        })
      );
  },
  beforeRouteUpdate(to, from, next) {
    axios.get("api/products", { params: to.query }).then(response => {
      this.products = response.data;
      next();
    });
  }
};
</script>

