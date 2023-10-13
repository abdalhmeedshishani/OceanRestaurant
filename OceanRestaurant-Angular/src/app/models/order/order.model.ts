import { CookingMethod } from 'src/app/enums/cookingMethod.enum';

export interface Order {
  id: number;
  dishName: string;
  notes: string;
  cookingMethod: CookingMethod;
  guestId: number[];
  dishIds: number[];
}
