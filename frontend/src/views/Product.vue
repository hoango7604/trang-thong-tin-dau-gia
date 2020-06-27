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
        <SfHeading :title="product.name" :level="3"></SfHeading>
        <SfDivider />
        <div class="row mt-4">
          <div class="col-12 col-md-7">
            <div class="d-flex justify-content-between">
              <p>
                Giá gốc <br />
                <b> {{ product.giaGoc | formatCurrency }} </b>
              </p>
              <p>
                Khởi điểm <br />
                <b> {{ product.giaKhoiDiem | formatCurrency }} </b>
              </p>
              <p>
                Bước giá <br />
                <b> {{ product.buocGia | formatCurrency }} </b>
              </p>
            </div>
            <div class="d-flex">
              <p>
                Giá hiện tại <br />
                <b class="product__price">
                  {{ product.giaHienTai | formatCurrency }}
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
            <SfButton style="width: 100%">
              Đấu giá ngay
            </SfButton>
          </div>
        </div>

        <SfDivider></SfDivider>

        <div class="mt-4">
          <SfProperty
            class="product__property"
            v-for="item in product.info"
            :key="item.name"
            :name="item.name"
            :value="item.value"
          />
        </div>
      </div>
    </div>

    <!-- Chi tiết sản phẩm  và Sản phẩm khác -->
    <div class="row">
      <div class="col-12 col-md-8">
        <SfTabs>
          <SfTab v-for="tab in tabs" :key="tab.title" :title="tab.title">
            <p v-html="tab.content"></p>
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
      images: [
        {
          alt: "Product A",
          mobile: { url: require("@/assets/img/productA.jpg") },
          desktop: { url: require("@/assets/img/productA.jpg") },
          zoom: { url: require("@/assets/img/productA.jpg") },
        },
      ],
      tabs: [
        {
          title: "Chi tiết sản phẩm",
          content: `<iframe width="560" height="315" src="https://www.youtube.com/embed/OmHG_UAeWJc" frameborder="0" allow="accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>`,
        },
        {
          title: "Hướng dẫn đấu giá",
          content: "Hướng dẫn đấu giá đang được cập nhật.",
        },
      ],
      sliderOptions: { autoplay: false, rewind: true, gap: 0 },
      product: {
        name: "STUHRLING ORIGINAL ST-557.02",
        giaGoc: 8660000,
        giaKhoiDiem: 5196000,
        buocGia: 100000,
        giaHienTai: 5196000,
        winner: "Hưng Trần",
        info: [
          { name: "Mã sản phẩm", value: "ST-557.02" },
          { name: "Thương hiệu", value: "Thụy Sĩ" },
          { name: "Bảo hành", value: "10 năm" },
          { name: "Đường kính mặt", value: "42mm" },
          { name: "Độ chịu nước", value: "5 ATM" },
          { name: "Năng lượng sử dụng", value: "Quartz/Pin" },
        ],
      },
    };
  },

  methods: {
    fetchProductDetail() {
      console.log("id: ", this.$route.params.id);
      this.$axios
        .get(`Product/GetProductForView?id=${this.$route.params.id}`)
        .then((data) => {
          const { result, success } = data.data;
          console.log("fetchProductDetail -> result", result);
          if (success) {
            // this.product = result.items;
          }
          return;
        });
    },
  },

  created() {
    this.fetchProductDetail();
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
