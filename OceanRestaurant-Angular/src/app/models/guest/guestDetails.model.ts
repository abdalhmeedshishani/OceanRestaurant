import { Gender } from 'src/app/enums/gender.enum';
import { UploaderImage } from 'src/app/upload/UploaderImage.data';

export interface GuestDetails {
  id: number;
  name: string;
  gender: Gender;
  dob: string;
  age: number;
  images: UploaderImage[];
}
