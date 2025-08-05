import { Injectable } from '@nestjs/common';
import { CanActivate, ExecutionContext } from '@nestjs/common';
import { JwtService } from '@nestjs/jwt';
import { Observable } from 'rxjs';

@Injectable()
export class AuthGuard implements CanActivate {
  constructor(private readonly jwtService: JwtService) {}

  canActivate(
    context: ExecutionContext,
  ): boolean | Promise<boolean> | Observable<boolean> {
    const request = context.switchToHttp().getRequest();
    const token = request.headers['authorization']?.split(' ')[1];

    if (!token) {
      throw new Error('Authorization token is missing');
    }

    try {
      const decoded = this.jwtService.verify(token, {
        secret: 'your-secret', 
      });
      request.user = decoded; 
      return true;
    } catch (error) {
      throw new Error('Invalid or expired token');
    }
  }
}
