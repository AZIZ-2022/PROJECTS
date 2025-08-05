import { Controller, Post, Get, Patch, Param, Body, Headers, UnauthorizedException, UsePipes, ValidationPipe } from '@nestjs/common';
import { BookingService } from './booking.service';
import { InjectRepository } from '@nestjs/typeorm';
import { Repository } from 'typeorm';
import { user } from 'src/user/user/user.entity';
import { BookingDto } from 'src/booking/booking/DTO/booking.dto';
import { ParseIntPipe } from '@nestjs/common';

@Controller('booking')
export class BookingController {
  constructor(
    private readonly bookingService: BookingService,
    @InjectRepository(user)
    private userRepo: Repository<user>,
  ) {}

  async verifyToken(authHeader: string): Promise<user> {
    if (!authHeader) {
      throw new UnauthorizedException('Authorization token is required');
    }

    const token = authHeader && authHeader.startsWith('Bearer ') ? authHeader.slice(7) : authHeader;

    const user = await this.userRepo.findOne({ where: { loginToken: token } });
    if (!user) {
      throw new UnauthorizedException('Invalid or missing token');
    }

    return user;
  }


@Post('request')
  @UsePipes(new ValidationPipe())
  async requestBooking(@Body() body: BookingDto) {
    return this.bookingService.requestBooking(body);
  }





  @Get('requests')
  async getAllRequests(@Headers('authorization') token: string) {
    await this.verifyToken(token);
    return this.bookingService.getAllRequests();
  }

  @Get('showall')
  async showAllBookings(@Headers('authorization') token: string) {
    await this.verifyToken(token);  // Ensure the user is authenticated
    return this.bookingService.showAllBookings();  // Get all bookings from the service
  }

  @Get(':id')  // New route to get a specific booking by ID
  async getBookingById(@Param('id') id: number, @Headers('authorization') token: string) {
    await this.verifyToken(token);
    return this.bookingService.getBookingById(id);  // Fetch booking by ID from the service
  }

  @Patch('accept/:id')
  async acceptBooking(@Param('id') id: number, @Headers('authorization') token: string) {
    await this.verifyToken(token);
    return this.bookingService.acceptBooking(id);
  }

  @Patch('reject/:id')
  async rejectBooking(@Param('id') id: number, @Headers('authorization') token: string) {
    await this.verifyToken(token);
    return this.bookingService.rejectBooking(id);
  }

  @Patch('set-price/:id')
  async setPriceAndDistance(@Param('id') id: number, @Body() body: { distance: number }, @Headers('authorization') token: string) {
    await this.verifyToken(token);
    return this.bookingService.setPriceAndDistance(id, body.distance);
  }
}
