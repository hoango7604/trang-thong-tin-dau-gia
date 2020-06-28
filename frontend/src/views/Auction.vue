<template>
  <h1>Danh muc san pham</h1>
</template>

<script>
export default {
  data() {
    return {
      auctions: [],
      currentAuctionId: null,
      categories: [],
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
        this.auctions = result.items;
        console.log("auctions", this.auctions);
      }
    },

    async getCurrentAuctionId() {
      //get Auction ID hien tai ra truoc sau do moi goi api de get ra danh sach san pham theo danh muc
      // const currentAuctionId = await this.$axios.get(`Auction/GetCurrentAuction`);
      const currentAuctionId = 0;
      this.currentAuctionId = currentAuctionId;
    },

    async fetchAllCategory() {
      const res = await this.$axios.get("Category/GetCategorysByFilter");
      const { success, result } = res.data;
      if (success) {
        this.categories = result.items;
        console.log("categories", this.categories);
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
