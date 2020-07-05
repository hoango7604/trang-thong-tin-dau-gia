<template>
  <div>
    <SfProductCardHorizontal
      v-for="product in products"
      :key="product.id"
      :imageWidth="240"
      :imageHeight="240"
      :image="product.imageUrl"
      :is-added-to-cart="isAddedToCart"
      :add-to-cart-disabled="addToCartDisabled"
      @input="quantity = $event"
    >
      <div slot="price" class="price">
        <a :href="`/product/${product.id}`" class="sf-product-card__link title">
          <h3 class="sf-product-card__title">{{ product.name }}</h3>
        </a>

        <p class="price-original">
          Giá gốc: {{ product.primaryPrice | formatCurrency }}
        </p>
        <span>Giá khởi điểm: {{ product.startPrice | formatCurrency }}</span>
      </div>
    </SfProductCardHorizontal>
  </div>
</template>
<script>
import { SfProductCardHorizontal } from "@storefront-ui/vue";
import { SfButton } from "@storefront-ui/vue";
import { SfProperty } from "@storefront-ui/vue";

export default {
  components: {
    SfProductCardHorizontal,
    SfButton,
    SfProperty,
  },
  data() {
    return {
      quantity: 1,
      wishlistIcon: false,
      isOnWishlist: true,
      isOnWishlistIcon: "heart_fill",
      isAddedToCart: false,
      addToCartDisabled: false,
      products: [],
    };
  },

  created() {
    this.fetchProductsHighlights();
  },

  methods: {
    fetchProductsHighlights() {
      this.$axios.get("Product/GetProductsByFilter").then((data) => {
        const { result, success } = data.data;
        if (success) {
          this.products = result.items;
        }
      });
    },
  },
};
</script>

<style>
.sf-product-card-horizontal__add-to-cart {
  display: none;
}
.sf-product-card-horizontal__actions {
  display: none;
}
.sf-product-card-horizontal__main {
  align-items: center;
}
.price {
  color: #5ece7b;
}
.price p {
  margin-bottom: 8px;
}

.price-original {
  color: black;
}
.sf-product-card__link {
  margin-bottom: 8px;
  color: black;
}
.sf-product-card-horizontal {
  border-radius: 8px;
  margin-bottom: 16px;
  padding: 16px;
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.12), 0 0 6px rgba(0, 0, 0, 0.04);
}
.sf-product-card-horizontal:hover {
  transform: scale(1.1);
  transition: all 0.2s;
}
</style>
