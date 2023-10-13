import { HttpErrorResponse } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { PageMode } from 'src/app/enums/pageMode.enum';
import { DishDetails } from 'src/app/models/dish/dishDetails.model';
import { DishService } from 'src/app/services/dish.service';

@Component({
  selector: 'app-add-edit-dish',
  templateUrl: './add-edit-dish.component.html',
  styleUrls: ['./add-edit-dish.component.css'],
})
export class AddEditDishComponent {
  dish?: DishDetails;
  dishForm!: FormGroup;
  dishId?: number;
  pageMode: PageMode = PageMode.Create;
  pageModeEnum = PageMode;

  constructor(
    private fb: FormBuilder,
    private dishSvc: DishService,
    private router: Router,
    private activatedRoute: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.buildForm();
    this.setDishId();
    this.setPageMode();
    if (this.pageMode == PageMode.Edit) {
      this.loadDish();
    }
  }

  addEditDish() {
    if (this.dishForm.valid) {
      if (this.pageMode == PageMode.Create) {
        this.dishSvc.addNewDish(this.dishForm.value).subscribe({
          next: () => {
            this.router.navigate(['/dish']);
          },
          error: (error: HttpErrorResponse) => {
            console.log(error);
          },
        });
      } else {
        this.dishSvc.editDish(this.dishId!, this.dishForm.value).subscribe({
          next: (dishFromApi) => {
            this.router.navigate(['/dish']);
          },
          error: (error: HttpErrorResponse) => {
            console.log(error);
          },
        });
      }
    }
  }

  private loadDish() {
    this.dishSvc.getDish(this.dishId!).subscribe({
      next: (dishFromApi) => {
        this.dish = dishFromApi;
        this.patchForm(dishFromApi);
      },
      error: (error: HttpErrorResponse) => {
        console.log(error);
      },
    });
  }

  private setPageMode(): void {
    if (this.dishId) {
      this.pageMode = PageMode.Edit;
    }
  }

  private setDishId(): void {
    this.dishId = Number(this.activatedRoute.snapshot.paramMap.get('id'));
  }

  private buildForm() {
    this.dishForm = this.fb.group({
      id: [0],
      name: ['', Validators.required],
      Price: [''],
      Details: ['', Validators.required],
    });
  }

  private patchForm(dishFromApi: DishDetails) {
    this.dishForm.patchValue({
      id: this.dishId,
      name: dishFromApi.name,
      Price: dishFromApi.Price,
      Details: dishFromApi.Details,
    });
  }
}
