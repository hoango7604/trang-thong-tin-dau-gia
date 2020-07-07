import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { MenuClientComponent } from "@app/gwebsite/menu-client/menu-client.component";
import { DemoModelComponent } from "./demo-model/demo-model.component";
import { CustomerComponent } from "./customer/customer.component";

import { ClientComponent } from "./client/client.component";
import { AuctionComponent } from "./auction/auction.component";
import { ProductComponent } from "./product/product.component";
import { CategoryComponent } from "./category/category.component";
import { PaymentComponent } from "./payment/payment.component";

@NgModule({
    imports: [
        RouterModule.forChild([
            {
                path: "",
                children: [
                    {
                        path: "menu-client",
                        component: MenuClientComponent,
                        data: { permission: "Pages.Administration.MenuClient" },
                    },
                ],
            },
            {
                path: "",
                children: [
                    {
                        path: "demo-model",
                        component: DemoModelComponent,
                        data: { permission: "Pages.Administration.DemoModel" },
                    },
                ],
            },
            {
                path: "",
                children: [
                    {
                        path: "customer",
                        component: CustomerComponent,
                        data: { permission: "Pages.Administration.Customer" },
                    },
                ],
            },
            {
                path: "",
                children: [
                    {
                        path: "client",
                        component: ClientComponent,
                        // data: { permission: 'Pages.Administration.Customer' }
                    },
                ],
            },
            {
                path: "",
                children: [
                    {
                        path: "auction",
                        component: AuctionComponent,
                        // data: { permission: 'Pages.Administration.Customer' }
                    },
                ],
            },
            {
                path: "",
                children: [
                    {
                        path: "product",
                        component: ProductComponent,
                        // data: { permission: 'Pages.Administration.Customer' }
                    },
                ],
            },
            {
                path: "",
                children: [
                    {
                        path: "category",
                        component: CategoryComponent,
                        // data: { permission: 'Pages.Administration.Customer' }
                    },
                ],
            },
            {
                path: "",
                children: [
                    {
                        path: "payment",
                        component: PaymentComponent,
                        // data: { permission: 'Pages.Administration.Customer' }
                    },
                ],
            },
        ]),
    ],
    exports: [RouterModule],
})
export class GWebsiteRoutingModule {}
