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
    ProductServiceProxy,
    ProductDto,
    CategoryServiceProxy,
    CategoryDto,
    ClientServiceProxy,
    ClientDto,
    IAuctionDto,
    AuctionDto,
    AuctionServiceProxy,
} from "@shared/service-proxies/service-proxies";
import { flatMap } from "rxjs/operators";

interface IAuctionWithName extends IAuctionDto {
    name: string;
}

@Component({
    selector: "createOrEditProductModal",
    templateUrl: "./create-or-edit-product-modal.component.html",
})
export class CreateOrEditProductModalComponent extends AppComponentBase {
    @ViewChild("createOrEditModal") modal: ModalDirective;
    @ViewChild("productCombobox") productCombobox: ElementRef;
    @ViewChild("iconCombobox") iconCombobox: ElementRef;
    @ViewChild("dateInput") dateInput: ElementRef;

    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;

    winnerClient: ClientDto;
    winnerClientName: string;

    categories: CategoryDto[];
    selectedCategory: CategoryDto;

    auctions: IAuctionWithName[];
    selectedAuction: IAuctionWithName;

    isPaid: boolean;

    product: ProductDto = new ProductDto();

    constructor(
        injector: Injector,
        private _productService: ProductServiceProxy,
        private _categoryService: CategoryServiceProxy,
        private _clientService: ClientServiceProxy,
        private _auctionService: AuctionServiceProxy
    ) {
        super(injector);
        this.isPaid = false;
    }

    show(productId?: number | null | undefined): void {
        this.saving = false;

        this._productService
            .getProductForEdit(productId)
            .pipe(
                flatMap((result) => {
                    this.product = result;
                    this.product.stepPrice = 100000;

                    const clientId = result.winnerClientId;
                    return this._clientService.getClientForView(clientId);
                })
            )
            .subscribe((result) => {
                this.winnerClient = result;
                this.winnerClientName = result.fullName;
                this.modal.show();
            });

        this._categoryService
            .getCategorysByFilter(undefined, undefined, 100, 0)
            .subscribe((result) => {
                this.categories = result.items;
            });

        this._auctionService
            .getAuctionsByFilter(
                undefined,
                undefined,
                undefined,
                undefined,
                undefined,
                100,
                0
            )
            .subscribe((result) => {
                const { items } = result;
                const auctions = items.reverse().map((item) => ({
                    ...item,
                    name: this.genAuctionName(item.id),
                }));
                this.auctions = auctions;
            });
    }

    onChange = (event) => {
        const startPrice = event.target.value * 0.6;
        this.product.startPrice = startPrice;
        this.product.currentPrice = startPrice;
    };

    save(): void {
        let input = this.product;
        if (this.selectedCategory) {
            input.categoryId = this.selectedCategory.id;
        }
        if (this.selectedAuction) {
            input.auctionId = this.selectedAuction.id;
        }
        input.isPaid = this.isPaid;
        this.saving = true;
        this._productService.createOrEditProduct(input).subscribe((result) => {
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
