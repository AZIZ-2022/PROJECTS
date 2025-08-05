import { NestFactory } from '@nestjs/core';
import { AppModule } from './app.module';
import * as dotenv from 'dotenv';
import { join } from 'path';
import { NestExpressApplication } from '@nestjs/platform-express';

dotenv.config();

async function bootstrap() {
  const app = await NestFactory.create<NestExpressApplication>(AppModule);

  // ✅ Serve static files for profile and car images
    app.useStaticAssets(join(__dirname, '..', 'uploads', 'profile'), {
    prefix: '/uploads/profile',  // Car pictures will be accessed via '/uploads/cars/{image-name}'
  });

  app.useStaticAssets(join(__dirname, '..', 'uploads', 'cars'), {
    prefix: '/uploads/cars',  // Car pictures will be accessed via '/uploads/cars/{image-name}'
  });

  // ✅ Enable CORS for frontend
  app.enableCors({
    origin: 'http://localhost:3000',
    credentials: true,
  });

  await app.listen(3001);
}
bootstrap();
