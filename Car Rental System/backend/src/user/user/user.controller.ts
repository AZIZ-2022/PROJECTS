import { Controller,Get,Patch,Delete, Body, Headers,UsePipes,UseInterceptors,UploadedFile,ValidationPipe,UnauthorizedException,} from '@nestjs/common';
import { UserService } from './user.service';
import { createuser } from 'src/user/user/DTO/user.dto';
import { Query, Post } from '@nestjs/common';
import { FileInterceptor } from '@nestjs/platform-express';
import { diskStorage } from 'multer';
import { extname } from 'path';  // Add this import

@Controller('profile')
export class UserController {
  constructor(private readonly userService: UserService) {}

  @Get('view')
  async viewProfile(@Headers('Authorization') authorizationHeader: string) {
    if (!authorizationHeader) {
      throw new UnauthorizedException('Authorization token is required');
    }

    const token = this.extractToken(authorizationHeader);
    return this.userService.viewProfile(token);
  }

  @Patch('update')
  @UsePipes(new ValidationPipe())
  async updateProfile(
    @Headers('Authorization') authorizationHeader: string,
    @Body() updateUserDto: createuser,
  ) {
    if (!authorizationHeader) {
      throw new UnauthorizedException('Authorization token is required');
    }

    const token = this.extractToken(authorizationHeader);
    return this.userService.updateProfile(token, updateUserDto);
  }


  @Post('delete/request')
  async requestDeleteProfile(@Headers('Authorization') auth: string) {
    if (!auth) throw new UnauthorizedException('Token required');
    const token = this.extractToken(auth);
    return this.userService.requestDeleteProfile(token);
  }



  @Delete('delete/confirm')
async confirmDeleteProfile(
  @Headers('Authorization') auth: string,
  @Query('otp') otp: string
) {
  if (!auth) throw new UnauthorizedException('Token required');
  if (!otp) throw new UnauthorizedException('OTP is required');
  const token = this.extractToken(auth);
  return this.userService.confirmDeleteProfile(token, otp);
}




@Post('update-picture')
@UseInterceptors(FileInterceptor('profilePicture', {
  storage: diskStorage({
    destination: './uploads/profile',
    filename: (req, file, cb) => {
      const randomName = Array(32).fill(null).map(() => 
        (Math.round(Math.random() * 16)).toString(16)).join('');
      return cb(null, `${randomName}${extname(file.originalname)}`);
    }
  })
}))
async updateProfilePicture(
  @Headers('Authorization') auth: string,
  @UploadedFile() file: Express.Multer.File
) {
  if (!auth) throw new UnauthorizedException('Token required');
  const token = this.extractToken(auth);
  return this.userService.updateProfilePicture(token, file);
}










  private extractToken(authorizationHeader: string): string {
    const parts = authorizationHeader.split(' ');
    if (parts.length === 2 && parts[0] === 'Bearer') {
      return parts[1];
    } else {
      throw new UnauthorizedException('Invalid token format');
    }
  }
}
