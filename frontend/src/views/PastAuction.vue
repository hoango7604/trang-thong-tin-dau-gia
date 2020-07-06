<template>
  <div>
    <SfBreadcrumbs :breadcrumbs="breadcrumbs" class="mb-4" />
    <!-- <div class="d-flex mb-4">
      <SfCheckbox v-model="filter.rolex" name="Rolex" label="Rolex" />
      <SfCheckbox v-model="filter.rolex" name="Rolex" label="Rolex" />
      <SfCheckbox v-model="filter.rolex" name="Rolex" label="Rolex" />
    </div> -->
    <!-- <h2 class="text-center mb-4">Danh sách sản phẩm</h2> -->
    <div class="row mb-4">
      <ProductCard
        v-for="product in products"
        :key="product.id"
        :title="product.name"
        :end-date="endDate"
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
  components: { SfBreadcrumbs, SfCheckbox, SfProductCard, ProductCard },

  data() {
    return {
      breadcrumbs: [
        { text: "Trang chủ", link: "/" },
        { text: "Đấu giá trực tuyến", link: "/" },
      ],
      endDate: "",
      curAunction: "",
      products: [],
    };
  },
  methods: {
    async fetchCurrentAuction() {
      let cur = this.$store.state.common.currentAuction;
      if (!cur) {
        await this.$store.dispatch("common/getCurrentAuction");
        cur = this.$store.state.common.currentAuction;
      }
      this.curAunction = cur.id - 1;
      this.endDate = cur.endDate;
    },

    fetchProductsByCategory() {
      this.$axios
        .get("Product/GetProductsByFilter", {
          params: {
            AuctionId: this.curAunction,
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
    this.fetchProductsByCategory();
  },
};
</script>

<style scoped></style>
