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
      "
    >
      <h4>
        Thanh toán thuận tiện dễ dàng
      </h4>
      <p>
        Daugia.tv cung cấp các công cụ thanh toán cực kỳ tiện lợi và dễ dàng sử
        dụng với tât cả các khách hàng, gồm 3 hình thức thanh toán
      </p>
      <strong>
        1. Thanh toán tiền mặt tại nhà khi nhận hàng thông qua hình thức giao
        hàng trực tiếp, chuyển phát nhanh hoặc COD:
      </strong>

      <ul>
        <li>
          Khi nhân viên giao hàng giao phát, khách hàng kiểm tra sản phẩm về
          hình thức đảm bảo, khách hàng nhận hàng và thanh toán trực tiếp cho
          nhân viên giao hàng theo giá trị tiền trên hóa đơn. Ngoài ra khách
          hàng không phải thanh toán bất kỳ 1 chi phí nào khác.
        </li>
        <li>
          Đơn giản, An toàn, Không chút rắc rối mà lại an tâm tuyệt đối khi quý
          khách chọn thanh toán COD tại Daugia.tv
        </li>
      </ul>

      <strong>
        2. Thanh toán tiền mặt tại cửa hàng:
      </strong>

      <ul>
        <li>
          Khách hàng đến cửa hàng tham quan, mua sản phẩm sẽ thanh toán trực
          tiếp bằng tiền mặt hoặc quẹt thẻ qua POS ngân hàng tại cửa hàng.
        </li>
      </ul>

      <strong>
        3. Chuyển khoản qua ngân hàng:
      </strong>

      <ul>
        <li>
          Nếu địa điểm giao hàng là ngoại thành, ngoại tỉnh nhưng khác với địa
          điểm thanh toán (trong trường hợp Quý khách gửi quà, gửi hàng cho bạn
          bè, đối tác …) chúng tôi sẽ thu tiền trước 100% giá trị hàng bằng
          phương thức chuyển khoản trước khi giao hàng. Khách hàng được miễn phí
          vận chuyển
        </li>
        <li>
          Khách hàng có thể hoàn toàn yên tâm với hình thức thanh toán này. vì
          khi chuyển tiền ở ngân hàng , ngân hàng sẽ đưa cho bạn một giấy ủy
          nhiệm chi trong đó có số tiền và số TK mà bạn chuyển tiền tới, nên các
          bạn không phải lo lắng mình chuyển tiền rồi mà ĐĂNG QUANG WATCH không
          chuyển hàng, giấy ủy nhiệm chi đó chính là bằng chứng bạn đã chuyển
          tiền và ngân hàng mà bạn chuyên tiền có thể làm rõ điều đó cho bạn.
          Chúng tôi bán hàng luôn đăt chữ tín lên đầu và luôn cố gắng có những
          chất lượng dịch vụ tốt nhất với khách hàng.
        </li>
        <li>
          a. Thanh toán chuyển khoản trực tiếp (nhận hàng sau):
        </li>
        <li>
          Chủ tài khoản: Đặng Vinh Quang
        </li>
        <li>
          Số tài khoản: 12410006669669 Ngân hàng Đầu tư và phát triển BIDV Chi
          nhánh Hoàn Kiếm - Hà Nội
        </li>
        <li>
          Số tài khoản : 1604205334030 Ngân hàng Agribank chi nhánh Phú Nhuận –
          TP HCM
        </li>
        <li>
          Ngay sau khi chúng tôi nhận được tiền, Qúy khách sẽ nhận được hàng từ
          2-3 ngày.
        </li>
        <li>
          Để biết thêm thông tin chi tiết, Quý khách vui lòng liên hệ trực tiếp
          với nhân viên tư vấn bán hàng hoặc liên hệ theo số tổng đài miễn phí
          18006005 để được hỗ trợ.
        </li>
        <li>
          Xin trân trọng cảm ơn!
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
      titleHeading: "Phương thức thanh toán",
      subtitleHeading: "#Payment Methods",
      levelHeading: 2,
    };
  },
};
</script>
