import { Module } from '@nestjs/common';
import { CarController } from './car.controller';
import { CarService } from './car.service';
import { TypeOrmModule } from '@nestjs/typeorm';
import { car } from 'src/car/car/car.entity';
import { UserModule } from 'src/user/user/user.module';



@Module({
  imports: [TypeOrmModule.forFeature([car]),UserModule],
  controllers: [CarController],
  providers: [CarService]
})
export class CarModule {}
