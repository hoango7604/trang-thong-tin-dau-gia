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
    ClientServiceProxy,
    ClientDto,
} from "@shared/service-proxies/service-proxies";

@Component({
    selector: "createOrEditClientModal",
    templateUrl: "./create-or-edit-client-modal.component.html",
})
export class CreateOrEditClientModalComponent extends AppComponentBase {
    @ViewChild("createOrEditModal") modal: ModalDirective;
    @ViewChild("clientCombobox") clientCombobox: ElementRef;
    @ViewChild("iconCombobox") iconCombobox: ElementRef;
    @ViewChild("dateInput") dateInput: ElementRef;

    /**
     * @Output dùng để public event cho component khác xử lý
     */
    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    saving = false;

    client: ClientDto = new ClientDto();

    constructor(
        injector: Injector,
        private _clientService: ClientServiceProxy
    ) {
        super(injector);
    }

    show(clientId?: number | null | undefined): void {
        this.saving = false;

        this._clientService.getClientForEdit(clientId).subscribe((result) => {
            this.client = result;
            this.modal.show();
        });
    }

    save(): void {
        let input = this.client;
        this.saving = true;
        this._clientService.createOrEditClient(input).subscribe((result) => {
            this.notify.info(this.l("SavedSuccessfully"));
            this.close();
        });
    }

    close(): void {
        this.modal.hide();
        this.modalSave.emit(null);
    }
}
