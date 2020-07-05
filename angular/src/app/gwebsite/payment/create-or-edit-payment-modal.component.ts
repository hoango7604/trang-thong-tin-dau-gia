import {
    Component,
    ElementRef,
    EventEmitter,
    Injector,
    Output,
    ViewChild,
} from "@angular/core";
import { AppComponentBase } from "@shared/common/app-component-base";
import { ModalDirective } from "ngx-bootstrap";
import {
    PaymentServiceProxy,
    PaymentDto,
} from "@shared/service-proxies/service-proxies";

@Component({
    selector: "createOrEditPaymentModal",
    templateUrl: "./create-or-edit-payment-modal.component.html",
})
export class CreateOrEditPaymentModalComponent extends AppComponentBase {
    @ViewChild("createOrEditModal") modal: ModalDirective;
    @ViewChild("paymentCombobox") auctionCombobox: ElementRef;
    @ViewChild("iconCombobox") iconCombobox: ElementRef;
    @ViewChild("dateInput") dateInput: ElementRef;

    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;

    payment: PaymentDto = new PaymentDto();

    constructor(
        injector: Injector,
        private _paymentService: PaymentServiceProxy
    ) {
        super(injector);
    }

    show(paymentId?: number | null | undefined): void {
        this.saving = false;

        this._paymentService
            .getPaymentForEdit(paymentId)
            .subscribe((result) => {
                this.payment = result;
                this.modal.show();
            });
    }

    save(): void {
        let input = this.payment;
        this.saving = true;
        this._paymentService.createOrEditPayment(input).subscribe((result) => {
            this.notify.info(this.l("SavedSuccessfully"));
            this.close();
        });
    }

    close(): void {
        this.modal.hide();
        this.modalSave.emit(null);
    }
}
