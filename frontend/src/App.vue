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
            <SfMenuItem :label="item" />
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
          title: "About us",
          items: ["Who we are", "Quality in the details", "Customer Reviews"],
        },
        {
          title: "Departments",
          items: ["Women fashion", "Men fashion", "Kidswear", "Home"],
        },
        {
          title: "Help",
          items: ["Customer service", "Size guide", "Contact us"],
        },
        { title: "Payment & delivery", items: ["Purchase terms", "Guarantee"] },
        {
          title: "Social",
          pictures: [
            require("@/assets/storybook/SfFooter/facebook.svg"),
            require("@/assets/storybook/SfFooter/pinterest.svg"),
            require("@/assets/storybook/SfFooter/twitter.svg"),
            require("@/assets/storybook/SfFooter/youtube.svg"),
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
.page-content {
  min-height: 60vh;
  max-width: 1240px;
  margin: auto;
}
</style>
