<template>
    <product-details :product="product" />
</template>

<script>
    import ProductDetails from '../components/product/Details.vue'

    export default {
        name: "product",
        components: {
            ProductDetails
        },
        data() {
            return {
                product: {
                    name: "Латте",
                    slug: "latte",
                    description: "Кофе латте схож по названию с напитком латте макиато. Основное отличие латте макиато заключается в том, что при его приготовлении кофе добавляется в молоко (а не молоко в кофе, как в латте) и напиток, таким образом, получается слоистым: слой молока, слой эспрессо, слой вспененного молока. Латте даёт более сильный вкус кофе",
                    thumbnail: "https://via.placeholder.com/100x150",
                    volume: 385,
                    price: 95,
                }
            }
        }
    }
</script>