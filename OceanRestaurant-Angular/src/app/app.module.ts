import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { OrderComponent } from './order/order.component';
import { OrderDetailsComponent } from './order/order-details/order-details.component';
import { AddEditOrderComponent } from './order/add-edit-order/add-edit-order.component';
import { DeleteOrderComponent } from './order/delete-order/delete-order.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { DishComponent } from './dish/dish.component';
import { DishDetailsComponent } from './dish/dish-details/dish-details.component';
import { AddEditDishComponent } from './dish/add-edit-dish/add-edit-dish.component';
import { DeleteDishComponent } from './dish/delete-dish/delete-dish.component';
import { GuestComponent } from './guest/guest.component';
import { GuestDetailsComponent } from './guest/guest-details/guest-details.component';
import { DeleteGuestComponent } from './guest/delete-guest/delete-guest.component';
import { AddEditGuestComponent } from './guest/add-edit-guest/add-edit-guest.component';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { SharedModule } from './shared/shared.module';
import { ReactiveFormsModule } from '@angular/forms';
import { ImageUploaderComponent } from './upload/image-uploader.component';
import { EnumToArrayPipe } from 'src/pipes/enum-to-array.pip';
import { HomeComponent } from './home/home.component';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent,
    OrderComponent,
    OrderDetailsComponent,
    AddEditOrderComponent,
    DeleteOrderComponent,
    DishComponent,
    DishDetailsComponent,
    AddEditDishComponent,
    DeleteDishComponent,
    GuestComponent,
    GuestDetailsComponent,
    DeleteGuestComponent,
    AddEditGuestComponent,
    ImageUploaderComponent,
    EnumToArrayPipe,
    HomeComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    NgbModule,
    NgxDatatableModule,
    SharedModule,
    ReactiveFormsModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
