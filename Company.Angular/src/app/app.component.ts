import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Company } from './Models/company.model';
import { CompanyService } from './service/company.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'company';
  companies: Company[] = [];
  company: Company = {
    Id: '',
    Name: '',
    Country: '',
    Address: ''
  }

  constructor(private companyService: CompanyService) {

  }
  ngOnInit(): void {
    this.getAllCompany();
  }
  getAllCompany() {
    this.companyService.getAllCompany()
      .subscribe(
        response => {
          this.companies = response;

        }
      );
  }
  onSubmit() {
    this.companyService.addCompany(this.company)
      .subscribe(
        response => {
          this.getAllCompany();
          this.company = {
            Id: '',
            Name: '',
            Country: '',
            Address: ''
          };
        })
  }
  deleteCompany(id: string) {
    this.companyService.DeleteCompany(id)
      .subscribe(
        response => {
          this.getAllCompany();
        }
      );
  }
}

