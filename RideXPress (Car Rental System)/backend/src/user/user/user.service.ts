import { Injectable, NotFoundException } from '@nestjs/common';
import { InjectRepository } from '@nestjs/typeorm';
import { Repository } from 'typeorm';
import { user } from 'src/user/user/user.entity';
import { createuser } from 'src/user/user/DTO/user.dto';
import * as bcrypt from 'bcrypt';
import { SmsService } from 'src/sms/sms.service';
import { join } from 'path';
import * as fs from 'fs'; // Add this import


@Injectable()
export class UserService {
  constructor(
    @InjectRepository(user) private userRepo: Repository<user>,
    private smsService: SmsService,
  ) {}

  
  async viewProfile(token: string) {
  const userData = await this.userRepo.findOne({ where: { loginToken: token } });

  if (!userData) {
    throw new NotFoundException('User not found or invalid token');
  }

  const { password, loginToken, id, otp, ...safeUser } = userData;

  const profilePictureUrl = userData.profilePicture
    ? `http://localhost:3001${userData.profilePicture.replace(/\\/g, '/')}`
    : null;
  
   console.log(profilePictureUrl);

  return {
    ...safeUser,
    password: '********',
    profilePicture: profilePictureUrl,
  };
}


  
  async updateProfile(token: string, updateUserDto: createuser) {
    const user = await this.userRepo.findOne({ where: { loginToken: token } });
  
    if (!user) {
      throw new NotFoundException('User not found or invalid token');
    }
  
    
    if (updateUserDto.password) {
      updateUserDto.password = await bcrypt.hash(updateUserDto.password, 10);
    }
  
    Object.assign(user, updateUserDto);
    
   



    await this.userRepo.save(user);
  
    
    const { password, loginToken,  otp, id, ...safeUser } = user;
  
    return {
      message: 'Profile updated successfully',
      user: {
        ...safeUser,
        password: '********',
      },
    };
  }




  async requestDeleteProfile(token: string) {
    const user = await this.userRepo.findOne({ where: { loginToken: token } });
  
    if (!user) {
      throw new NotFoundException('User not found or invalid token');
    }
  
    const otp = Math.floor(100000 + Math.random() * 900000).toString();
    user.otp = otp;
    await this.userRepo.save(user);
  
    await this.smsService.sendSms(user.phone, `Your OTP to delete account is: ${otp}`);
    return { message: 'OTP sent to your registered phone number.' };
  }
  


  async confirmDeleteProfile(token: string, otp: string) {
    const user = await this.userRepo.findOne({ where: { loginToken: token } });
  
    if (!user) {
      throw new NotFoundException('User not found or invalid token');
    }
  
    if (user.otp !== otp) {
      throw new NotFoundException('Invalid OTP');
    }
  
    await this.userRepo.remove(user);
    return { message: 'Profile deleted successfully' };
  }
  

 async updateProfilePicture(token: string, file: Express.Multer.File) {
  const user = await this.userRepo.findOne({ where: { loginToken: token } });

  if (!user) {
    throw new NotFoundException('User not found or invalid token');
  }

  // Delete old profile picture if exists
  if (user.profilePicture) {
    try {
      const oldImagePath = join(__dirname, '..', '..', 'uploads', user.profilePicture);
      fs.unlinkSync(oldImagePath);
    } catch (err) {
      console.error('Error deleting old profile picture:', err);
    }
  }

  // Save new profile picture path
  // Save new profile picture path (relative path without '/uploads')
  const relativePath = `profile/${file.filename}`;
  user.profilePicture = `/uploads/${relativePath}`; 
  await this.userRepo.save(user);

  return {
    profilePicture: `http://localhost:3001/uploads/${relativePath}`,
    message: 'Profile picture updated successfully'
  };
}








  

}
