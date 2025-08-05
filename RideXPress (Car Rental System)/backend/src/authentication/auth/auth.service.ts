import { Injectable, ConflictException, NotFoundException, UnauthorizedException, BadRequestException } from '@nestjs/common';
import { JwtService } from '@nestjs/jwt';
import { InjectRepository } from '@nestjs/typeorm';
import { Repository } from 'typeorm';
import { user } from 'src/user/user/user.entity';
import { createuser } from 'src/user/user/DTO/user.dto';
import * as nodemailer from 'nodemailer';
import * as bcrypt from 'bcrypt';

@Injectable()
export class AuthService {
  constructor(
    @InjectRepository(user) private userRepo: Repository<user>,
    private jwtService: JwtService,
  ) {}

  // SIGNUP
  async signup(dto: createuser, profilePicture?: string) {
    const existing = await this.userRepo.findOne({ where: { email: dto.email } });
    if (existing) throw new ConflictException('Email already registered');

    const hashedPassword = await bcrypt.hash(dto.password, 10);

    const newUser = this.userRepo.create({
      ...dto,
      password: hashedPassword,
      profilePicture,
    });

    await this.userRepo.save(newUser);
    return { message: 'Signup successful!' };
  }


  

  //LOGIN
  async login(email: string, password: string) {
    const userFound = await this.userRepo.findOne({ where: { email } });
  
    if (!userFound) {
      throw new UnauthorizedException('Invalid credentials');
    }
  
    const isPasswordValid = await bcrypt.compare(password, userFound.password);
    if (!isPasswordValid) {
      throw new UnauthorizedException('Invalid credentials');
    }
  
    const payload = { sub: userFound.id, email: userFound.email };
    const jwtToken = this.jwtService.sign(payload);
  
    userFound.loginToken = jwtToken;
    await this.userRepo.save(userFound);
  
    return { message: 'Login successful', loginToken: jwtToken };
  }
 
  async logout(loginToken: string) {
    const userFound = await this.userRepo.findOne({ where: { loginToken } });
    if (!userFound) throw new NotFoundException('Invalid token or already logged out');
  
    userFound.loginToken = null;
    await this.userRepo.save(userFound);
  
    return { message: 'Logged out successfully' };
  }
  

  // FORGOT PASSWORD 
 async forgotPassword(email: string) {
  const userFound = await this.userRepo.findOne({ where: { email } });
  if (!userFound) throw new NotFoundException('Email not registered');

  if (userFound.loginToken) {
    throw new UnauthorizedException('Logout first before resetting password.');
  }

  const otp = Math.floor(100000 + Math.random() * 900000).toString(); 
  userFound.otp = otp;
  await this.userRepo.save(userFound);

  await this.sendOtpEmail(userFound.email, otp);

  return { message: 'OTP sent to your email' };
}



  async resetPassword(email: string, otp: string, newPassword: string) {
  const userFound = await this.userRepo.findOne({ where: { email } });
  if (!userFound) throw new NotFoundException('Email not registered');

  if (userFound.loginToken) {
    throw new UnauthorizedException('Logout first before resetting password.');
  }

  if (userFound.otp !== otp) {
    throw new BadRequestException('Invalid OTP');
  }

  const hashedPassword = await bcrypt.hash(newPassword, 10);
  userFound.password = hashedPassword;
  userFound.otp = null;
  await this.userRepo.save(userFound);

  return { message: 'Password reset successful' };
}


  
  private async sendOtpEmail(toEmail: string, otp: string) {
    const transporter = nodemailer.createTransport({
      service: 'gmail',
      auth: {
        user: 'aziz22470131@gmail.com', 
        pass: 'rklw aahk qxxh tpvu', 
      },
    });

    const mailOptions = {
      from: 'aziz22470131@gmail.com',
      to: toEmail,
      subject: 'Password Reset OTP',
      text: `Your OTP for password reset is: ${otp}`,
    };

    await transporter.sendMail(mailOptions);
  }
}
