<template>
  <SfCarousel :style="{ maxWidth: '1240px', margin: 'auto' }">
    <SfCarouselItem v-for="index in 12" :key="index">
      <SfProductCard
        :image="image"
        :image-width="imageWidth"
        :image-height="imageHeight"
        :badge-label="badgeLabel"
        :badge-color="badgeColor"
        :title="title"
        :link="link"
        :link-tag="linkTag"
        :show-add-to-cart-button="showAddToCartButton"
        :add-to-cart-disabled="addToCartDisabled"
        :is-added-to-cart="isAddedToCart"
        @click:is-added-to-cart="alert('@click:is-added-to-cart')"
      >
        <div slot="title" class="title">
          <a :href="link" class="sf-product-card__link">
            <h3 class="sf-product-card__title">{{ title }}</h3>
          </a>
        </div>
        <div slot="price" class="price">
          <p class="price-original">Giá gốc: {{ regularPrice }}</p>
          <p>Giá khởi điểm: {{ specialPrice }}</p>
        </div>
        <div slot="add-to-cart-icon">
          
        </div>
      </SfProductCard>
    </SfCarouselItem>
  </SfCarousel>
</template>

<script>
import { SfCarousel } from "@storefront-ui/vue";
import { SfProductCard } from "@storefront-ui/vue";

export default {
  components: {
    SfCarousel,
    SfProductCard,
  },

  data() {
    return {
      image: {
        mobile: { url: require("@/assets/storybook/Home/productB.jpg") },
        desktop: { url: require("@/assets/storybook/Home/productB.jpg") },
      },
      imageWidth: 316,
      imageHeight: 316,
      badgeLabel: "time cd",
      badgeColor: "color-danger",
      title: "Stuhrling Original ST-571.3345K54",
      link: "",
      linkTag: "",
      regularPrice: "$10.99",
      specialPrice: "$5.09",
      showAddToCartButton: true,
      isAddedToCart: false,
      addToCartDisabled: false,
    };
  },
};
</script>

<style scoped>
.title {
  text-align: center;
}

.price {
  color: red;
  text-align: center;
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

.sf-product-card__title {
  font-weight: 600;
}
</style>
