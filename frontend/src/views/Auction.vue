<template>
  <div>
    <SfBreadcrumbs :breadcrumbs="breadcrumbs" class="mb-4" />
    <div class="d-flex mb-4">
      <SfCheckbox v-model="filter.rolex" name="Rolex" label="Rolex" />
      <SfCheckbox v-model="filter.rolex" name="Rolex" label="Rolex" />
      <SfCheckbox v-model="filter.rolex" name="Rolex" label="Rolex" />
    </div>
    <h2 class="text-center mb-4">Danh sách sản phẩm</h2>
    <div class="row mb-4">
      <ProductCard
        v-for="product in products"
        :key="product.id"
        :title="product.name"
        :image="product.imageUrl"
        :link="`/product/${product.id}`"
        :primaryPrice="product.primaryPrice"
        :startPrice="product.startPrice"
      ></ProductCard>
    </div>
  </div>
</template>

<script>
import { SfBreadcrumbs, SfCheckbox, SfProductCard } from "@storefront-ui/vue";
import ProductCard from "@/components/ProductCard";

export default {
  components: {
    SfBreadcrumbs,
    SfCheckbox,
    SfProductCard,
    ProductCard,
  },
  data() {
    return {
      breadcrumbs: [
        { text: "Trang chủ", link: "/" },
        { text: "Đấu giá trực tuyến", link: "/" },
      ],
      filter: {
        rolex: false,
      },
      auctions: [],
      currentAuctionId: null,
      categories: [],
      products: [],
    };
  },

  methods: {
    async fetchProductsByCategory(categoryId) {
      const res = await this.$axios.get("Product/GetProductsByFilter", {
        params: {
          categoryId: categoryId,
          auctionId: this.currentAuctionId,
          MaxResultCount: 100,
        },
      });
      const { success, result } = res.data;
      if (success) {
        this.products = result.items;
      }
    },

    async fetchAllCategory() {
      const res = await this.$axios.get("Category/GetCategorysByFilter");
      const { success, result } = res.data;
      if (success) {
        this.categories = result.items;
        console.log("categories", this.categories);
      }
    },

    async getCurrentAuctionId() {
      const res = await this.$axios.get("Auction/GetCurrentAuction");
      const { result, success } = res.data;
      if (success) {
        this.currentAuctionId = result.id;
      }
    },
  },

  async created() {
    const categoryId = this.$route.params.id;

    await this.getCurrentAuctionId();
    await this.fetchProductsByCategory(categoryId);
    await this.fetchAllCategory();
  },
};
</script>

<style scoped>
.sf-checkbox {
  margin-right: 16px;
}
</style>
