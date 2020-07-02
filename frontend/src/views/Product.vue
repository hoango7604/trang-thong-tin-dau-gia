<template>
  <div class="product-page">
    <SfBreadcrumbs :breadcrumbs="breadcrumbs" class="mb-4" />
    <div class="row mb-5">
      <SfGallery
        class="col-12 col-md-6"
        :images="images"
        :image-width="468"
        :image-height="468"
        :thumb-width="100"
        :slider-options="sliderOptions"
        :current="1"
        :enable-zoom="true"
      />
      <div class="col-12 col-md-6">
        <SfHeading :title="product.name" :level="2"></SfHeading>
        <SfDivider />
        <div class="row mt-4">
          <div class="col-12 col-md-7">
            <div class="d-flex justify-content-between">
              <p>
                Giá gốc <br />
                <b> {{ product.primaryPrice | formatCurrency }} </b>
              </p>
              <p>
                Khởi điểm <br />
                <b> {{ product.startPrice | formatCurrency }} </b>
              </p>
              <p>
                Bước giá <br />
                <b> {{ product.stepPrice | formatCurrency }} </b>
              </p>
            </div>
            <div class="d-flex">
              <p>
                Giá hiện tại <br />
                <b class="product__price">
                  {{ product.currentPrice | formatCurrency }}
                </b>
              </p>

              <div class="ml-3 w-100 d-flex align-items-start">
                <img
                  :src="require('@/assets/img/winner.png')"
                  alt="#"
                  class="winner mr-3"
                />
                <p class="d-inline-block">
                  Người chiến thắng <br />
                  <b> {{ product.winner }} </b>
                </p>
              </div>
            </div>
          </div>
          <div class="col-12 col-md-5">
            <SfButton style="width: 100%" @click="actionAuctionNow">
              Đấu giá ngay
            </SfButton>
          </div>
        </div>

        <SfDivider></SfDivider>

        <div class="mt-4">
          <h4>Danh sách người đấu</h4>
          <SfTable>
            <SfTableHeading>
              <SfTableHeader v-for="header in tableHeaders" :key="header">{{
                header
              }}</SfTableHeader>
            </SfTableHeading>
            <SfTableRow v-for="(row, key) in tableRows" :key="key">
              <SfTableData
                v-for="data in row"
                :key="data"
                :class="status[data]"
                >{{ data }}</SfTableData
              >
            </SfTableRow>
          </SfTable>
        </div>
      </div>
    </div>

    <!-- Chi tiết sản phẩm  và Sản phẩm khác -->
    <div class="row">
      <div class="col-12 col-md-8">
        <SfTabs>
          <SfTab title="Chi tiết sản phẩm">
            <SfProperty
              class="product__property"
              v-for="item in info"
              :key="item.name"
              :name="item.name"
              :value="item.value"
            />
          </SfTab>
          <SfTab title="Hướng dẫn đấu giá">
            Hướng dẫn đấu giá đang được cập nhật.
          </SfTab>
        </SfTabs>
      </div>

      <div class="col-12 col-md-4">
        <SfHeading title="Sản phẩm khác" :level="3"></SfHeading>

        <CollectionProductHorizontal></CollectionProductHorizontal>
      </div>
    </div>
  </div>
</template>
<script>
import {
  SfBreadcrumbs,
  SfButton,
  SfHeading,
  SfTable,
  SfTabs,
  SfGallery,
  SfDivider,
  SfProperty,
} from "@storefront-ui/vue";
import CollectionProductHorizontal from "@/components/CollectionProductHorizontal";

export default {
  components: {
    CollectionProductHorizontal,
    SfBreadcrumbs,
    SfProperty,
    SfGallery,
    SfTable,
    SfHeading,
    SfDivider,
    SfButton,
    SfTabs,
  },

  data() {
    return {
      breadcrumbs: [
        { text: "Trang chủ", link: "/" },
        { text: "Đấu giá trực tuyến", link: "/" },
      ],
      images: [],
      sliderOptions: { autoplay: false, rewind: true, gap: 0 },
      product: [],
      info: [],
      tableHeaders: ["Tên", "Giá đấu", "Thời gian"],
      tableRows: [
        ["#35767", "4th Nov", "Paypal"],
        ["#35767", "4th Nov", "Visa"],
        ["#35767", "4th Nov", "Paypal"],
      ],
      status: { Finalise: "text-success", "In process": "text-warning" },
    };
  },

  methods: {
    async fetchProductDetail() {
      await this.$axios
        .get(`Product/GetProductForView?id=${this.$route.params.id}`)
        .then((data) => {
          const { result, success } = data.data;
          if (success) {
            this.product = result;
            this.images = [
              {
                alt: "Product",
                mobile: { url: result.imageUrl },
                desktop: { url: result.imageUrl },
                zoom: { url: result.imageUrl },
              },
            ];

            this.info = [
              { name: "Mã sản phẩm", value: result.productId },
              { name: "Thương hiệu", value: result.brand },
              { name: "Bảo hành", value: `${result.warranty} năm` },
              { name: "Đường kính mặt", value: `${result.diameter}mm` },
              { name: "Độ chịu nước", value: "5 ATM" },
              { name: "Năng lượng sử dụng", value: result.energySource },
            ];
          }
          return;
        });
    },

    async fetchUsersAuctioning() {
      const { currentAuction } = this.$store.state.common;
      console.log("fetchUsersAuctioning -> currentAuction", currentAuction);
      await this.$axios
        .get("AuctionDetail/GetAuctionDetailsByFilter", {
          params: {
            productId: this.$route.params.id,
            auctionId: currentAuction.id,
            // auctionId: 3, // test
          },
        })
        .then(async (data) => {
          const { result, success } = data.data;
          console.log("fetchUsersAuctioning -> result", result);
          if (success) {
            // Get nguoi dung dang dau gia trong san pham
            this.userAuctioning = null;
            const { items } = result;
            if (items) {
              // vi khong lay dc truc tiep thong tin user nen phai goi api get tung user theo id
              this.userAuctioning = await Promise.all(
                items.map(async (value) => {
                  return await this.$store.dispatch("common/getInfoUserById", {
                    id: value.id,
                  });
                })
              );
            }
          }
          return;
        });
    },

    async fetchCurrentAuction() {
      const cur = this.$store.state.common.currentAuction;
      if (!cur) {
        await this.$store.dispatch("common/getCurrentAuction");
      }
    },

    async actionAuctionNow() {
      const isLogged = localStorage.getItem("isLogged");
      if (isLogged) {
        const user = JSON.parse(localStorage.getItem("user"));
        const res = await this.$axios.post("Product/Bidding", {
          productId: this.$route.params.id,
          clientId: user.id,
        });
        const { success } = res.data;
        if (success) {
          location.reload();
        }
      } else {
        this.$store.commit("account/setTogglePopupLogin", true);
      }
    },
  },

  async created() {
    await this.fetchCurrentAuction();
    await this.fetchProductDetail();
    await this.fetchUsersAuctioning();
  },
};
</script>

<style scoped>
.product__property {
  margin-bottom: 16px;
}

.product__price {
  color: red;
  font-size: 20px;
}

.winner {
  width: 100%;
  max-width: 36px;
}
</style>
