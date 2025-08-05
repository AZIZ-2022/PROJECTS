import { Entity, Column, PrimaryGeneratedColumn } from 'typeorm';
import * as bcrypt from 'bcrypt';

@Entity()
export class user {
  @PrimaryGeneratedColumn()
  id: number;

  @Column()
  name: string;

  @Column({ unique: true })
  email: string;

  @Column()
  password: string;


  @Column()
  phone: string;


  @Column()
  address: string;



  @Column('text', { nullable: true })
  loginToken: string | null;    

  @Column('text', { nullable: true })
  otp: string | null;  
  
  @Column({ nullable: true })
profilePicture: string;





}
