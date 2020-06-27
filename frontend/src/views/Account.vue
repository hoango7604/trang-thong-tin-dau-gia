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
            ref="formEditUser"
            :model="formEditUser"
            :rules="rules"
          >
            <el-form-item label="Họ và tên: ">
              <el-input v-model="formEditUser.username"></el-input>
            </el-form-item>
            <el-form-item label="SĐT: ">
              <el-input v-model="formEditUser.phone"></el-input>
            </el-form-item>
            <el-form-item label="Email: ">
              <el-input v-model="formEditUser.email"></el-input>
            </el-form-item>
            <el-form-item label="Địa chỉ: ">
              <el-input v-model="formEditUser.address"></el-input>
            </el-form-item>
            <el-form-item label="Giới tính: ">
              <el-select
                v-model="formEditUser.gerder"
                placeholder="Giới tính: "
              >
                <el-option label="Nam" value="male"></el-option>
                <el-option label="Nữ" value="female"></el-option>
              </el-select>
            </el-form-item>
            <el-form-item class="d-flex justify-content-end">
              <el-button type="primary" @click="submitForm('formEditUser')"
                >Cập nhật thông tin</el-button
              >
            </el-form-item>
          </el-form>
        </div>
      </el-card>
    </el-tab-pane>
    <el-tab-pane label="Quản lý đơn hàng">Quản lí đơn hàng</el-tab-pane>
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
      formEditUser: {
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
    };
  },
  methods: {
    submitForm(formName) {
      if (formName == "formEditUser") {
        this.$refs[formName].validate((valid) => {
          if (valid) {
            console.log(this.formEditUser);
            alert("submit!");
          } else {
            console.log("error submit!!");
            return false;
          }
        });
      } else if (formName == "formResetPassword") {
        console.log(this.formResetPassword);
      }
    },

    handleClickTab(obj, e) {
      console.log(obj.label);
      if (obj.label == "Đăng xuất") {
        console.log("Logout");
      }
    },
  },
};
</script>
