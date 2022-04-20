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
  addCompany(company: Company): Observable<Company> {

    return this.http.post<Company>(this.baseUrl, company)

  }

  DeleteCompany(id: string): Observable<Company> {

    return this.http.delete<Company>(this.baseUrl + '/' + id);

  }
  PutCompany(company: Company): Observable<Company> {

    return this.http.put<Company>(this.baseUrl + '/' + company.id, company);

  }

}
