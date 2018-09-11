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
            <product-details class="details" v-if="selectedProduct" :product="selectedProduct" />
        </div>
    </div>
</template>

<script>
    export default {
        name: "product-list",
        data() {
            return {
                products: [{
                    name: "Латте",
                    slug: "latte",
                    description: "Кофе латте схож по названию с напитком латте макиато. Основное отличие латте макиато заключается в том, что при его приготовлении кофе добавляется в молоко (а не молоко в кофе, как в латте) и напиток, таким образом, получается слоистым: слой молока, слой эспрессо, слой вспененного молока. Латте даёт более сильный вкус кофе",
                    thumbnail: "https://via.placeholder.com/100x150",
                    volume: 385,
                    price: 95,
                },
                {
                    name: "Эспрессо",
                    slug: "espresso",
                    description: "Эсперссо - метод приготовления кофе путём прохождения горячей воды (около 90 °C) под давлением 9 бар через фильтр с молотым кофе.",
                    thumbnail: "https://via.placeholder.com/100x150",
                    volume: 35,
                    price: 60,
                },
                ],
                selectedProduct:  null
            };
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