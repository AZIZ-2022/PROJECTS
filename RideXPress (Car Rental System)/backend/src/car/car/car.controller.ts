import {Controller,Post,Get,Patch,Delete,Body,Param,Headers,UnauthorizedException,UseInterceptors, UploadedFile,UsePipes,BadRequestException,ValidationPipe,Res,Query} from '@nestjs/common';
import { FileInterceptor } from '@nestjs/platform-express';
import { CarService } from './car.service';
import { cardto } from 'src/car/car/DTO/car.dto';
import { user } from 'src/user/user/user.entity';
import { InjectRepository } from '@nestjs/typeorm';
import { Repository } from 'typeorm';
import * as path from 'path';
import * as fs from 'fs';
import { Response } from 'express';
import { diskStorage } from 'multer';


@Controller('/car')
export class CarController {
  constructor(
    private readonly carService: CarService,
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

  @Post('add')
  @UseInterceptors(
    FileInterceptor('carPicture', {
      storage: diskStorage({
        destination: './uploads/cars',  // Directory to store images
        filename: (req, file, cb) => {
          const ext = path.extname(file.originalname);  // Get file extension
          cb(null, `${Date.now()}${ext}`);  // Rename the file to avoid conflicts
        },
      }),
    }),
  )
  async addCar(
    @UploadedFile() file: Express.Multer.File,  // Handle the uploaded file
    @Body() carDto: cardto,
  ) {
    const carPicture = file
      ? `/uploads/cars/${file.filename}`  // Generate URL for the uploaded image
      : undefined;

    return this.carService.addCar(carDto, carPicture);  // Call service to save the car with picture URL
  }


  @Get('all')
async getAllCars(
  @Headers('authorization') authHeader: string,
  @Res() res: Response,
) {
  await this.verifyToken(authHeader); 
  return this.carService.getAllCars(res);
}
  

  @Patch(':id/update')
  @UsePipes(new ValidationPipe())
  async updateCar(
    @Param('id') id: number,
    @Body() carDto: cardto,
    @Headers('authorization') authHeader: string,
  ) {
    
    await this.verifyToken(authHeader); 
    return this.carService.updateCar(id, carDto);
  }

  @Delete(':id/delete')
  async deleteCar(@Param('id') id: number, @Headers('authorization') authHeader: string) {
   
    await this.verifyToken(authHeader);
    return this.carService.deleteCar(id);
  }



  @Get('stats/pdf')
  async getCarStatsPdf(@Headers('authorization') authHeader: string, @Res() res: Response) {
    await this.verifyToken(authHeader);
    return this.carService.generateCarStatsPDF(res);
  }

 @Get('list')
async listAllCars(@Headers('authorization') authHeader: string) {
  await this.verifyToken(authHeader); // ensure token logic matches
  return this.carService.fetchAllCars();
}

  
@Get(':id')
  async getCarById(@Param('id') id: number, @Headers('authorization') authHeader: string) {
    
    await this.verifyToken(authHeader); 
    return this.carService.getCarById(id);
  }

  
@Patch(':id/upload-picture')
@UseInterceptors(
  FileInterceptor('carPicture', {
    storage: diskStorage({
      destination: './uploads/cars',
      filename: (req, file, cb) => {
        const ext = path.extname(file.originalname);
        cb(null, `${Date.now()}${ext}`);
      },
    }),
  }),
)
async uploadCarPicture(
  @Param('id') id: number,
  @UploadedFile() file: Express.Multer.File,
  @Headers('authorization') authHeader: string,
) {
  await this.verifyToken(authHeader);
  
  if (!file) {
    throw new BadRequestException('No file uploaded');
  }

  const carPicture = `/uploads/cars/${file.filename}`;
  return this.carService.updateCarPicture(id, carPicture);
}




  




}
