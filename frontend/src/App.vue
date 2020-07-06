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
      @click:account="$router.push('/account')"
      @change:search="searchValue = $event"
    >
      <template #navigation>
        <SfHeaderNavigationItem v-for="item in navigation" :key="item.name">
          <SfLink :link="item.link">
            {{ item.name }}
          </SfLink>
        </SfHeaderNavigationItem>
        <el-dropdown
          class="sf-header-navigation-item"
          @command="handleCategoryClick"
        >
          <a href="#" class="sf-link">
            Danh mục<i class="el-icon-arrow-down el-icon--right"></i>
          </a>
          <el-dropdown-menu slot="dropdown">
            <el-dropdown-item
              v-for="item in categories"
              :key="item.id"
              :command="item.id"
            >
              {{ item.name }}
            </el-dropdown-item>
          </el-dropdown-menu>
        </el-dropdown>
        <div class="sf-header-navigation-item" v-if="!isLogged">
          <a href="#" class="sf-link" @click="openPopup()">Login</a>
        </div>
        <div class="sf-header-navigation-item" v-else>
          <a href="#" class="sf-link" @click="logout()">Logout</a>
        </div>
      </template>
    </SfHeader>

    <section class="page-content">
      <router-view />
    </section>

    <PopupAccount :visible="isOpenPopup" @closePopUp="closePopUp" />

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
      isMobile: false,
      navigation: [
        { name: "Trang chủ", link: "/" },
        { name: "Phiên đã đấu", link: "/past-auction" },
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
      cartIcon: false,
      wishlistIcon: false,
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
  computed: {
    isOpenPopup() {
      return this.$store.state.account.togglePopUpLogin;
    },

    isLogged() {
      return this.$store.state.account.isLogged;
    },

    categories() {
      return this.$store.state.common.category;
    },
  },

  methods: {
    handleCategoryClick(command) {
      window.location.href = `/auction/${command}`;
    },

    openPopup() {
      this.$store.commit("account/setTogglePopupLogin", true);
    },

    closePopUp() {
      this.$store.commit("account/setTogglePopupLogin", false);
    },

    logout() {
      this.$store.dispatch("account/logout");
      location.reload();
    },
  },

  created() {
    this.$store.dispatch("common/getAllCategoryProduct");
    const logged = localStorage.getItem("isLogged");
    if (logged) {
      const user = JSON.parse(localStorage.getItem("user"));
      this.$store.commit("account/setLogged", true);
      this.$store.dispatch("common/getCurrentAuction");
      this.$store.dispatch("common/getCartByUserId", {
        userId: user.id,
      });
    }
  },
};
</script>

<style>
:root {
  --primary: teal;
  --link-text-decoration: none;
  --section-margin: 100px;
}
.page-content {
  padding-top: 32px;
  min-height: 60vh;
  max-width: 1240px;
  margin: auto;
}
.el-dropdown {
  display: flex !important;
}
</style>
