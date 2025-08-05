import { Injectable, NotFoundException,BadRequestException } from '@nestjs/common';
import { InjectRepository } from '@nestjs/typeorm';
import { Repository } from 'typeorm';
import { car } from './car.entity';
import { cardto } from 'src/car/car/DTO/car.dto';
import { user } from 'src/user/user/user.entity';
import * as PDFDocument from 'pdfkit';
import { Response } from 'express';
import { Res } from '@nestjs/common';
import { ChartJSNodeCanvas } from 'chartjs-node-canvas';
import { ChartConfiguration } from 'chart.js';




@Injectable()
export class CarService {
  constructor(
    @InjectRepository(car) private carRepo: Repository<car>,
    @InjectRepository(user) private userRepo: Repository<user>,
 

  ) {}


  async findUserByToken(token: string) {
    return this.userRepo.findOne({ where: { loginToken: token } });
  }

  // Add a new car
  // Add a new car
async addCar(carDto: cardto, carPicture?: string) {
    // Check if car with the same license number already exists
    const existingCar = await this.carRepo.findOne({ where: { license_number: carDto.license_number } });
    if (existingCar) {
      throw new BadRequestException('This car already exists');
    }

    // Create a new car entity and save to the database
    const newCar = this.carRepo.create({
      ...carDto,
      carPicture,  // Store the car picture URL if available
    });

    await this.carRepo.save(newCar);

    const { customerName, customerEmail, ...safeCar } = newCar;

    return { message: 'Car added successfully!', car: safeCar };
  }


  
  async getAllCars(res: Response) {
    const cars = await this.carRepo.find();
  
    const doc = new PDFDocument();
  
    res.setHeader('Content-Type', 'application/pdf');
    res.setHeader('Content-Disposition', 'attachment; filename="car-list.pdf"');
  
    doc.pipe(res);
  
    doc.fontSize(25).text('Car List', { align: 'center' });
    doc.moveDown();
  
    cars.forEach((car, index) => {
      doc.fontSize(14).text(
        `${index + 1}. Car ID: ${car.id},Name: ${car.name}, Model: ${car.model},Mileage:${car.mileage},Fuel Type: ${car.fuel_type},License Number: ${car.license_number},IsBooked: ${car.isBooked}`
      );
      doc.moveDown(0.5);
    });
  
    doc.end();
  }

  
  async getCarById(id: number) {
    const car = await this.carRepo.findOne({ where: { id } });
    if (!car) {
      throw new NotFoundException('Car not found');
    }
    return car;
  }

  
  
  
async updateCar(id: number, carDto: cardto) {
  const car = await this.carRepo.findOne({ where: { id } });
  if (!car) {
    throw new NotFoundException('Car not found');
  }

  const duplicateCar = await this.carRepo.findOne({ where: { license_number: carDto.license_number } });
  if (duplicateCar && duplicateCar.id !== car.id) {
    throw new BadRequestException('This car exists');
  }

  Object.assign(car, carDto);
  await this.carRepo.save(car);

  
  const { customerName, customerEmail, ...cleanCar } = car;

  return { message: 'Car updated successfully!', car: cleanCar };
}

  


  
  async deleteCar(id: number) {
    const car = await this.carRepo.findOne({ where: { id } });
    if (!car) {
      throw new NotFoundException('Car not found');
    }

    await this.carRepo.remove(car);
    return { message: 'Car deleted successfully' };
  }



  async generateCarStatsPDF(res: Response) {
    const totalCars = await this.carRepo.count();
    const bookedCars = await this.carRepo.count({ where: { isBooked: true } });
    const availableCars = totalCars - bookedCars;
  
    
    const width = 500;
    const height = 300;
    const chartJSNodeCanvas = new ChartJSNodeCanvas({ width, height });
  
    const configuration: ChartConfiguration<'bar'> = {
      type: 'bar',
      data: {
        labels: ['Total Cars', 'Booked Cars', 'Available Cars'],
        datasets: [
          {
            label: 'Car Stats',
            data: [totalCars, bookedCars, availableCars],
            backgroundColor: ['#3498db', '#e74c3c', '#2ecc71'],
          },
        ],
      },
      options: {
        plugins: {
          legend: {
            display: false,
          },
        },
        scales: {
          y: {
            beginAtZero: true,
            ticks: {
              precision: 0,
            },
          },
        },
      },
    };
  
    const imageBuffer = await chartJSNodeCanvas.renderToBuffer(configuration);
  
    
    const doc = new PDFDocument();
    res.setHeader('Content-Type', 'application/pdf');
    res.setHeader('Content-Disposition', 'inline; filename="car-stats.pdf"');
    doc.pipe(res);
  
    doc.fontSize(20).text('Car Statistics Report', { align: 'center' });
    doc.moveDown();
  
    doc.image(imageBuffer, {
      fit: [500, 300],
      align: 'center',
      valign: 'center',
    });
  
    doc.end();
  }


  async fetchAllCars(): Promise<car[]> {
  return this.carRepo.find();
}


async updateCarPicture(id: number, carPicture: string) {
  const car = await this.carRepo.findOne({ where: { id } });
  if (!car) {
    throw new NotFoundException('Car not found');
  }

  car.carPicture = carPicture;
  await this.carRepo.save(car);

  return { message: 'Car picture updated successfully!' };
}











}
