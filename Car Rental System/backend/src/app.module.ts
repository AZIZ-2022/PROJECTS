import { Module } from '@nestjs/common';
import { AppController } from './app.controller';
import { AppService } from './app.service';
import { TypeOrmModule } from '@nestjs/typeorm';
import { AuthModule } from 'src/authentication/auth/auth.module';
import { UserModule } from './user/user/user.module';
import { CarModule } from './car/car/car.module';
import { BookingModule } from './booking/booking/booking.module';
import { user } from './user/user/user.entity';
import { car } from './car/car/car.entity';
import { booking } from './booking/booking/booking.entity';



@Module({
  imports: [AuthModule,UserModule,CarModule,BookingModule,TypeOrmModule.forRoot({
      type: 'postgres',
      host: 'localhost',
      port: 5432,
      username: 'postgres',
      password: 'aziz123',
      database: 'employee',
      entities: [user,car,booking], 
      synchronize: true, 
    }),
    
  ],
})
export class AppModule {}
