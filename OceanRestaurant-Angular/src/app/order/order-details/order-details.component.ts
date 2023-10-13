import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CookingMethod } from 'src/app/enums/cookingMethod.enum';
import { OrderDetails } from 'src/app/models/order/orderDetails.model';
import { OrderService } from 'src/app/services/order.service';

@Component({
  selector: 'app-order-details',
  templateUrl: './order-details.component.html',
  styleUrls: ['./order-details.component.css'],
})
export class OrderDetailsComponent implements OnInit {
  order?: OrderDetails;
  cookingMethod = CookingMethod;

  constructor(
    private orderSvc: OrderService,
    private activatedRoute: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.orderDetails();
    this.setOrderDetailsId();
  }

  private orderDetails() {
    let orderId = this.setOrderDetailsId();

    this.orderSvc.getOrder(orderId).subscribe({
      next: (ordersFromApi) => {
        this.order = ordersFromApi;
      },
    });
  }

  private setOrderDetailsId(): number {
    return Number(this.activatedRoute.snapshot.paramMap.get('id'));
  }
}
