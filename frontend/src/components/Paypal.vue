<template>
  <div>
    <div ref="paypal_sdk" id="paypal-button-container"></div>
  </div>
</template>

<script>
const URL_PAYPAL =
  "https://www.paypal.com/sdk/js?client-id=AUFrlin40XhXjV7-zxyn0YOtvST2fC3KcV30XSOK0fjGbkA5xwMDR3XKI_X1n1Qve9iLBIAUvhdDTHZu&disable-funding=credit,card&commit=false";

export default {
  props: {
    payment: { type: Object },
    products: { type: Array, default: [] },
    user: { type: Object, default: {} },
  },

  data() {
    return {
      loaded: false,
      paidFor: false,
    };
  },

  mounted() {
    const script = document.createElement("script");
    script.setAttribute("data-namespace", "paypal_sdk");
    script.src = URL_PAYPAL;
    script.addEventListener("load", this.setLoaded);
    document.body.appendChild(script);
  },

  methods: {
    setLoaded() {
      this.loaded = true;
      window.paypal_sdk
        .Buttons({
          style: {
            layout: "vertical",
            color: "gold",
            label: "checkout",
            shape: "rect",
            size: "responsive",
            tagline: false,
          },
          createOrder: async (data, actions) => {
            return actions.order.create({
              purchase_units: [
                {
                  description: this.payment.description,
                  amount: {
                    currency_code: this.payment.currency,
                    value: this.payment.total,
                  },
                },
              ],
            });
          },
          onApprove: async (data, actions) => {
            const order = await actions.order.get();
            this.paidFor = true;

            if (this.products.length) {
              for (const product of this.products) {
                await this.$store.dispatch("common/finishPayment", {
                  userId: this.user.id,
                  address: this.user.address,
                  productId: product.id,
                  price: product.currentPrice,
                });
              }
              await window.open("/", "_self");
            }
          },
          onError: (err) => {
            console.log(err);
          },
        })
        .render(this.$refs.paypal_sdk);
    },
  },
};
</script>
