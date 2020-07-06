import {
    Component,
    ElementRef,
    EventEmitter,
    Injector,
    Output,
    ViewChild,
    AfterViewChecked,
    AfterViewInit,
} from "@angular/core";
import { AppComponentBase } from "@shared/common/app-component-base";
import { ModalDirective } from "ngx-bootstrap";
import {
    AuctionServiceProxy,
    AuctionDto,
} from "@shared/service-proxies/service-proxies";
import * as moment from "moment";

@Component({
    selector: "createOrEditAuctionModal",
    templateUrl: "./create-or-edit-auction-modal.component.html",
})
export class CreateOrEditAuctionModalComponent extends AppComponentBase
    implements AfterViewInit {
    @ViewChild("createOrEditModal") modal: ModalDirective;
    @ViewChild("auctionCombobox") auctionCombobox: ElementRef;
    @ViewChild("iconCombobox") iconCombobox: ElementRef;
    @ViewChild("startDateInput") startDateInput: ElementRef;
    @ViewChild("endDateInput") endDateInput: ElementRef;

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

    ngAfterViewInit(): void {
        $(this.startDateInput.nativeElement).datetimepicker({
            locale: "vi",
            format: "L LT",
        });
        $(this.endDateInput.nativeElement).datetimepicker({
            locale: "vi",
            format: "L LT",
        });
    }

    show(auctionId?: number | null | undefined): void {
        this.saving = false;

        this._auctionService
            .getAuctionForEdit(auctionId)
            .subscribe((result) => {
                this.auction = result;
                const startDate = moment(result.startDate).format(
                    "DD/MM/YYYY HH:mm"
                );
                const endDate = moment(result.endDate).format(
                    "DD/MM/YYYY HH:mm"
                );
                $(this.startDateInput.nativeElement)
                    .data("DateTimePicker")
                    .date(startDate);
                $(this.endDateInput.nativeElement)
                    .data("DateTimePicker")
                    .date(endDate);
                this.modal.show();
            });
    }

    save(): void {
        let input = this.auction;
        this.saving = true;
        const startDate = moment(
            $(this.startDateInput.nativeElement)
                .data("DateTimePicker")
                .date()
                .format("YYYY-MM-DDTHH:mm:ssZ")
        )
            .utc()
            .format();
        const endDate = moment(
            $(this.endDateInput.nativeElement)
                .data("DateTimePicker")
                .date()
                .format("YYYY-MM-DDTHH:mm:ssZ")
        )
            .utc()
            .format();
        input.startDate = startDate;
        input.endDate = endDate;
        // console.log(input);

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
