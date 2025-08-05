import { IsEmail, IsNotEmpty, MinLength, MaxLength } from 'class-validator';

export class createuser {
  @IsNotEmpty()
  name: string;




  @IsNotEmpty()
  @IsEmail()
  email: string;

  @IsNotEmpty()
  @MinLength(14)
  @MaxLength(14)
  phone: string;


  @IsNotEmpty()
  address: string;

  @MinLength(6)
  password: string;
}
