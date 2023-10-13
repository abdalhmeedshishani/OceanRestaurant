import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Order } from '../models/order/order.model';
import { OrderDetails } from '../models/order/orderDetails.model';
import { environment } from 'src/environments/environment';
import { OrderList } from '../models/order/orderList.model';

@Injectable({
  providedIn: 'root',
})
export class OrderService {
  apiUrl = `${environment.apiUrl}/Orders`;

  constructor(private http: HttpClient) {}

  getOrders(): Observable<OrderList[]> {
    return this.http.get<OrderList[]>(`${this.apiUrl}/GetOrders`);
  }
  getOrder(id: number): Observable<OrderDetails> {
    return this.http.get<OrderDetails>(`${this.apiUrl}/GetOrder/${id}`);
  }

  addNewOrder(order: Order): Observable<Order> {
    return this.http.post<Order>(`${this.apiUrl}/CreateOrder`, order);
  }
  editOrder(id: number, order: Order): Observable<Order> {
    return this.http.put<Order>(`${this.apiUrl}/EditOrder/${id}`, order);
  }

  getEditOrder(id: number): Observable<Order> {
    return this.http.get<Order>(`${this.apiUrl}/GetEditOrder/${id}`);
  }

  deleteOrder(id: number): Observable<Order> {
    return this.http.delete<Order>(`${this.apiUrl}/DeleteOrder/${id}`);
  }

  totalPrice(dishIds: number[]): Observable<number> {
    return this.http.post<number>(`${this.apiUrl}/GetOrderTotalPrice`, dishIds);
  }
}
