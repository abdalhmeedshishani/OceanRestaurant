import { UploaderImage } from 'src/app/upload/UploaderImage.data';
import { Gender } from '../../enums/gender.enum';

export interface Guest {
  id: number;
  name: string;
  gender: Gender;
  dob: string;
  age: number;
  images: UploaderImage[];
}
