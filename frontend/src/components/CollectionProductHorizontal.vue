<template>
  <div>
    <SfProductCardHorizontal
      :image="image"
      :title="title"
      :link="link"
      :link-tag="linkTag"
      :regular-price="regularPrice"
      :special-price="specialPrice"
      :is-added-to-cart="isAddedToCart"
      :add-to-cart-disabled="addToCartDisabled"
      @input="quantity = $event"
    >
      <template #configuration>
        <SfProperty
          class="desktop-only"
          name="Size"
          value="XS"
          style="margin: 0 0 1rem 0;"
        />
        <SfProperty class="desktop-only" name="Color" value="white" />
      </template>
      <template #actions>
        <SfButton
          class="sf-button--text desktop-only"
          @click="$emit('click:add-to-wishlist')"
          style="margin: 0 0 1rem auto; display: block;"
        >
          Save for later
        </SfButton>
        <SfButton
          class="sf-button--text desktop-only"
          @click="$emit('click:add-to-compare')"
          style="margin: 0 0 0 auto; display: block;"
        >
          Add to compare
        </SfButton>
      </template>
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
      image: require("@/assets/img/productA.jpg"),
      title: "Cream Beach Bag",
      link: "",
      linkTag: "",
      regularPrice: "$10,99",
      specialPrice: "",
      wishlistIcon: false,
      isOnWishlist: true,
      isOnWishlistIcon: "heart_fill",
      maxRating: 5,
      isAddedToCart: false,
      addToCartDisabled: false,
    };
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
</style>
