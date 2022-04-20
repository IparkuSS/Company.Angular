import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Company } from '../Models/company.model';

@Injectable({
  providedIn: 'root'
})
export class CompanyService {
  baseUrl = 'https://localhost:7148/api/company'
  constructor(private http: HttpClient) { }
  getAllCompany(): Observable<Company[]> {
    return this.http.get<Company[]>(this.baseUrl);
  }
}
