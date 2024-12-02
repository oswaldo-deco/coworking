import { ReactNode } from "react";

export interface Space {
    pricePerHour: ReactNode;
    id: number;         
    name: string;      
    location?: string;  
    capacity?: number;  
    description?: string; 
    createdAt?: Date;   
    updatedAt?: Date;  
  }