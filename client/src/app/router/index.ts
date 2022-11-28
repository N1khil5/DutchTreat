import { RouterModule } from "@angular/router";
import { Checkout } from "../pages/checkout.component";
import { LoginPage } from "../pages/loginPage.component";
import { shopPage } from "../pages/shopPage.component";
import { AuthActivator } from "../services/authActivator.service";

const routes = [
    { path: "", component: shopPage },
    { path: "checkout", component: Checkout, canActivate: [AuthActivator] },
    { path: "login", component: LoginPage },
    { path: "**", redirectTo: "/"}
];

const router = RouterModule.forRoot(routes, {
    useHash: false
    });

export default router;