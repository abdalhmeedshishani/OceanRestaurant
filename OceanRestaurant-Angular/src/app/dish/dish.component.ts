import { Component } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { DishService } from '../services/dish.service';
import { LoaderService } from '../services/loader.service';
import { DishList } from '../models/dish/dishList.model';
import { DeleteDishComponent } from './delete-dish/delete-dish.component';

@Component({
  selector: 'app-dish',
  templateUrl: './dish.component.html',
  styleUrls: ['./dish.component.css'],
})
export class DishComponent {
  dishes: DishList[] = [];
  dishId?: number;
  totalRequests = 0;

  constructor(
    private dishSvc: DishService,
    private dialog: MatDialog,
    private loadingSvc: LoaderService
  ) {}

  ngOnInit(): void {
    this.loadDishes();
  }

  deleteDish(id: number): void {
    let deleteDialogConfig: MatDialogConfig = {
      data: {
        dish: this.dishes.find((c) => c.id == id),
      },
      disableClose: true,
    };

    const dialogRef = this.dialog.open(DeleteDishComponent, deleteDialogConfig);

    dialogRef.afterClosed().subscribe((result) => {
      if (result == true) {
        this.dishSvc.deleteDish(id).subscribe({
          next: () => {
            this.loadDishes();
          },
        });
      }
    });
  }

  private loadDishes() {
    this.totalRequests++;
    this.loadingSvc.setLoading(true);

    this.dishSvc.getDishes().subscribe({
      next: (dishesFromApi) => {
        this.dishes = dishesFromApi;

        this.totalRequests--;
        if (this.totalRequests == 0) {
          this.loadingSvc.setLoading(false);
        }
      },
    });
  }
}
