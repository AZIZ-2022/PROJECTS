import { Module } from '@nestjs/common';
import { BookingController } from './booking.controller';
import { BookingService } from './booking.service';
import { TypeOrmModule } from '@nestjs/typeorm';
import { booking } from './booking.entity';
import { CarModule } from 'src/car/car/car.module';
import { UserModule } from 'src/user/user/user.module';
import { car } from 'src/car/car/car.entity';

@Module({
  imports: [TypeOrmModule.forFeature([booking,car]),CarModule,UserModule],
  controllers: [BookingController],
  providers: [BookingService]
})
export class BookingModule {}
