<template>
  <div class="home">
    <SfHero class="mb-5">
      <SfHeroItem
        v-for="(item, i) in heros"
        :key="i"
        :title="item.title"
        :subtitle="item.subtitle"
        :button-text="item.buttonText"
        :image="item.image"
        :background="item.background"
      />
    </SfHero>

    <SfBannerGrid
      class="mb-5"
      :banner-grid="bannerGrid"
      :style="{ maxWidth: '1240px', margin: 'auto' }"
    >
      <template v-for="item in banners" v-slot:[item.slot]>
        <SfBanner
          :key="item.slot"
          :title="item.title"
          :subtitle="item.subtitle"
          :description="item.description"
          :button-text="item.buttonText"
          :image="item.image"
          :class="item.class"
        />
      </template>
    </SfBannerGrid>

    <CollectionProduct type="hightlight" title="SẢN PHẨM NỔI BẬT" />

    <CollectionProduct
      type="category"
      categoryId="0"
      title="ĐỒNG HỒ STUHRLING"
    />

    <CollectionProduct type="category" categoryId="2" title="ĐỒNG HỒ CASIO" />
  </div>
</template>

<script>
import { SfHero } from "@storefront-ui/vue";
import { SfBannerGrid } from "@storefront-ui/vue";
import { SfBanner } from "@storefront-ui/vue";
import CollectionProduct from "@/components/CollectionProduct";

export default {
  components: {
    SfHero,
    SfBannerGrid,
    SfBanner,
    CollectionProduct,
  },

  data() {
    return {
      heros: [
        {
          title: "Sản phẩm nổi bật",
          subtitle: "Summer Collection 2020",
          buttonText: "Xem thêm",
          image: {
            mobile: require("@/assets/storybook/SfHero/hero.png"),
            desktop: require("@/assets/storybook/SfHero/hero.png"),
          },
          background: "#ECEFF1",
        },
        {
          title: "BRUNO SOHNLE GLASHUTTE",
          subtitle: "Summer Collection 2019",
          buttonText: "Xem thêm",
          image: {
            mobile: require("@/assets/storybook/SfHero/hero-2.png"),
            desktop: require("@/assets/storybook/SfHero/hero-2.png"),
          },
          background: "#ECEFF1",
        },
      ],

      banners: [
        {
          slot: "banner-A",
          subtitle: "Dresses",
          title: "Cocktail & Party",
          description:
            "Find stunning women's cocktail dresses and party dresses. Stand out in lace and metallic cocktail dresses from all your favorite brands.",
          buttonText: "Shop now",
          image: require("@/assets/storybook/Home/banner-1.jpg"),
          class: "sf-banner--slim",
        },
        {
          slot: "banner-B",
          subtitle: "Dresses",
          title: "Linen Dresses",
          description:
            "Find stunning women's cocktail dresses and party dresses. Stand out in lace and metallic cocktail dresses from all your favorite brands.",
          buttonText: "Shop now",
          image: require("@/assets/storybook/Home/banner-2.jpg"),
          class: "sf-banner--slim",
          style: ["padding-right: 20%", null],
        },
        {
          slot: "banner-C",
          subtitle: "T-Shirts",
          title: "The Office Life",
          buttonText: "Shop now",
          image: require("@/assets/storybook/Home/banner-3.jpg"),
          class: "sf-banner--slim",
        },
        {
          slot: "banner-D",
          subtitle: "Summer Sandals",
          title: "Eco Sandals",
          buttonText: "Shop now",
          image: require("@/assets/storybook/Home/banner-4.jpg"),
          class: ["sf-banner--slim"],
        },
      ],
      bannerGrid: 1,
    };
  },
};
</script>
