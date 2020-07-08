<template>
  <SfProductCard
    :image="image"
    :image-width="imageWidth"
    :image-height="imageHeight"
    :badge-label="badgeLabel"
    :badge-color="badgeColor"
    :link="link"
    :wishlistIcon="false"
    :is-added-to-cart="isAddedToCart"
    @click:is-added-to-cart="alert('@click:is-added-to-cart')"
  >
    <div slot="title" class="title">
      <a :href="link" class="sf-product-card__link">
        <h3 class="sf-product-card__title">{{ title }}</h3>
      </a>
    </div>
    <div slot="price" class="price">
      <p class="price-original">Giá gốc: {{ primaryPrice | formatCurrency }}</p>
      <span>Giá khởi điểm: {{ startPrice | formatCurrency }}</span>
    </div>
    <div slot="add-to-cart-icon">
      <img :src="hammer" alt="#" />
    </div>
    <template #badge>
      <Countdown :end-date="endDate"></Countdown>
    </template>
  </SfProductCard>
</template>

<script>
import Countdown from "@/components/Countdown";
import { SfProductCard } from "@storefront-ui/vue";

export default {
  components: {
    SfProductCard,
    Countdown,
  },

  props: {
    title: {
      type: String,
      default: "",
    },
    image: {
      type: String,
      default: require("@/assets/storybook/Home/productB.jpg"),
    },
    primaryPrice: {
      type: Number,
    },
    startPrice: {
      type: Number,
    },
    link: {
      type: String,
    },
    badgeLabel: {
      type: String,
      default: "time cd",
    },
    endDate: {
      type: String,
    },
  },

  data() {
    return {
      hammer: require("@/assets/icon/hammer.svg"),
      imageWidth: 316,
      imageHeight: 316,
      badgeColor: "color-success",
      linkTag: "",
      isAddedToCart: false,
    };
  },
};
</script>

<style lang="css" scoped>
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

/* .sf-product-card__title {
  font-weight: 600;
} */
</style>
