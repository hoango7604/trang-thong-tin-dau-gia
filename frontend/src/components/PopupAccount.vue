<template>
  <SfModal
    :visible="visible"
    :title="title"
    :overlay="overlay"
    :cross="cross"
    :persistent="persistent"
    @close="close"
  >
    <div>
      <SfTabs :open-tab="openTab">
        <SfTab title="Đăng nhập">
          <div class="d-flex justify-content-center">
            <SfAlert :message="messageLogin" :type="type" />
          </div>
          <div class="mt-2">
            <SfInput
              v-model="formLogin.phone"
              type="text"
              label="Nhập Số điện thoại"
              name="phone"
              :valid="valid"
              :error-message="errorMessage"
              :required="required"
            />
            <SfInput
              v-model="formLogin.password"
              type="password"
              label="Nhập Mật khẩu"
              name="password"
              :valid="valid"
              :error-message="errorMessage"
              :required="required"
            />
          </div>
          <div class="mt-1 d-flex justify-content-center">
            <SfButton @click="actionLogin()">
              Đăng nhập
            </SfButton>
          </div>
        </SfTab>
        <SfTab title="Đăng ký">
          <div class="d-flex justify-content-center">
            <SfAlert :message="messageRegister" :type="type" />
          </div>
          <div class="mt-2">
            <SfInput
              v-model="formRegister.fullName"
              type="text"
              label="Họ và tên"
              name="fullName"
              :valid="valid"
              :error-message="errorMessage"
              :required="required"
            />
            <SfInput
              v-model="formRegister.phone"
              type="text"
              label="Nhập Số điện thoại"
              name="phone"
              :valid="valid"
              :error-message="errorMessage"
              :required="required"
            />

            <SfInput
              v-model="formRegister.password"
              type="password"
              label="Nhập Mật khẩu"
              name="password"
              :valid="valid"
              :error-message="errorMessage"
              :required="required"
            />
            <SfInput
              v-model="formRegister.rePassword"
              type="password"
              label="Nhập lại Mật khẩu"
              name="rePassword"
              :valid="valid"
              :error-message="errorMessage"
              :required="required"
            />
          </div>
          <div class="mt-1 d-flex justify-content-center">
            <SfButton @click="actionRegister()">
              Đăng kí
            </SfButton>
          </div>
        </SfTab>
      </SfTabs>
    </div>
  </SfModal>
</template>
<script>
import { SfModal } from "@storefront-ui/vue";
import { SfTabs } from "@storefront-ui/vue";
import { SfAlert } from "@storefront-ui/vue";
import { SfInput } from "@storefront-ui/vue";
import { SfButton } from "@storefront-ui/vue";
export default {
  components: {
    SfModal,
    SfTabs,
    SfAlert,
    SfInput,
    SfButton,
  },

  props: { visible: Boolean, default: true },

  data() {
    return {
      title: "My title",
      overlay: true,
      cross: true,
      persistent: false,
      openTab: 1,
      messageLogin:
        "Quý khách vui lòng đăng nhập hoặc đăng ký tài khoản để tham gia đấu giá!",
      type: "info",
      formLogin: {
        phone: "",
        password: "",
      },
      messageRegister: "Vui lòng nhập đầy đủ thông tin",
      formRegister: {
        fullName: "",
        phone: "",
        password: "",
        rePassword: "",
      },
      errorMessage: "Required.",
      valid: true,
      required: true,
    };
  },

  computed: {
    isErrorLogin() {
      return this.$store.state.account.isErrorLogin;
    },
  },

  methods: {
    close() {
      this.$emit("closePopUp");
    },
    actionLogin() {
      this.$store.dispatch("account/login", this.formLogin);
      if (!this.isErrorLogin) {
        location.reload();
      }
    },

    actionRegister() {
      const { rePassword, password } = this.formRegister;
      if (rePassword !== password) {
        //show error
      } else {
        this.$store.dispatch("account/register", this.formRegister);
      }
    },
  },
};
</script>
