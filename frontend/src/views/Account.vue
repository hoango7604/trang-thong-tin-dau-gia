<template>
  <el-tabs
    tab-position="left"
    style="height: auto;"
    class="container mt-5"
    @tab-click="handleClickTab"
  >
    <el-tab-pane label="Thông tin tài khoản">
      <el-card class="box-card">
        <div slot="header" class="clearfix">
          <b>Vui lòng nhập đầy đủ thông tin!</b>
        </div>
        <div class="text item">
          <el-form
            label-position="right"
            label-width="100px"
            ref="formUpdateUser"
            :model="formUpdateUser"
            :rules="rules"
          >
            <el-form-item label="Họ và tên: ">
              <el-input v-model="formUpdateUser.username"></el-input>
            </el-form-item>
            <el-form-item label="SĐT: ">
              <el-input v-model="formUpdateUser.phone"></el-input>
            </el-form-item>
            <el-form-item label="Email: ">
              <el-input v-model="formUpdateUser.email"></el-input>
            </el-form-item>
            <el-form-item label="Địa chỉ: ">
              <el-input v-model="formUpdateUser.address"></el-input>
            </el-form-item>
            <el-form-item label="Giới tính: ">
              <el-select
                v-model="formUpdateUser.gerder"
                placeholder="Giới tính: "
              >
                <el-option label="Nam" value="male"></el-option>
                <el-option label="Nữ" value="female"></el-option>
              </el-select>
            </el-form-item>
            <el-form-item class="d-flex justify-content-end">
              <el-button type="primary" @click="submitForm('formUpdateUser')"
                >Cập nhật thông tin</el-button
              >
            </el-form-item>
          </el-form>
        </div>
      </el-card>
    </el-tab-pane>
    <el-tab-pane label="Quản lý đơn hàng">
      <div>
        <div
          v-if="!products.length"
          class="d-flex align-items-center w-100 h-100"
          style="font-weight: 100"
        >
          Chưa đấu giá thành công sản phẩm nào!
        </div>
        <!-- product card  -->
        <div
          v-else
          class="d-flex justify-content-start p-3"
          v-for="(product, index) in products"
          :key="index"
        >
          <img
            :src="product.imageUrl"
            alt="#"
            width="110"
            class="img-fluid mb-4"
          />
          <div class="ml-3">
            <h4 class="mb-4">{{ product.name }}</h4>
            {{ product.currentPrice | formatCurrency }}
          </div>
        </div>
      </div>
    </el-tab-pane>
    <el-tab-pane label="Thay đổi mật khẩu">
      <el-card class="box-card">
        <div slot="header" class="clearfix">
          <b>Vui lòng nhập đầy đủ thông tin!</b>
        </div>
        <div class="text item">
          <el-form
            label-position="right"
            label-width="100px"
            ref="formResetPassword"
            :model="formResetPassword"
          >
            <el-form-item label="Mật khẩu cũ: ">
              <el-input v-model="formResetPassword.oldPassword"></el-input>
            </el-form-item>
            <el-form-item label="Mật khẩu mới: ">
              <el-input v-model="formResetPassword.newPassword"></el-input>
            </el-form-item>
            <el-form-item label="Nhập lại: ">
              <el-input
                v-model="formResetPassword.reTypeNewPassword"
              ></el-input>
            </el-form-item>
            <el-form-item class="d-flex justify-content-end">
              <el-button type="primary" @click="submitForm('formResetPassword')"
                >Thay đổi mật khẩu</el-button
              >
            </el-form-item>
          </el-form>
        </div>
      </el-card>
    </el-tab-pane>
    <el-tab-pane label="Đăng xuất"></el-tab-pane>
  </el-tabs>
</template>

<script>
export default {
  data() {
    return {
      formUpdateUser: {
        username: "",
        phone: "",
        email: "",
        address: "",
        gerder: "",
      },
      formResetPassword: {
        oldPassword: "",
        newPassword: "",
        reTypeNewPassword: "",
      },
      rules: {
        username: [
          {
            required: true,
            message: "Vui lòng nhập Tên",
            trigger: "blur",
          },
        ],
        phone: [
          {
            required: true,
            message: "Vui lòng nhập SĐT",
            trigger: "blur",
          },
        ],
        email: [
          {
            required: true,
            message: "Vui lòng nhập Email",
            trigger: "blur",
          },
        ],
        address: [
          {
            required: true,
            message: "Vui lòng nhập Địa chỉ",
            trigger: "blur",
          },
        ],
        gender: [
          {
            required: true,
            message: "Vui lòng chọn giới tính",
            trigger: "blur",
          },
        ],
      },

      products: [],
    };
  },
  methods: {
    submitForm(formName) {
      if (formName == "formUpdateUser") {
        this.$refs[formName].validate((valid) => {
          if (valid) {
            this.$store.dispatch("account/updateAccount", this.formUpdateUser);
          } else {
            return false;
          }
        });
      } else if (formName == "formResetPassword") {
        this.$store.dispatch("account/resetPassword", this.formResetPassword);
      }
    },

    handleClickTab(obj, e) {
      if (obj.label == "Đăng xuất") {
        this.$store.dispatch("account/logout");
      }
    },
  },

  created() {
    this.$store
      .dispatch("common/getCartByUserId", {
        userId: JSON.parse(localStorage.getItem("user")).id,
      })
      .then((data) => {
        this.products = data;
      });
  },
};
</script>
