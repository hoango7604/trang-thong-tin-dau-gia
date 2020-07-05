import { CustomerServiceProxy } from "./../../shared/service-proxies/service-proxies";
import { ViewDemoModelModalComponent } from "./demo-model/view-demo-model-modal.component";
import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { FormsModule } from "@angular/forms";
import { AppCommonModule } from "@app/shared/common/app-common.module";
import { UtilsModule } from "@shared/utils/utils.module";
import { FileUploadModule } from "ng2-file-upload";
import {
    ModalModule,
    PopoverModule,
    TabsModule,
    TooltipModule,
} from "ngx-bootstrap";
import {
    AutoCompleteModule,
    EditorModule,
    FileUploadModule as PrimeNgFileUploadModule,
    InputMaskModule,
    PaginatorModule,
} from "primeng/primeng";
import { TableModule } from "primeng/table";
import { GWebsiteRoutingModule } from "./gwebsite-routing.module";

import {
    MenuClientComponent,
    CreateOrEditMenuClientModalComponent,
} from "./index";
import { DemoModelComponent } from "./demo-model/demo-model.component";
import { CreateOrEditDemoModelModalComponent } from "./demo-model/create-or-edit-demo-model-modal.component";
import { DemoModelServiceProxy } from "@shared/service-proxies/service-proxies";
import { CustomerComponent } from "./customer/customer.component";
import { ViewCustomerModalComponent } from "./customer/view-customer-modal.component";
import { CreateOrEditCustomerModalComponent } from "./customer/create-or-edit-customer-modal.component";
import { CustomUserComponent } from "./custom-user/custom-user.component";

import { ViewClientModalComponent } from "./client/view-client-modal.component";
import { CreateOrEditClientModalComponent } from "./client/create-or-edit-client-modal.component";
import { ClientComponent } from "./client/client.component";
import { ViewAuctionModalComponent } from "./auction/view-auction-modal.component";
import { CreateOrEditAuctionModalComponent } from "./auction/create-or-edit-auction-modal.component";
import { AuctionComponent } from "./auction/auction.component";
import { ViewProductModalComponent } from "./product/view-product-modal.component";
import { CreateOrEditProductModalComponent } from "./product/create-or-edit-product-modal.component";
import { ProductComponent } from "./product/product.component";
import { ViewCategoryModalComponent } from "./category/view-category-modal.component";
import { CreateOrEditCategoryModalComponent } from "./category/create-or-edit-category-modal.component";
import { CategoryComponent } from "./category/category.component";
import { ViewPaymentModalComponent } from "./payment/view-payment-modal.component";
import { CreateOrEditPaymentModalComponent } from "./payment/create-or-edit-payment-modal.component";
import { PaymentComponent } from "./payment/payment.component";

import {
    ClientServiceProxy,
    AuctionServiceProxy,
    ProductServiceProxy,
    CategoryServiceProxy,
    PaymentServiceProxy,
} from "@shared/service-proxies/service-proxies";

@NgModule({
    imports: [
        FormsModule,
        CommonModule,
        FileUploadModule,
        ModalModule.forRoot(),
        TabsModule.forRoot(),
        TooltipModule.forRoot(),
        PopoverModule.forRoot(),
        GWebsiteRoutingModule,
        UtilsModule,
        AppCommonModule,
        TableModule,
        PaginatorModule,
        PrimeNgFileUploadModule,
        AutoCompleteModule,
        EditorModule,
        InputMaskModule,
    ],
    declarations: [
        MenuClientComponent,
        CreateOrEditMenuClientModalComponent,
        DemoModelComponent,
        CreateOrEditDemoModelModalComponent,
        ViewDemoModelModalComponent,
        CustomerComponent,
        CreateOrEditCustomerModalComponent,
        ViewCustomerModalComponent,
        CustomUserComponent,

        ClientComponent,
        CreateOrEditClientModalComponent,
        ViewClientModalComponent,
        AuctionComponent,
        CreateOrEditAuctionModalComponent,
        ViewAuctionModalComponent,
        ProductComponent,
        CreateOrEditProductModalComponent,
        ViewProductModalComponent,
        CategoryComponent,
        CreateOrEditCategoryModalComponent,
        ViewCategoryModalComponent,
        PaymentComponent,
        CreateOrEditPaymentModalComponent,
        ViewPaymentModalComponent,
    ],
    providers: [
        DemoModelServiceProxy,
        CustomerServiceProxy,

        ClientServiceProxy,
        AuctionServiceProxy,
        ProductServiceProxy,
        CategoryServiceProxy,
        PaymentServiceProxy,
    ],
})
export class GWebsiteModule {}
