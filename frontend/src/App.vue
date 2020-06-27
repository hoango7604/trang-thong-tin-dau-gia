<template>
  <div id="app">
    <SfHeader
      :title="title"
      :logo="logo"
      :active-icon="activeIcon"
      :search-placeholder="searchPlaceholder"
      :search-value="searchValue"
      :cart-icon="cartIcon"
      :wishlist-icon="wishlistIcon"
      :is-sticky="isSticky"
      :account-icon="accountIcon"
      :cart-items-qty="cartItemsQty"
      @click:cart="alert('@click:cart')"
      @click:wishlist="alert('@click:wishlist')"
      @click:account="alert('@click:account')"
      @change:search="searchValue = $event"
    >
      <template #navigation>
        <SfHeaderNavigationItem v-for="item in navigation" :key="item.name">
          <SfLink :link="item.link">
            {{ item.name }}
          </SfLink>
        </SfHeaderNavigationItem>
        <button @click="openPopup()">Login</button>
      </template>
    </SfHeader>

    <section class="page-content">
      <router-view />
    </section>

    <PopupAccount
      v-if="isOpenPopup"
      :visible="isOpenPopup"
      @closePopUp="closePopUp"
    />

    <SfFooter :column="column" :multiple="multiple">
      <SfFooterColumn
        v-for="column in columns"
        :key="column.title"
        :title="column.title"
      >
        <SfList v-if="column.items">
          <SfListItem v-for="(item, i) in column.items" :key="i">
            <SfLink :link="item.url">
              <SfMenuItem :label="item.title" />
            </SfLink>
          </SfListItem>
        </SfList>
        <div v-else>
          <SfImage
            v-for="picture in column.pictures"
            :key="picture"
            width="12"
            height="12"
            :src="picture"
            :style="{ margin: '0 1.5rem 0 0' }"
          />
        </div>
      </SfFooterColumn>
    </SfFooter>
  </div>
</template>

<script>
import { SfFooter } from "@storefront-ui/vue";
import { SfHeader } from "@storefront-ui/vue";
import { SfList } from "@storefront-ui/vue";
import { SfImage } from "@storefront-ui/vue";
import { SfButton } from "@storefront-ui/vue";
import { SfMenuItem } from "@storefront-ui/vue";
import { SfLink } from "@storefront-ui/vue";
import {} from "@storefront-ui/vue";
import PopupAccount from "@/components/PopupAccount.vue";
export default {
  components: {
    SfFooter,
    SfHeader,
    SfLink,
    SfList,
    SfImage,
    SfButton,
    SfMenuItem,
    PopupAccount,
  },
  data() {
    return {
      isOpenPopup: false,
      isMobile: false,
      navigation: [
        { name: "home", link: "/" },
        { name: "about", link: "/about" },
        { name: "account", link: "/account" },
        { name: "login", link: "/login" },
        { name: "register", link: "/register" },
      ],
      searchValue: "",
      title: "Storefront UI",
      logo: {
        mobile: { url: require("@/assets/logo.svg") },
        desktop: { url: require("@/assets/logo.svg") },
      },
      activeIcon: "account",
      isSticky: true,
      searchPlaceholder: "Search for items",
      cartIcon: "empty_cart",
      wishlistIcon: "heart",
      accountIcon: "profile",
      cartItemsQty: "0",

      columns: [
        {
          title: "Về chúng tôi",
          items: [
            {
              title: "Giới thiệu chung",
              url: "/about",
            },
            {
              title: "Phương thức thanh toán",
              url: "/payment",
            },
            {
              title: "Liên hệ",
              url: "/contact",
            },
          ],
        },
        {
          title: "Hướng dẫn sử dụng",
          items: [
            {
              title: "Hướng dẫn đăng nhập hệ thống",
              url: "/about",
            },
            {
              title: "Hướng dẫn đăng ký thành viên",
              url: "/payment",
            },
            {
              title: "Hướng dẫn quản lý đấu giá",
              url: "/contact",
            },
          ],
        },
        {
          title: "Hỗ trợ khách hàng",
          items: [
            {
              title: "Chính sách bảo hành",
              url: "/about",
            },
            {
              title: "Chính sách đổi hàng",
              url: "/payment",
            },
            {
              title: "Chính sách bảo mật",
              url: "/contact",
            },
          ],
        },
      ],
      column: 4,
      multiple: false,
    };
  },
  methods: {
    openPopup() {
      this.isOpenPopup = true;
    },
    closePopUp() {
      this.isOpenPopup = false;
    },
  },
};
</script>

<style>
:root {
  --link-text-decoration: none;
  --section-margin: 100px;
}
.page-content {
  min-height: 60vh;
  max-width: 1240px;
  margin: auto;
}
</style>
