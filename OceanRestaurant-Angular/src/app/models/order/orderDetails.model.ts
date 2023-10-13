import { CookingMethod } from "src/app/enums/cookingMethod.enum";
import { Dish } from "../dish/dish.model";

export interface OrderDetails {
  id: number;
  totalPrice: number;
  orderDate: Date;
  cookingMethod: CookingMethod
  notes: string;
  guestName: string;
  dishes: Dish[];
}
