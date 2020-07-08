<template>
  <div class="mb-5 mt-5">
    <SfHeading :level="level" :title="title" />
    <SfCarousel
      :style="{ maxWidth: '1240px', margin: 'auto' }"
      v-if="products.length"
    >
      <SfCarouselItem v-for="(product, i) in products" :key="i">
        <ProductCard
          :title="product.name"
          :image="product.imageUrl"
          :end-date="endDate"
          :link="`/product/${product.id}`"
          :primaryPrice="product.primaryPrice"
          :startPrice="product.startPrice"
        >
        </ProductCard>
      </SfCarouselItem>
    </SfCarousel>
  </div>
</template>

<script>
import moment from "moment";
import { SfCarousel } from "@storefront-ui/vue";
import { SfProductCard } from "@storefront-ui/vue";
import { SfHeading } from "@storefront-ui/vue";
import ProductCard from "@/components/ProductCard";

export default {
  components: {
    SfCarousel,
    SfHeading,
    SfProductCard,
    ProductCard,
  },

  props: {
    level: {
      type: Number,
      default: 2,
    },
    title: {
      type: String,
      default: "New Arrival",
    },
    type: {
      type: String,
      default: "hightlight",
    },
    categoryId: {
      type: Number,
    },
  },

  data() {
    return {
      settings: {
        arrows: true,
        dots: true,
      },
      products: [],
      curAunction: "",
      endDate: "",
    };
  },

  methods: {
    async fetchCurrentAuction() {
      let cur = this.$store.state.common.currentAuction;
      if (!cur) {
        await this.$store.dispatch("common/getCurrentAuction");
        cur = this.$store.state.common.currentAuction;
      }
      this.curAunction = cur;
      this.endDate = cur.endDate;
      console.log(this.endDate);
    },

    fetchProductsHighlights() {
      this.$axios
        .get("Product/GetProductsByFilter", {
          params: {
            AuctionId: this.curAunction.id,
          },
        })
        .then((data) => {
          const { result, success } = data.data;
          if (success) {
            this.products = result.items;
          }
        });
    },
    fetchProductsByCategory() {
      this.$axios
        .get("Product/GetProductsByFilter", {
          params: {
            CategoryId: this.categoryId,
          },
        })
        .then((data) => {
          console.log("fetchProductsByCategory -> data", data);
          const { result, success } = data.data;
          if (success) {
            this.products = result.items;
          }
        });
    },
  },

  async created() {
    await this.fetchCurrentAuction();
    if (this.type == "hightlight") {
      this.fetchProductsHighlights();
    } else if (this.type == "category") {
      this.fetchProductsByCategory();
    }
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
