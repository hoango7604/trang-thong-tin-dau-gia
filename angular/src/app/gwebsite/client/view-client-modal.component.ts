import { ClientDto } from "./../../../shared/service-proxies/service-proxies";
import { AppComponentBase } from "@shared/common/app-component-base";
import { AfterViewInit, Injector, Component, ViewChild } from "@angular/core";
import { ClientServiceProxy } from "@shared/service-proxies/service-proxies";
import { ModalDirective } from "ngx-bootstrap";

@Component({
    selector: "viewClientModal",
    templateUrl: "./view-client-modal.component.html",
})
export class ViewClientModalComponent extends AppComponentBase {
    client: ClientDto = new ClientDto();
    @ViewChild("viewModal") modal: ModalDirective;

    constructor(
        injector: Injector,
        private _clientService: ClientServiceProxy
    ) {
        super(injector);
    }

    show(clientId?: number | null | undefined): void {
        this._clientService.getClientForView(clientId).subscribe((result) => {
            this.client = result;
            this.modal.show();
        });
    }

    close(): void {
        this.modal.hide();
    }
}
