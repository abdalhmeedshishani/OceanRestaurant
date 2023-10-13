import { Component, Input, OnInit } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { Gender } from '../enums/gender.enum';
import { Guest } from '../models/guest/guest.model';
import { GuestService } from '../services/guest.service';
import { LoaderService } from '../services/loader.service';
import { DeleteGuestComponent } from './delete-guest/delete-guest.component';

@Component({
  selector: 'app-guest',
  templateUrl: './guest.component.html',
  styleUrls: ['./guest.component.css'],
})
export class GuestComponent implements OnInit {
  guests: Guest[] = [];
  gender = Gender;
  guestId?: number;
  totalRequests = 0;

  constructor(
    private guestSvc: GuestService,
    private dialog: MatDialog,
    private loadingService: LoaderService
  ) {}

  ngOnInit(): void {
    this.loadGuests();
  }

  deleteGuest(id: number): void {
    let deleteDialogConfig: MatDialogConfig = {
      data: {
        guest: this.guests.find((c) => c.id == id),
      },
      disableClose: true,
    };

    const dialogRef = this.dialog.open(
      DeleteGuestComponent,
      deleteDialogConfig
    );

    dialogRef.afterClosed().subscribe((result) => {
      if (result == true) {
        this.guestSvc.deleteGuest(id).subscribe({
          next: () => {
            this.loadGuests();
          },
        });
      }
    });
  }

  private loadGuests() {
    this.totalRequests++;
    this.loadingService.setLoading(true);
    this.guestSvc.getGuests().subscribe({
      next: (guestsFromApi) => {
        this.guests = guestsFromApi;
        this.totalRequests--;
        if (this.totalRequests == 0) {
          this.loadingService.setLoading(false);
        }
      },
    });
  }
}
