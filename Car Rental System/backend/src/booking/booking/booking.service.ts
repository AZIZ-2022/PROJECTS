import { Injectable, NotFoundException, BadRequestException } from '@nestjs/common';
import { InjectRepository } from '@nestjs/typeorm';
import { Repository } from 'typeorm';
import { booking } from 'src/booking/booking/booking.entity';  
import { car } from 'src/car/car/car.entity';
import { BookingDto } from 'src/booking/booking/DTO/booking.dto';

@Injectable()
export class BookingService {
  constructor(
    @InjectRepository(booking)
    private bookingRepo: Repository<booking>,

    @InjectRepository(car)
    private carRepo: Repository<car>,
  ) {}

  async requestBooking(body: BookingDto) {
    const carFound = await this.carRepo.findOne({ where: { id: body.carId } });

    if (!carFound) {
      throw new NotFoundException('Car not found');
    }

    if (carFound.status !== 'Available') {
      throw new BadRequestException('Car is not available for booking');
    }

    const newBooking = new booking();
    newBooking.carId = body.carId;
    newBooking.customerName = body.customerName;
    newBooking.customerEmail = body.customerEmail;
    newBooking.pickupLocation = body.pickupLocation;
    newBooking.destinationLocation = body.destinationLocation;
    newBooking.customerPhoneNumber = body.customerPhoneNumber;
    newBooking.status = 'Pending';

    return await this.bookingRepo.save(newBooking);
  }

  async setPriceAndDistance(id: number, distance: number) {
    const bookingFound = await this.bookingRepo.findOne({ where: { id } });

    if (!bookingFound) {
      throw new NotFoundException('Booking not found');
    }

    if (bookingFound.status !== 'Accepted') {
      throw new BadRequestException('You must accept the booking before setting price and distance.');
    }

    if (isNaN(distance) || distance <= 0) {
    throw new BadRequestException('Invalid distance value');
  }

    bookingFound.distance = distance;
    bookingFound.price = distance * 20; // 20 Taka per km

    await this.bookingRepo.save(bookingFound);

    return {
      message: 'Distance and price set successfully',
      distance: bookingFound.distance,
      price: bookingFound.price,
    };
  }

  async getAllRequests() {
    const bookings = await this.bookingRepo.find({ where: { status: 'Pending' } });

    return bookings.map((booking) => {
      const pickupEncoded = encodeURIComponent(booking.pickupLocation);
      const destinationEncoded = encodeURIComponent(booking.destinationLocation);

      const pickupUrl = `https://www.google.com/maps/search/?api=1&query=${pickupEncoded}`;
      const destinationUrl = `https://www.google.com/maps/search/?api=1&query=${destinationEncoded}`;
      const routeMapUrl = `https://www.google.com/maps/dir/?api=1&origin=${pickupEncoded}&destination=${destinationEncoded}`;

      return {
        id: booking.id,
        carId: booking.carId,
        customerName: booking.customerName,
        customerEmail: booking.customerEmail,
        pickupLocation: booking.pickupLocation,
        destinationLocation: booking.destinationLocation,
        pickupMapUrl: pickupUrl,
        destinationMapUrl: destinationUrl,
        routeMapUrl: routeMapUrl,
        status: booking.status,
        distance: booking.distance || null,
        price: booking.price || null,
      };
    });
  }

  // New method to get a booking by ID
  async getBookingById(id: number) {
    const booking = await this.bookingRepo.findOne({ where: { id } });

    if (!booking) {
      throw new NotFoundException('Booking not found');
    }

    const pickupEncoded = encodeURIComponent(booking.pickupLocation);
    const destinationEncoded = encodeURIComponent(booking.destinationLocation);

    const pickupUrl = `https://www.google.com/maps/search/?api=1&query=${pickupEncoded}`;
    const destinationUrl = `https://www.google.com/maps/search/?api=1&query=${destinationEncoded}`;
    const routeMapUrl = `https://www.google.com/maps/dir/?api=1&origin=${pickupEncoded}&destination=${destinationEncoded}`;

    return {
      id: booking.id,
      carId: booking.carId,
      customerName: booking.customerName,
      customerEmail: booking.customerEmail,
      pickupLocation: booking.pickupLocation,
      destinationLocation: booking.destinationLocation,
      pickupMapUrl: pickupUrl,
      destinationMapUrl: destinationUrl,
      routeMapUrl: routeMapUrl,
      status: booking.status,
      distance: booking.distance || null,
      price: booking.price || null,
    };
  }

  async showAllBookings() {
    // Fetch all bookings (both accepted and pending)
    const bookings = await this.bookingRepo.find();

    return bookings.map((booking) => {
      const pickupEncoded = encodeURIComponent(booking.pickupLocation);
      const destinationEncoded = encodeURIComponent(booking.destinationLocation);

      const pickupUrl = `https://www.google.com/maps/search/?api=1&query=${pickupEncoded}`;
      const destinationUrl = `https://www.google.com/maps/search/?api=1&query=${destinationEncoded}`;
      const routeMapUrl = `https://www.google.com/maps/dir/?api=1&origin=${pickupEncoded}&destination=${destinationEncoded}`;

      return {
        id: booking.id,
        carId: booking.carId,
        customerName: booking.customerName,
        customerEmail: booking.customerEmail,
        pickupLocation: booking.pickupLocation,
        destinationLocation: booking.destinationLocation,
        pickupMapUrl: pickupUrl,
        destinationMapUrl: destinationUrl,
        routeMapUrl: routeMapUrl,
        status: booking.status,
        distance: booking.distance || null,
        price: booking.price || null,
      };
    });
  }

  async acceptBooking(id: number) {
    const booking = await this.bookingRepo.findOne({ where: { id } });
    if (!booking) throw new NotFoundException('Booking request not found');

    const bookedCar = await this.carRepo.findOne({ where: { id: booking.carId } });
    if (!bookedCar) throw new NotFoundException('Car not found');

    if (bookedCar.isBooked) {
      throw new BadRequestException('This car has already been booked');
    }

    bookedCar.customerName = booking.customerName;
    bookedCar.customerEmail = booking.customerEmail;
    bookedCar.isBooked = true;

    await this.carRepo.save(bookedCar);
    await this.bookingRepo.save(booking);

    booking.status = 'Accepted';
    await this.bookingRepo.save(booking);

    return { message: 'Booking accepted and car updated' };
  }

  async rejectBooking(id: number) {
    const foundBooking = await this.bookingRepo.findOne({ where: { id } });
    if (!foundBooking) throw new NotFoundException('Booking request not found');

    const bookedCar = await this.carRepo.findOne({ where: { id: foundBooking.carId } });
    if (!bookedCar) throw new NotFoundException('Car not found');

    bookedCar.isBooked = false;
    bookedCar.customerName = '';
    bookedCar.customerEmail = '';
    await this.carRepo.save(bookedCar);

    foundBooking.status = 'Rejected';
    await this.bookingRepo.save(foundBooking);

    return { message: 'Booking rejected and car is now available again' };
  }

  async showFullBookings() {
    return await this.bookingRepo.find();
  }
}
