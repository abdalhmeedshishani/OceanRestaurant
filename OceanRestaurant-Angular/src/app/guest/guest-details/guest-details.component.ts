import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Gender } from 'src/app/enums/gender.enum';
import { GuestDetails } from 'src/app/models/guest/guestDetails.model';
import { GuestService } from 'src/app/services/guest.service';
import { ImageUploaderConfig } from 'src/app/upload/image-uploader.config';
import { UploaderImage } from 'src/app/upload/UploaderImage.data';
import {
  UploaderMode,
  UploaderStyle,
  UploaderType,
} from 'src/app/upload/uploaderMode.enum';

@Component({
  selector: 'app-guest-details',
  templateUrl: './guest-details.component.html',
  styleUrls: ['./guest-details.component.css'],
})
export class GuestDetailsComponent implements OnInit {
  guest?: GuestDetails;
  gender = Gender;

  images: UploaderImage[] = [];

  uploaderConfig = new ImageUploaderConfig(
    UploaderStyle.Normal,
    UploaderMode.Details,
    UploaderType.Single
  );

  constructor(
    private guestSvc: GuestService,
    private route: Router,
    private activatedRoute: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.loadGuestDetails();
    this.setGuestId();
  }

  private loadGuestDetails() {
    let guestId = this.setGuestId();

    if (guestId) {
      this.guestSvc.getGuest(guestId).subscribe({
        next: (guestFromApi) => {
          this.guest = guestFromApi;

          if (guestFromApi.images) {
            this.images = guestFromApi.images;
          }
        },
        error: (e: HttpErrorResponse) => {
          console.log(e);
          this.route.navigate(['not-found']);
        },
        complete: () => {
          console.info('complete');
        },
      });
    }
  }

  private setGuestId(): number {
    return Number(this.activatedRoute.snapshot.paramMap.get('id'));
  }
}
