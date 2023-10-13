import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { GuestComponent } from './guest/guest.component';
import { AddEditGuestComponent } from './guest/add-edit-guest/add-edit-guest.component';
import { DeleteGuestComponent } from './guest/delete-guest/delete-guest.component';
import { GuestDetailsComponent } from './guest/guest-details/guest-details.component';
import { DishComponent } from './dish/dish.component';
import { AddEditDishComponent } from './dish/add-edit-dish/add-edit-dish.component';
import { DeleteDishComponent } from './dish/delete-dish/delete-dish.component';
import { DishDetailsComponent } from './dish/dish-details/dish-details.component';
import { OrderComponent } from './order/order.component';
import { AddEditOrderComponent } from './order/add-edit-order/add-edit-order.component';
import { OrderDetailsComponent } from './order/order-details/order-details.component';
import { HomeComponent } from './home/home.component';

const routes: Routes = [
  { path: 'home', component: HomeComponent },

  { path: 'guest', component: GuestComponent },
  { path: 'guest/create', component: AddEditGuestComponent },
  { path: 'guest/edit/:id', component: AddEditGuestComponent },
  { path: 'guest/guest-details/:id', component: GuestDetailsComponent },

  { path: 'dish', component: DishComponent },
  { path: 'dish/create', component: AddEditDishComponent },
  { path: 'dish/edit/:id', component: AddEditDishComponent },
  { path: 'dish/dish-details/:id', component: DishDetailsComponent },

  { path: 'order', component: OrderComponent },
  { path: 'order/create', component: AddEditOrderComponent },
  { path: 'order/edit/:id', component: AddEditOrderComponent },
  { path: 'order/order-details/:id', component: OrderDetailsComponent },

  { path: '**', redirectTo: '/home', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
