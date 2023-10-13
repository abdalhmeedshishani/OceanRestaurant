import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { OrderList } from '../models/order/orderList.model';
import { OrderService } from '../services/order.service';
import { DeleteOrderComponent } from './delete-order/delete-order.component';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.css'],
})
export class OrderComponent implements OnInit {
  orders: OrderList[] = [];

  constructor(private orderSvc: OrderService, private dialog: MatDialog) {}

  ngOnInit(): void {
    this.loadOrders();
  }
  private loadOrders() {
    this.orderSvc.getOrders().subscribe({
      next: (ordersFromApi) => {
        this.orders = ordersFromApi;
      },
      error: (error: HttpErrorResponse) => {
        console.log(error.message);
      },
    });
  }

  deleteOrder(id: number): void {
    let deleteDialogConfig: MatDialogConfig = {
      data: {
        order: this.orders.find((c) => c.id == id),
      },
      disableClose: true,
    };
    const dialogRef = this.dialog.open(
      DeleteOrderComponent,
      deleteDialogConfig
    );

    dialogRef.afterClosed().subscribe((result) => {
      if (result == true) {
        this.orderSvc.deleteOrder(id).subscribe({
          next: () => {
            this.loadOrders();
          },
        });
      }
    });
  }
}
