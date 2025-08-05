import { IsNotEmpty, IsEmail, IsString, Matches } from 'class-validator';

export class BookingDto {
  @IsNotEmpty()
  carId: number;

  @IsNotEmpty()
  customerName: string;

  @IsNotEmpty()
  @IsEmail()
  customerEmail: string;

  @IsNotEmpty()
  pickupLocation: string;

  @IsNotEmpty()
  destinationLocation: string;

  @IsNotEmpty()
  @IsString()
  @Matches(/^\+8801[3-9][0-9]{8}$/, {
    message: 'Phone number must be a valid Bangladeshi number starting with +8801',
  })
  customerPhoneNumber: string;
}
