import {  IsNotEmpty, MinLength, } from 'class-validator';


export class cardto {
  @IsNotEmpty()
  name: string;


  @IsNotEmpty()
  model: string;

  @IsNotEmpty()
  mileage: string;

  @IsNotEmpty()
  fuel_type: string;

  @MinLength(6)
  license_number: string;






  
}