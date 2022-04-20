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
    id: '',
    name: '',
    country: '',
    address: ''
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

    if (this.company.id === '') {
      this.companyService.addCompany(this.company)
        .subscribe(
          response => {
            this.getAllCompany();
            this.company = {
              id: '',
              name: '',
              country: '',
              address: ''
            };
          });
    }
    else {
      this.updateCompany(this.company);
    }


  }
  deleteCompany(id: string) {
    this.companyService.DeleteCompany(id)
      .subscribe(
        response => {
          this.getAllCompany();
        }
      );
  }

  PopulateFormCompany(company: Company) {
    this.company = company;
  }
  updateCompany(company: Company) {
    this.companyService.PutCompany(company)
      .subscribe(
        response => {
          this.companyService.getAllCompany();

        }
      );

  }
}

