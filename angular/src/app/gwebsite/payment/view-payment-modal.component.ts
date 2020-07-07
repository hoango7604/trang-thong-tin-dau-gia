import { PaymentDto } from "../../../shared/service-proxies/service-proxies";
import { AppComponentBase } from "@shared/common/app-component-base";
import { AfterViewInit, Injector, Component, ViewChild } from "@angular/core";
import { PaymentServiceProxy } from "@shared/service-proxies/service-proxies";
import { ModalDirective } from "ngx-bootstrap";

@Component({
    selector: "viewPaymentModal",
    templateUrl: "./view-payment-modal.component.html",
})
export class ViewPaymentModalComponent extends AppComponentBase {
    payment: PaymentDto = new PaymentDto();
    @ViewChild("viewModal") modal: ModalDirective;

    constructor(
        injector: Injector,
        private _paymentService: PaymentServiceProxy
    ) {
        super(injector);
    }

    show(paymentId?: number | null | undefined): void {
        this._paymentService
            .getPaymentForView(paymentId)
            .subscribe((result) => {
                this.payment = result;
                this.modal.show();
            });
    }

    close(): void {
        this.modal.hide();
    }
}
