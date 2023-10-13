import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-delete-guest',
  templateUrl: './delete-guest.component.html',
  styleUrls: ['./delete-guest.component.css'],
})
export class DeleteGuestComponent implements OnInit {
  constructor(
    public dialogRef: MatDialogRef<DeleteGuestComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {}

  ngOnInit(): void {}
}
