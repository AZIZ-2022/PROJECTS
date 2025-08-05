import { Module } from '@nestjs/common';
import { AuthController } from './auth.controller';
import { AuthService } from './auth.service';
import { JwtModule } from '@nestjs/jwt';
import { JwtStrategy } from './jwt.strategy';
import { TypeOrmModule } from '@nestjs/typeorm';
import { user } from 'src/user/user/user.entity';
import { AuthGuard } from './auth.guard';

@Module({
  imports: [
    TypeOrmModule.forFeature([user]),
    JwtModule.register({
      secret: 'your-secret',
      signOptions: { expiresIn: '1d' },
    }),
  ],
 
  controllers: [AuthController],
  providers: [AuthService, JwtStrategy, AuthGuard],
  
})
export class AuthModule {}
