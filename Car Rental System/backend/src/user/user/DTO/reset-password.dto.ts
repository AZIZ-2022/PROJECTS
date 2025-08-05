import { IsEmail, IsNotEmpty, MinLength } from 'class-validator';

export class ResetPasswordDTO {
  @IsEmail()
  @IsNotEmpty()
  email: string;

  @IsNotEmpty()
  otp: string;

  @IsNotEmpty()
  @MinLength(6)
  newPassword: string;
}
