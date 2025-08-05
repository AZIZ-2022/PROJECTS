import { Body, Controller, Post, Param, UsePipes, ValidationPipe, UnauthorizedException,Headers } from '@nestjs/common';
import { AuthService } from './auth.service';
import { createuser } from 'src/user/user/DTO/user.dto';
import { ResetPasswordDTO } from 'src/user/user/DTO/reset-password.dto';
import { JwtService } from '@nestjs/jwt';
import { InjectRepository } from '@nestjs/typeorm';
import { Repository } from 'typeorm';
import { user } from 'src/user/user/user.entity';
import { UploadedFile, UseInterceptors } from '@nestjs/common';
import { FileInterceptor } from '@nestjs/platform-express';
import { diskStorage } from 'multer';
import { extname } from 'path';
import { Express } from 'express';

@Controller('/authentication')
export class AuthController {
  constructor(
    private readonly authService: AuthService,
    private readonly jwtService: JwtService,
    @InjectRepository(user) private readonly userRepo: Repository<user>,
  ) {}

  @Post('signup')
@UseInterceptors(
  FileInterceptor('profilePicture', {
    storage: diskStorage({
      destination: './uploads/profile',
      filename: (req, file, cb) => {
        const ext = extname(file.originalname);
        cb(null, `${Date.now()}${ext}`);
      },
    }),
  }),
)
async signup(
  @UploadedFile() file: Express.Multer.File,
  @Body() body: createuser,
) {
  const profilePicturePath: string | undefined = file ? `/uploads/profile/${file.filename}` : undefined;



  return this.authService.signup(body, profilePicturePath);
}


  @Post('login')
  async login(@Body() body: { email: string; password: string }) {
    const { email, password } = body;
    if (!email || !password) {
      throw new UnauthorizedException('Email and password are required');
    }
    return this.authService.login(email, password);
  }


  @Post('logout')
async logout(@Headers('authorization') authHeader: string) {
  if (!authHeader) throw new UnauthorizedException('No token provided');

  const token = authHeader.replace('Bearer ', '').trim(); 
  return this.authService.logout(token); 
}



 @Post('forgot-password')
forgotPassword(@Body() body: { email: string }) {
  return this.authService.forgotPassword(body.email);
}


  @Post('reset-password')
 @UsePipes(new ValidationPipe())
  resetPassword(@Body() dto:ResetPasswordDTO) {
    return this.authService.resetPassword(dto.email, dto.otp, dto.newPassword);
  }
}
