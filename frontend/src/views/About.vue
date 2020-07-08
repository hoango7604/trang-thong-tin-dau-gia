<template>
  <SfSection
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
        height: 18.75rem;

      "
    >
      <h4>
        Giới thiệu chung về Daugia.tv
      </h4>
      <p>
        Daugia.tv - Kênh đấu giá trực tuyến với mục tiêu đem lại lợi ích mua sắm
        khách hàng, mọi người đều có thể tham gia đấu giá sản phẩm.
      </p>
      <strong>
        1. Lợi ích khi tham gia Đấu Giá Trực Tuyến:
      </strong>
      <p>
        Mua hàng trên Daugia.tv được bảo đảm giao dịch cho đến khi giao dịch
        thành công Hoàn tiền 100% đối với đơn hàng không nhận được hàng, nhận
        không đúng hàng Được tham giá đấu giá cực kỳ thú vị mà không hề mất phí
      </p>
      <strong>
        2. Các phiên đấu giá khởi điểm với giá trị thấp!
      </strong>
      <p>
        Daugia.tv cung cấp đa dạng sản phẩm tại các phiên đấu giá với mức khởi
        điểm thấp theo từng sản phẩm.. Khách hàng sẽ quyết định mức giá sản phẩm
        bằng cách đấu giá với những người dùng khác để tìm ra giá tốt nhất. Đôi
        khi bạn sẽ bị trả giá cao hơn, nhưng nếu bạn kiên định bạn sẽ có những
        ưu đãi tuyệt vời mà không đâu có được.
      </p>

      <strong>
        3. Mua sắm an toàn, đơn giản
      </strong>

      <p>
        Chúng tôi đảm bảo thông tin khách hàng luôn được bảo mật. Chúng tôi sử
        dụng kết nối SSL đối với các thanh toán bằng thẻ để bạn có thể yên tâm
        không bị lừa đảo hay mất tiền. Hơn nữa, thông tin cá nhân của bạn được
        bảo mật tuyệt đối và không thể truy cập trái phép. Mua sắm tại Daugia.tv
        là một trải nghiệm thú vị và an toàn.
      </p>
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
      titleHeading: "Về chúng tôi",
      subtitleHeading: "#About Us",
      levelHeading: 2,
    };
  },
};
</script>
