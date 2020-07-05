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
    AuctionServiceProxy,
    AuctionDto,
} from "@shared/service-proxies/service-proxies";

@Component({
    selector: "createOrEditAuctionModal",
    templateUrl: "./create-or-edit-auction-modal.component.html",
})
export class CreateOrEditAuctionModalComponent extends AppComponentBase {
    @ViewChild("createOrEditModal") modal: ModalDirective;
    @ViewChild("auctionCombobox") auctionCombobox: ElementRef;
    @ViewChild("iconCombobox") iconCombobox: ElementRef;
    @ViewChild("dateInput") dateInput: ElementRef;

    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;

    auction: AuctionDto = new AuctionDto();

    constructor(
        injector: Injector,
        private _auctionService: AuctionServiceProxy
    ) {
        super(injector);
    }

    show(auctionId?: number | null | undefined): void {
        this.saving = false;

        this._auctionService
            .getAuctionForEdit(auctionId)
            .subscribe((result) => {
                this.auction = result;
                this.modal.show();
            });
    }

    save(): void {
        let input = this.auction;
        this.saving = true;
        this._auctionService.createOrEditAuction(input).subscribe((result) => {
            this.notify.info(this.l("SavedSuccessfully"));
            this.close();
        });
    }

    close(): void {
        this.modal.hide();
        this.modalSave.emit(null);
    }

    genAuctionName = (id) => {
        return `Phiên đấu giá thứ ${id}`;
    };
}
