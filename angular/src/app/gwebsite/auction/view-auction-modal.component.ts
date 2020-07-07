import { AuctionDto } from "../../../shared/service-proxies/service-proxies";
import { AppComponentBase } from "@shared/common/app-component-base";
import { AfterViewInit, Injector, Component, ViewChild } from "@angular/core";
import { AuctionServiceProxy } from "@shared/service-proxies/service-proxies";
import { ModalDirective } from "ngx-bootstrap";

@Component({
    selector: "viewAuctionModal",
    templateUrl: "./view-auction-modal.component.html",
})
export class ViewAuctionModalComponent extends AppComponentBase {
    auction: AuctionDto = new AuctionDto();
    @ViewChild("viewModal") modal: ModalDirective;

    constructor(
        injector: Injector,
        private _auctionService: AuctionServiceProxy
    ) {
        super(injector);
    }

    show(auctionId?: number | null | undefined): void {
        this._auctionService
            .getAuctionForView(auctionId)
            .subscribe((result) => {
                this.auction = result;
                this.modal.show();
            });
    }

    close(): void {
        this.modal.hide();
    }

    genAuctionName = (id) => {
        return `Phiên đấu giá thứ ${id}`;
    };
}
