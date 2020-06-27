<template>
  <SfSection
    style="margin: 100px 100px!important"
    :title-heading="titleHeading"
    :subtitle-heading="subtitleHeading"
    :level-heading="levelHeading"
  >
    <div
      style="
        display: flex;
        align-items: flex-start;
        flex-direction: column;
        justify-content: flex-start;
      "
    >
      <h4>
        Liên hệ với Daugia.tv
      </h4>
      <p>
        <strong>
          Thông tin liên hệ
        </strong>
      </p>

      <ul>
        <li>
          CÔNG TY CỔ PHẦN TRỰC TUYẾN ĐĂNG QUANG
        </li>
        <li>
          Email: info@daugia.tv
        </li>
        <li>
          Điện thoại: 1800.6005 - 098.668.1189
        </li>
        <li>
          Địa chỉ: Số 9 Nguyễn Khánh Toàn - Cầu Giấy - Hà Nội.
        </li>
        <li>
          Chân thành cảm ơn quý khách!
        </li>
      </ul>
    </div>
  </SfSection>
</template>
<script>
import { SfSection } from "@storefront-ui/vue";
export default {
  components: {
    SfSection,
  },
  data() {
    return {
      titleHeading: "Liên hệ",
      subtitleHeading: "#Contact",
      levelHeading: 2,
    };
  },
};
</script>
