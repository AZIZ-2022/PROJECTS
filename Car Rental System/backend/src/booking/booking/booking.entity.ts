import { Entity, Column, PrimaryGeneratedColumn } from 'typeorm';

@Entity()
export class booking {
  @PrimaryGeneratedColumn()
  id: number;

  @Column()
  carId: number;

  @Column({ nullable: true })
  customerName: string;

  @Column({ nullable: true })
  customerEmail: string;



  @Column()
  pickupLocation: string;

  @Column()
  destinationLocation: string; 

  @Column({ nullable: true, type: 'float' })
  distance: number; 

  @Column({ nullable: true, type: 'float' })
  price: number; 



  @Column({ nullable: true })
  customerPhoneNumber: string;  




  @Column({ default: 'pending' }) 
  status: string; 
}
