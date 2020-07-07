<template>
  <div>
    <SfBreadcrumbs :breadcrumbs="breadcrumbs" class="mb-4" />
    <div class="d-flex mb-4">
      <SfRadio
        label="Giá < 2 triệu"
        name="filter"
        value="priceBefore2"
        v-model="filter"
      />
      <SfRadio
        label="Giá từ 2 - 5 triệu"
        name="filter"
        value="price2To5"
        v-model="filter"
      />
      <SfRadio
        label="Giá > 5 triệu"
        name="filter"
        value="priceAfter5"
        v-model="filter"
      />
    </div>
    <h2 class="text-center mb-4">Danh sách sản phẩm</h2>
    <div class="row mb-4" v-if="products.length">
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
    <div v-else class="row mb-4 text-center">Không có sản phẩm nào hợp lệ</div>
  </div>
</template>

<script>
import {
  SfBreadcrumbs,
  SfCheckbox,
  SfProductCard,
  SfSelect,
  SfRadio,
} from "@storefront-ui/vue";
import ProductCard from "@/components/ProductCard";

export default {
  components: {
    SfBreadcrumbs,
    SfCheckbox,
    SfRadio,
    SfProductCard,
    ProductCard,
    SfSelect,
  },
  data() {
    return {
      options: [
        { value: "before2", label: "Giá < 2 triệu" },
        { value: "2To5", label: "Giá từ 2 - 5 triệu" },
        { value: "after5", label: "Giá > 5 triệu" },
      ],
      breadcrumbs: [
        { text: "Trang chủ", link: "/" },
        { text: "Đấu giá trực tuyến", link: "/" },
      ],
      filter: "",
      auctions: [],
      currentAuctionId: null,
      categories: [],
      products: [],
      endDate: "",
    };
  },

  watch: {
    async filter(value) {
      let priceFrom = 0;
      let priceTo = 0;
      console.log(this.$route.params.id);

      switch (value) {
        case "priceBefore2":
          await this.$axios
            .get("Product/GetProductsByFilter", {
              params: {
                CategoryId: this.$route.params.id,
                PrimaryPriceTo: 2000000,
                MaxResultCount: 20,
              },
            })
            .then((data) => {
              const result = data.data.result;
              this.products = result.items;
            });
          break;
        case "price2To5":
          await this.$axios
            .get("Product/GetProductsByFilter", {
              params: {
                CategoryId: this.$route.params.id,
                PrimaryPriceFrom: 2000000,
                PrimaryPriceTo: 5000000,
                MaxResultCount: 20,
              },
            })
            .then((data) => {
              const result = data.data.result;
              this.products = result.items;
            });
          break;
        case "priceAfter5":
          await this.$axios
            .get("Product/GetProductsByFilter", {
              params: {
                CategoryId: this.$route.params.id,
                PrimaryPriceFrom: 5000000,
                MaxResultCount: 20,
              },
            })
            .then((data) => {
              const result = data.data.result;
              this.products = result.items;
            });
          break;
      }
    },
  },

  methods: {
    async fetchProductsByCategory(categoryId) {
      const res = await this.$axios.get("Product/GetProductsByFilter", {
        // auctionId: this.currentAuctionId,
        params: {
          categoryId: categoryId,
          MaxResultCount: 100,
        },
      });
      const { success, result } = res.data;
      if (success) {
        this.products = result.items;
        console.log("products ", this.products);
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

    async fetchCurrentAuction() {
      let cur = this.$store.state.common.currentAuction;
      if (!cur) {
        await this.$store.dispatch("common/getCurrentAuction");
        cur = this.$store.state.common.currentAuction;
      }
      this.currentAuctionId = cur.id;
      this.endDate = cur.endDate;
      console.log(this.endDate);
    },
  },

  async created() {
    const categoryId = this.$route.params.id;

    await this.fetchCurrentAuction();
    await this.fetchProductsByCategory(categoryId);
    await this.fetchAllCategory();
  },
};
</script>

<style scoped>
.sf-checkbox {
  margin-right: 16px;
}
.sf-radio--is-active {
  background: transparent;
}
</style>
