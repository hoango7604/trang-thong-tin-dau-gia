<template>
  <h1>Danh muc san pham</h1>
</template>

<script>
export default {
  data() {
    return {
      auctions: [],
    };
  },

  async created() {
    //get Auction ID hien tai ra truoc sau do moi goi api de get ra danh sach san pham theo danh muc
    // const currentAuction = await this.$axios.get(`Auction/GetCurrentAuction`);
    const currentAuction = 0;

    const res = await this.$axios.get("Product/GetProductsByFilter", {
      categoryId: currentAuction,
      auctionId: this.$route.params.id,
    });
    const { success, result } = res.data;
    if (success) {
      this.auctions = result.items;
      console.log("created -> auctions", this.auctions);
    }
  },
};
</script>
