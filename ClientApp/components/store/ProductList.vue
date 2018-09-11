<template>
    <div class="products">
        <h1>Кофе</h1>
        <div class="list">
            <div class="item" v-for="product in products" :key="product.slug">
                <h2 @click="select(product)">{{ product.name }}</h2>
                <img :src="product.thumbnail" :alt="product.name" @click="select(product)" />
                <p @click="select(product)">Объем: {{ product.volume }} мл</p>
                <p @click="select(product)">Цена: {{ product.price }} рублей</p>
            </div>
        </div>
    </div>
</template>

<script>
    export default {
        name: "product-list",
        props: {
            products: {
                type: Array,
                required: true
            }
        },
        methods: {
            select(product) {
                this.$router.push(`/products/${product.slug}`);
            }
        }
    };
</script>

<style>
    * {
        box-sizing: border-box !important;
    }

    .products {
        padding: 20px;
        max-width: 1200px;
        margin: 0 auto;
    }

    .list .item {
        width: 25%;
        float: left;
        padding: 20px 10px 20px 0;
    }

    .list img,
    .list h3,
    .list p {
        cursor: pointer;
    }

    .list img {
        width: 100px;
    }
</style>