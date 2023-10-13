import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-delete-dish',
  templateUrl: './delete-dish.component.html',
  styleUrls: ['./delete-dish.component.css'],
})
export class DeleteDishComponent {
  constructor(
    public dialogRef: MatDialogRef<DeleteDishComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {}
}
