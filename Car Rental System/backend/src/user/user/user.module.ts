import { Module } from '@nestjs/common';
import { TypeOrmModule } from '@nestjs/typeorm';
import { UserService } from './user.service';
import { UserController } from './user.controller';
import { user } from 'src/user/user/user.entity';
import { SmsService } from 'src/sms/sms.service'; 

@Module({
  imports: [TypeOrmModule.forFeature([user])],
  providers: [UserService,SmsService],
  controllers: [UserController],
  exports: [TypeOrmModule],
})
export class UserModule {}
