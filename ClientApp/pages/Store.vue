<template>
    <product-list :products="products" />
</template>

<script>
    import ProductList from '../components/store/ProductList.vue'

    export default {
        name: "store",
        data() {
            return {
                products: []
            }
        },
        components: {
            ProductList
        },
        mounted() {
            fetch("/api/products")
                .then(response => {
                    return response.json();
                })
                .then(products => {
                    this.products = products;
                })
        }
    }
</script>