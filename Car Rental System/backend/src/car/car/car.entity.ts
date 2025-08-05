import { Entity, Column, PrimaryGeneratedColumn } from 'typeorm';



@Entity()
export class car {
  @PrimaryGeneratedColumn()
  id: number;

  @Column()
  name: string;

  @Column()
  model: string;

  @Column()
  mileage: string;

  @Column()
  fuel_type: string;

  @Column({ unique: true })
  license_number: string;


  @Column({ default: false })
damageReport: boolean;


@Column({ nullable: true ,type: 'varchar' })
customerName: string ;   

@Column({ nullable: true, type: 'varchar' })
customerEmail: string ;  

@Column({ default: false })
isBooked: boolean;
  
@Column({ default: 'Available' })
status: string;

@Column({ nullable: true, type: 'varchar' })
  carPicture: string;  // This will store the URL or file path of the image






}

