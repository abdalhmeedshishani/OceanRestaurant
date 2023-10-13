import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Gender } from 'src/app/enums/gender.enum';
import { PageMode } from 'src/app/enums/pageMode.enum';
import { Guest } from 'src/app/models/guest/guest.model';
import { GuestService } from 'src/app/services/guest.service';
import { ImageUploaderConfig } from 'src/app/upload/image-uploader.config';
import { UploaderImage } from 'src/app/upload/UploaderImage.data';
import {
  UploaderMode,
  UploaderStyle,
  UploaderType,
} from 'src/app/upload/uploaderMode.enum';

@Component({
  selector: 'app-add-edit-guest',
  templateUrl: './add-edit-guest.component.html',
  styleUrls: ['./add-edit-guest.component.css'],
})
export class AddEditGuestComponent implements OnInit {
  guest?: Guest;
  guestForm!: FormGroup;
  genderEnum = Gender;
  guestId?: number;
  pageMode: PageMode = PageMode.Create;
  pageModeEnum = PageMode;

  images: UploaderImage[] = [];

  uploaderConfig = new ImageUploaderConfig(
    UploaderStyle.Normal,
    UploaderMode.AddEdit,
    UploaderType.Single
  );

  constructor(
    private fb: FormBuilder,
    private guestSvc: GuestService,
    private router: Router,
    private activatedRoute: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.buildForm();
    this.setGuestId();
    this.setPageMode();
    if (this.pageMode == PageMode.Edit) {
      this.loadGuest();
    }
  }

  addEditGuest() {
    if (this.guestForm.valid) {
      if (this.pageMode == PageMode.Create) {
        this.guestSvc.addNewGuest(this.guestForm.value).subscribe({
          next: () => {
            this.router.navigate(['/guest']);
          },
          error: (error: HttpErrorResponse) => {
            console.log(error);
            this.guestForm.controls['email'].setErrors({ incorrect: true });
          },
        });
      } else {
        this.guestSvc.editGuest(this.guestId!, this.guestForm.value).subscribe({
          next: (guestFromApi) => {
            this.router.navigate(['/guest']);
          },
          error: (error: HttpErrorResponse) => {
            console.log(error);
          },
        });
      }
    }
  }

  private loadGuest() {
    this.guestSvc.getGuest(this.guestId!).subscribe({
      next: (guestFromApi: Guest) => {
        this.guest = guestFromApi;
        this.patchForm(guestFromApi);

        if (guestFromApi.images) {
          this.images = guestFromApi.images;
        }
      },
      error: (error: HttpErrorResponse) => {
        console.log(error);
      },
    });
  }

  uploadFinished(uploaderImages: UploaderImage[]) {
    this.guestForm.patchValue({
      images: uploaderImages,
    });
  }

  private setPageMode(): void {
    if (this.guestId) {
      this.pageMode = PageMode.Edit;
    }
  }

  private setGuestId(): void {
    this.guestId = Number(this.activatedRoute.snapshot.paramMap.get('id'));
  }

  private buildForm() {
    this.guestForm = this.fb.group({
      id: [0],
      name: ['', Validators.required],
      gender: ['', Validators.required],
      dob: ['', Validators.required],
      images: [[]],
    });
  }

  private patchForm(guestFromApi: Guest) {
    this.guestForm.patchValue({
      id: this.guestId,
      name: guestFromApi.name,
      gender: guestFromApi.gender,
      dob: guestFromApi.dob,
      images: guestFromApi.images,
    });
  }
}
